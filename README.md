# Sir
Sir is a distributed system for information retrieval for on-premise or cloud-based architectures, a .Net Core Elasticsearch+Hadoop clone in early development, built on [Resin](https://github.com/kreeben/resin). 

## The problem
Companies of today collect loads of data, information that analysts use with statistical tools and machine learning algorithms to produce predictions on sales and system loads.

There is a problem with big data though. It’s hard to manage and costly to keep around in a queryable state. Most manage to keep a window of data from days or weeks ago readily available but winning companies make all of their historical data available to their analysts. This is a winning concept indeed. Their analysts become smarter. Their machines as well.

These market winners (or soon-to-be) have solved the issue of long-term storing of queryable data by brute-forcing their way to a durable data system. Throwing money, or experienced thus expensive data engineers at the problem usually spawn a Elasticsearch+Hadoop-like system that functions well.

Hadoop experience is as rare as finding a Facebook engineer for hire. The problem is thus left unsolved for the rest of the market players as they will be left behind, eventually.

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
