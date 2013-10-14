SODA2 for .net
==============

These are C# bindings for the SODA2 API, built with VS 2013 and .net 4.5.

This library is divided into the **Soda2Consumer**, which provides read-only access to datasets, and the **Soda2Publisher**, which provides methods to update and delete data.  The Soda2Publisher simply adds extension methods to the Dataset class in Soda2Consumer.

The **SampleDataConsumerApp** is an example for querying datasets.

The **SampleDataPublisherApp** is an example for uploading data from a local CSV file.
