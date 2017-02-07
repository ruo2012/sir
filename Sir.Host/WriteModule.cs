﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using log4net;
using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using Resin;
using Resin.Analysis;
using Resin.Sys;

namespace Sir.Host
{
    public class WriteModule : NancyModule
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(WriteModule));

        public WriteModule()
        {
            Post["/{indexName}/add"] = parameters =>
            {
                var docs = this.Bind<Dictionary<string, string>[]>();
                var indexName = parameters.indexName;
                var timer = new Stopwatch();
                timer.Start();
                HandleAddRequest(indexName, docs);
                Log.InfoFormat("upserted {0} docs to {1} in {2}", docs.Length, indexName, timer.Elapsed);
                return HttpStatusCode.NoContent;
            };

            Post["/{indexName}/remove/{docId}"] = parameters =>
            {
                var docId = parameters.docId;
                var indexName = parameters.indexName;
                var timer = new Stopwatch();
                timer.Start();
                HandleRemoveRequest(indexName, docId);
                Log.DebugFormat("removed docs {0} in {1}", docId, timer.Elapsed);
                return HttpStatusCode.NoContent;
            };
        }

        private void HandleRemoveRequest(string indexName, string docId)
        {
        }

        private void HandleAddRequest(string indexName, IEnumerable<Dictionary<string, string>> docs)
        {
            try
            {
                var dir = Path.Combine(Helper.GetDataDirectory(), indexName);
                using (var writer = new IndexWriter(dir, new Analyzer()))
                {
                    writer.Write(docs.Select(dic=>new Document(dic)));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }

    public class StringDictionaryBinder : IModelBinder
    {
        public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration, params string[] blackList)
        {
            return DeserializeFromStream(context.Request.Body);
        }

        private static object DeserializeFromStream(Stream stream)
        {
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                var obj = serializer.Deserialize<Dictionary<string, string>[]>(jsonTextReader);
                return obj;
            }
        }

        public bool CanBind(Type modelType)
        {
            var can = modelType.BaseType == typeof(Array);
            return can;
        }
    }
}