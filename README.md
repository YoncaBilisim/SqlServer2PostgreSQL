# SqlServer2PostgreSQL
 
Moves tables and data in a schema on SqlServer to PostgreSql.

1- Tables and fields in SqlServer are migrated to PostgreSql based on their appropriate data types.

2- The data on SqlServer is exported as a text file for each table.

3- It is copied to the PostgreSql server with SFTP .

4- The data is loaded into PostgreSql with the COPY command.
