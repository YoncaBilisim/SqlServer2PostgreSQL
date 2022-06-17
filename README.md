# SqlServer2PostgreSQL

SqlServer üzerindeki bir şemadaki tabloları ve verileri PostgreSql'ye taşır.

1- SqlServer'daki **tablolar** ve **alanlar**, uygun veri tiplerine göre PostgreSql üzerinde oluşturulur.

2- SqlServer üzerindeki veriler, her tablo için bir **metin** dosyası olacak şekilde **dışa aktarılır**.

3- **SFTP** protololü üzerinden PostgreSql sunucusuna kopyalanır.

4- **COPY** komutu ile veriler PostgreSql içerisine aktarılır.

...

...

Moves tables and data in a schema on SqlServer to PostgreSql.

1- Tables and fields in SqlServer are **migrated** to PostgreSql based on their appropriate data types.

2- The data on SqlServer is **exported** as a **text** file for each table.

3- It is copied to the PostgreSql server with **SFTP**.

4- The data is loaded into PostgreSql with the **COPY** command.
