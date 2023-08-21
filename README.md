# BlazorDbTest
The file BTTest contains the SQL DB associated with the project.
There is a single table with two columns and one record.  The project contains one controller and one service that uses a single DBContext that has the one table in it.
Page refreshes result in a hard crash after around 250 to 300 hits.
