# Sir
Sir is a distributed system for information retrieval, a .Net Core Elasticsearch+Hadoop clone in early development, built on [Resin](https://github.com/kreeben/resin). 

## The problem
Companies of today collect loads of data, an important source of information to analysts who use statistical tools and machine learning to produce predictions on sales and system loads.

The problem with big data is it’s hard to manage and costly to keep around in a queryable state. Most manage to keep a window of data from days or weeks ago readily available but winning companies make all of their historical data available to their analysts. This is a winning concept indeed. Their analysts become smarter. Their machines as well.

These market winners (or soon-to-be) have solved the issue of long-term storing of queryable data by brute-forcing their way to a durable data system. Throwing money, or experienced thus expensive data engineers at the problem usually spawn a Elasticsearch+Hadoop-like system.

Hadoop experience is as rare as finding a Facebook engineer for hire. The problem is thus left unsolved for the rest of the market players and they will be left behind, eventually.

## Our technology
We've built a cross-platform search engine library. We call it [Resin](https://github.com/kreeben/resin). Looking around, it's closest competitor is Lucene. We are aiming for ~80 % feature parity with Lucene (term, boolean, phrase, fuzzy, fuzzy phrase and range querying). 

Resin is currently in beta and we are working our way towards a release by launching several release candidates. Right now we are at RC2 with a third around the corner. 

Being in beta, Resin is still faster than Lucene at indexing. In many scenarios that is also the case for querying. Before launching version 1 we aim to make Resin faster than Lucene for all types of queries.

We also aim to sharpen Resin's edge over Lucene even further by adding stronger compression to our data structures and document store.

## Sir
Sir is Resin distributed. 

It's main competitor is Elasticsearch ("ELK"). Targeting a cross-platform framework (.Net Core) and being built on Resin we feel very excited about challenging the ELK stack.

Our plan for beating Elasticsearch revolves around four key features:

- faster indexing
- faster querying
- higher compression
- more expressive querying language that allow for joins between databases or tables (indices).

## Get in touch

marcuslager at g mail dot com.
