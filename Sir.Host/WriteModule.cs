﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

            Post["/{indexName}/remove/{ids}"] = parameters =>
            {
                var ids = parameters.ids;
                var indexName = parameters.indexName;
                var timer = new Stopwatch();

                timer.Start();
                HandleRemoveRequest(indexName, ids);

                Log.DebugFormat("removed docs {0} in {1}", string.Join(",", ids), timer.Elapsed);

                return HttpStatusCode.NoContent;
            };
        }

        private void HandleRemoveRequest(string indexName, IEnumerable<string> ids)
        {
            try
            {
                var dir = Path.Combine(ToolBelt.GetDataDirectory(), indexName);
                using (var delete = new DeleteOperation(dir, ids))
                {
                    delete.Execute();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        private void HandleAddRequest(string indexName, IEnumerable<Dictionary<string, string>> docs)
        {
            try
            {
                var dir = Path.Combine(ToolBelt.GetDataDirectory(), indexName);
                using (var write = new WriteOperation(dir, new Analyzer(), docs.ToDocuments()))
                {
                    write.Execute();
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