# Sir
Sir is a distributed system for information retrieval for on-premise or cloud-based architectures, a .Net Core Elasticsearch+Hadoop clone in early development, built on [Resin](https://github.com/kreeben/resin). 

## The problem
Companies of today collect loads of data, information that analysts use with statistical tools and machine learning algorithms to produce predictions on sales and system loads.

There is a problem with big data though. It’s hard to manage and costly to keep around in a queryable state. Most manage to keep a window of data from days or weeks ago readily available but winning companies make all of their historical data available to their analysts. This is a winning concept indeed. Their analysts become smarter. Their machines as well.

These market winners (or soon-to-be) have solved the issue of long-term storing of queryable data by brute-forcing their way to a durable data system. Throwing money, or experienced thus expensive data engineers at the problem usually spawn a Elasticsearch+Hadoop-like system that functions well.

Other aspiring market place winners give money to cloud operators who quite successfully these days convince companies to store their data outside of their offices, distributed across one or more data centers. 

Hadoop experience is as rare as finding a Facebook engineer for hire and big data cloud solutions are expensive, lacking in querying capabilities and forces one to put enourmous trust with your data partner. 

If you know how to solve the problem of queryable big data there is a good chance you, your analysts and your machines are learning from history. Those that do not will be left behind, eventually.

## Technology
We've built a cross-platform search engine library. We call it [Resin](https://github.com/kreeben/resin). Looking around, it's closest competitor is Lucene.

Resin is faster than Lucene, in many scenarios, at indexing and querying. Before releasing version 1.0 we aim to make Resin faster than Lucene for all types of queries and indexing scenarios.

We also aim to sharpen Resin's edge over Lucene even further by adding stronger compression to our data structures and document store.

## Sir
Sir is Resin distributed. 

It's main competitor is Elasticsearch ("ELK"). Targeting a cross-platform framework (.Net Core) and being built on Resin we feel very excited about challenging the ELK stack.

Our plan for beating Elasticsearch+Hadoop revolves around five key features:

- faster indexing
- faster querying
- higher compression
- more efficient and more reliable way of distributing indices over many machines
- more expressive querying language that allow for joins between databases or tables (indices)

## Investors
If you believe it's time to give to the people of the world search technology so powerful that with the right business strategy you could take on Google, then please, by all means, contact me.
