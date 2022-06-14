Imports System.Data.SqlClient
Imports System.IO
Imports Npgsql
Imports Renci.SshNet

Public Class Form1
    Private myConn As SqlConnection
    Private cmdTab As SqlCommand
    Private wrTab As SqlDataReader
    Private wSftp As SftpClient

    Private Sub MsSQLFormatDosyasiOlustur()
        Dim myConn As SqlConnection
        Dim myCmd As SqlCommand
        Dim wr As SqlDataReader
        Dim results As String = ""
        Dim wpre_str1 As String = ""
        Dim wpre_str2 As String = ""
        Dim str3 As String = ""
        Dim str4 As String = ""
        Dim wc As Integer = 0
        Dim wtable As String = ""
        Dim wpre_datatype As String = ""
        Dim wpre_delim As String


        myConn = New SqlConnection("Server=10.10.111.140;Database=ABYSKASKI;User Id=insoftpro;Password=12345Qwe1")
        'Create a Command object.
        myCmd = myConn.CreateCommand
        myCmd.CommandText = "select TABLE_NAME, count(*) over (partition by TABLE_NAME) FIELD_COUNT, ORDINAL_POSITION, COLUMN_NAME, COLLATION_NAME, DATA_TYPE, 
                                    COALESCE (CHARACTER_OCTET_LENGTH, coalesce((NUMERIC_PRECISION+2) * case DATA_TYPE when 'decimal' then 2 else 1 end,case DATA_TYPE when 'datetime2' then 30 when 'bit' then 1 end )) SIZE
                            from INFORMATION_SCHEMA.COLUMNS c 
                            where exists (select 1 from INFORMATION_SCHEMA.TABLES t where t.TABLE_SCHEMA ='dbo' and t.TABLE_NAME =c.TABLE_NAME and t.TABLE_TYPE ='Base Table')
                            order by TABLE_NAME, ORDINAL_POSITION "

        'Open the connection.
        myConn.Open()
        wr = myCmd.ExecuteReader()

        'Concatenate the query result into a string.
        Do While wr.Read()
            If wr("TABLE_NAME").ToString <> wtable And wtable <> "" Then
                wpre_delim = IIf(wpre_datatype = "nvarchar", """\""\r\n", """\r\n") & """"
                results = results & wpre_str1 & wpre_delim & "      " & wpre_str2
                System.IO.File.WriteAllText("C:\tmp\" & wtable & ".fmt", results)

                results = ""
                wtable = wr("TABLE_NAME").ToString
                wc = 0
                wpre_str1 = ""
                wpre_str2 = ""
                wpre_datatype = ""
                wpre_delim = ""
            Else
                wtable = wr("TABLE_NAME").ToString
            End If

            wc = wc + 1
            If wc = 1 Then
                results = "14.0" & vbCrLf & wr.GetInt32(1) + IIf(wr("DATA_TYPE").ToString = "nvarchar", 1, 0) & vbCrLf
                wc = IIf(wr("DATA_TYPE").ToString = "nvarchar", 2, 1)
            End If

            If wpre_str1 = "" And wr("DATA_TYPE").ToString = "nvarchar" Then
                results = results & "1       SQLCHAR             0       0       ""\""""         0     FIRST_QUOTE                                                 Turkish_100_CI_AS" & vbCrLf
            ElseIf wpre_str1 <> "" Then
                wpre_delim = IIf(wpre_datatype = "nvarchar", """\""~", """~") & IIf(wr("DATA_TYPE").ToString = "nvarchar", "\""""", """")
                results = results & wpre_str1 & wpre_delim & "      " & wpre_str2
            End If

            wpre_str1 = wc.ToString.PadRight(8) & "SQLCHAR             0       " &
                              IIf(IsDBNull(wr("SIZE")), 1, wr("SIZE")).ToString.PadRight(8)

            wpre_str2 = wr("ORDINAL_POSITION").ToString.PadRight(6) &
                              wr("COLUMN_NAME").PadRight(60) &
                              IIf(IsDBNull(wr("COLLATION_NAME")), """""", wr("COLLATION_NAME")) & vbCrLf

            wpre_datatype = wr("DATA_TYPE").ToString
        Loop

        wpre_delim = IIf(wpre_datatype = "nvarchar", """\""\r\n", """\r\n") & """"
        results = results & wpre_str1 & wpre_delim & "      " & wpre_str2
        System.IO.File.WriteAllText("C:\tmp\" & wtable.ToLower & ".fmt", results)

        MsgBox("Bitti")

        'Close the reader and the database connection.
        wr.Close()
        myConn.Close()

    End Sub

    Private Function write_data(pdt As String, pdata As String) As String
        Dim wcomma As String
        wcomma = IIf(pdt Like "*varchar", """", "")
        Select Case pdt
            Case "decimal", "float", "numeric", "real"
                pdata = pdata.Replace(",", ".")
            Case "bit"
                pdata = IIf(pdata = "True", "1", IIf(pdata = "False", "0", ""))
        End Select
        Return IIf(pdata = "", "", wcomma & Replace(pdata, """", "") & wcomma) & txtDelimeter.Text
    End Function

    Private Sub ExportTable(pItem As ListViewItem)
        Dim wSqlCmd As SqlCommand
        Dim wSqlDR As SqlDataReader
        Dim wfileName As String
        Dim wdef As New ArrayList
        Dim wstr As String
        Dim wdata As String
        Dim i, l, wmaxRows As Integer
        Dim wTask As Task

        wSqlCmd = myConn.CreateCommand()
        wSqlCmd.CommandText = "select ORDINAL_POSITION, DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" & pItem.Text & "' order by ORDINAL_POSITION"
        wSqlDR = wSqlCmd.ExecuteReader()

        i = 0
        wdef.Clear()
        Do While wSqlDR.Read()
            wdef.Add(wSqlDR(1).ToString)
            i = i + 1
        Loop

        wSqlDR.Close()

        wSqlCmd = myConn.CreateCommand()
        wSqlCmd.CommandText = "select count(*) from " & pItem.Text
        wSqlDR = wSqlCmd.ExecuteReader()
        If wSqlDR.Read() Then
            wmaxRows = wSqlDR.GetInt32(0)
        End If
        wSqlDR.Close()

        wSqlCmd = myConn.CreateCommand()
        wSqlCmd.CommandText = "select * from " & pItem.Text
        wSqlDR = wSqlCmd.ExecuteReader()

        l = 0

        wfileName = txtFolder.Text & "\" & txtDataBase.Text & "\" & pItem.Text.ToLower(New Globalization.CultureInfo("en-US", False)) & ".dat"
        tsslblStatus.Text = pItem.Text & " >> " & wfileName

        Try
            FileSystem.Kill(wfileName)
        Catch ex As Exception

        End Try

        Try
            Using writer As New StreamWriter(wfileName, True)
                Do While wSqlDR.Read()
                    wstr = ""
                    For j As Integer = 0 To wSqlDR.FieldCount - 1
                        If IsDBNull(wSqlDR(j)) Then
                            wdata = ""
                        ElseIf wdef(j).ToString Like "date*" Then
                            wdata = wSqlDR.GetDateTime(j).ToString(txtDateFormat.Text)
                        Else
                            wdata = wSqlDR(j).ToString
                        End If
                        wstr = wstr & write_data(wdef(j), wdata)
                    Next
                    l = l + 1
                    writer.WriteLine(wstr.Substring(0, wstr.Length - 1))
                Loop
            End Using
            wSqlDR.Close()

            tsslblStatus.Text = pItem.Text & " >> " & wfileName & " ... " & Format(wmaxRows, "#,####") & " / " & Format(l, "#,###") & " Rows"
            pItem.SubItems(2).Text = "OK"

        Catch ex As Exception
            txtOutput.Text = ex.Message & vbCrLf & txtOutput.Text
        End Try

        Try
            wTask = Task.Run(Sub() SendFile(txtFolder.Text & "\" & txtDataBase.Text, pItem.Text.ToLower(New Globalization.CultureInfo("en-US", False)) & ".dat"))
            wTask.GetAwaiter.OnCompleted(Sub() LoadPostgreSQL(pItem.Text.ToLower(New Globalization.CultureInfo("en-US", False)), txtTargetFolder.Text & "/" & txtDataBase.Text & "/" & pItem.Text.ToLower(New Globalization.CultureInfo("en-US", False)) & ".dat", pItem))
            Application.DoEvents()

            PrintLog("EXPORT " & pItem.Text.ToLower(New Globalization.CultureInfo("en-US", False)) & ".dat >> " & l & " Rows", 1, pItem.Text)
        Catch ex As Exception
            txtOutput.Text = ex.Message & vbCrLf & txtOutput.Text
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim wCounter As Integer
        Dim wPgCnn As NpgsqlConnection
        Dim wPgCmd As NpgsqlCommand

        If lvTables.SelectedItems.Count = 0 Then
            MsgBox("Select any table/s for export")
            Exit Sub
        End If

        wCounter = 0

        tsspgTables.Minimum = 0
        tsspgTables.Maximum = lvTables.SelectedItems.Count
        tsspgTables.Value = 0

        For Each items As ListViewItem In lvTables.SelectedItems
            items.SubItems(2).Text = ""
            items.SubItems(3).Text = ""
            items.SubItems(4).Text = ""
        Next

        For Each witem As ListViewItem In lvTables.SelectedItems
            witem.SubItems(2).Text = "..."
            'wTask = Task.Run(Sub() ExportTable(witem))
            ExportTable(witem)
            witem.EnsureVisible()

            wCounter = wCounter + 1
            tsspgTables.Value = wCounter
            Application.DoEvents()
        Next

        wPgCnn = New NpgsqlConnection
        wPgCnn.ConnectionString = "SERVER=" & txtPGServer.Text & ";DATABASE=" & txtPGDatabase.Text & ";USER ID=" & txtPGUserName.Text & ";PASSWORD=" & txtPGPassword.Text & ";PORT=5432"
        wPgCnn.Open()

        For Each items As ListViewItem In lvScript.Items
            Try
                wPgCmd = New NpgsqlCommand(items.Text, wPgCnn)
                wPgCmd.ExecuteNonQuery()
                PrintLog("Script Execute ... ", 1, items.Text)

                items.SubItems(1).Text = "OK"
            Catch ex As Exception
                PrintLog("Error", 0, ex.Message)
            End Try

        Next

        wPgCnn.Close()

        tsslblStatus.Text = "Task complated successful."

    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(myConn) Then
            If myConn.State = ConnectionState.Open Then
                myConn.Close()
            End If
        End If
    End Sub

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        Dim wCnnPg As NpgsqlConnection
        Dim wItem As ListViewItem

        '******** SQL Server Connection  ******************

        lvTables.Items.Clear()

        If Not IsNothing(myConn) Then
            If myConn.State = ConnectionState.Open Then
                myConn.Close()
            End If
        End If

        Try
            myConn = New SqlConnection("Server=" & txtServer.Text & ";Database=" & txtDataBase.Text & ";User Id=" & txtUserName.Text & ";Password=" & txtPassword.Text & ";MultipleActiveResultSets=True")
            myConn.Open()

            cmdTab = myConn.CreateCommand()
            cmdTab.CommandText = "Select  t.TABLE_NAME, x.RecordCount
from INFORMATION_SCHEMA.TABLES t
left join (SELECT A.Name AS TableName, SUM(B.rows) AS RecordCount
          FROM sys.objects A
          INNER JOIN sys.partitions B ON A.object_id = B.object_id
          WHERE A.type = 'U'
          GROUP BY A.schema_id, A.Name) x on (t.TABLE_NAME=x.TableName)
where t.TABLE_SCHEMA ='dbo' 
and t.TABLE_TYPE ='Base Table' 
Order by x.RecordCount, t.TABLE_NAME"
            wrTab = cmdTab.ExecuteReader()

            Do While wrTab.Read()
                wItem = New ListViewItem(wrTab.GetString(0), 0)
                wItem.SubItems.Add(wrTab.GetInt64(1))
                wItem.SubItems.Add(".")
                wItem.SubItems.Add(".")
                wItem.SubItems.Add(".")

                lvTables.Items.Add(wItem)
            Loop

            PrintLog("SQL Server connection", 1, "SQL_SERVER")
        Catch sqlEx As SqlException
            PrintLog("SQL Server connection error - " & sqlEx.Message, 0, "SQL_SERVER")
        Catch ex As Exception
            PrintLog("SQL Server - " & ex.Message, 0, "SQL_SERVER")
        End Try

        '********** FTP Connection *********
        If chkSFTP.CheckState Then
            Try
                wSftp = New SftpClient(txtSftpHost.Text, txtSftpUserName.Text, txtSftpPassword.Text)
                wSftp.Connect()
                PrintLog("Secure connection", 1, "SFTP")
            Catch ex As Exception
                PrintLog("Secure connection", 0, "SFTP")
            End Try

            Try
                wSftp.ChangeDirectory(txtTargetFolder.Text)
                PrintLog("Target folder OK.", 1, "TARGET_FOLDER")
            Catch ex As Exception
                PrintLog("Target folder does not exist.", 0, "TARGET_FOLDER")
            End Try
        End If

        '***********  PostgreSQL Connection  *********************
        If chkPostgreSQL.CheckState Then
            Try
                wCnnPg = New NpgsqlConnection
                wCnnPg.ConnectionString = "SERVER=" & txtPGServer.Text & ";DATABASE=" & txtPGDatabase.Text & ";USER ID=" & txtPGUserName.Text & ";PASSWORD=" & txtPGPassword.Text & ";PORT=5432"
                wCnnPg.Open()
                wCnnPg.Close()
                PrintLog("PostgreSQL Connection", 1, "POSTGRESQL")
            Catch ex As Exception
                PrintLog("PostgreSQL Connection", 0, "POSTGRESQL")
            End Try
        End If

        If Not Directory.Exists(txtFolder.Text & "\" & txtDataBase.Text) Then
            FileSystem.MkDir(txtFolder.Text & "\" & txtDataBase.Text)
            PrintLog("Output folder created.", 1, "OUTPUT")
        Else
            PrintLog("Output folder OK.", 1, "OUTPUT")
        End If

        tsslblStatus.Text = "Connection Test Ok ... "
    End Sub

    Private Sub btnFolder_Click(sender As Object, e As EventArgs) Handles btnFolder.Click
        If FolderBrowserDialog1.ShowDialog() Then
            txtFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub SendFile(pPath As String, pFile As String)
        If chkSFTP.CheckState Then
            If IsNothing(wSftp) Then
                wSftp = New SftpClient(txtSftpHost.Text, txtSftpUserName.Text, txtSftpPassword.Text)
                wSftp.Connect()
            End If

            If Not wSftp.IsConnected Then
                wSftp = New SftpClient(txtSftpHost.Text, txtSftpUserName.Text, txtSftpPassword.Text)
                wSftp.Connect()
            End If

            Try
                wSftp.ChangeDirectory(txtTargetFolder.Text & "/" & txtDataBase.Text)
            Catch ex As Exception
                Try
                    wSftp.CreateDirectory(txtTargetFolder.Text & "/" & txtDataBase.Text)
                Catch ex2 As Exception
                    MsgBox(ex2.Message)
                End Try
                MsgBox(ex.Message)
            End Try

            Try
                wSftp.DeleteFile(txtTargetFolder.Text & "/" & txtDataBase.Text & "/" & pFile)
            Catch ex As Exception

            End Try
            Try
                Using stream As Stream = File.OpenRead(pPath & "\" & pFile)
                    wSftp.UploadFile(stream, txtTargetFolder.Text & "/" & txtDataBase.Text & "/" & pFile)
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Application.DoEvents()
        End If
    End Sub

    Private Sub LoadPostgreSQL(pTableName As String, pfileName As String, pItem As ListViewItem)
        Dim wSqlCopy As String = ""
        Dim wSqlTruncate As String

        If chkSFTP.CheckState Then
            pItem.SubItems(3).Text = "OK"
            PrintLog("UPLOAD " & pfileName, 1, pTableName)
            Application.DoEvents()
        End If

        If chkPostgreSQL.CheckState Then
            Try
                Using connection As New NpgsqlConnection("SERVER=" & txtPGServer.Text & ";DATABASE=" & txtPGDatabase.Text & ";USER ID=" & txtPGUserName.Text & ";PASSWORD=" & txtPGPassword.Text & ";PORT=5432; Timeout=1000; CommandTimeout=10000")
                    Dim dr As NpgsqlDataReader
                    Dim cmd As New NpgsqlCommand("select 'truncate table '||table_schema||'.'||table_name truncate_sql, " &
                    "'copy '||table_schema||'.'||table_name||' ('||STRING_AGG('""'||column_name||'""', ',' ORDER BY ordinal_position)||') FROM ''" & pfileName & "'' WITH DELIMITER ''~'' CSV ENCODING ''UTF-8'' ' wsql " &
                    "from information_schema.columns c " &
                    "where table_schema = '" & txtDataBase.Text.ToLower(New Globalization.CultureInfo("en-US", False)) & "' " &
                    "and table_name = '" & pTableName & "' " &
                    "group by table_schema, table_name " &
                    "order by 1", connection)

                    cmd.Connection.Open()
                    dr = cmd.ExecuteReader

                    If dr.Read Then
                        wSqlTruncate = dr.GetString(0)
                        wSqlCopy = dr.GetString(1)
                        dr.Close()

                        cmd = New NpgsqlCommand(wSqlTruncate, connection)
                        cmd.ExecuteNonQuery()

                        cmd = New NpgsqlCommand(wSqlCopy, connection)
                        cmd.ExecuteNonQuery()

                        PrintLog("PostgreSQL - " & wSqlCopy, 1, pTableName)
                        pItem.SubItems(4).Text = "OK"
                    Else
                        PrintLog("PostgreSQL " & pTableName & " not found.", 0, pTableName)
                        pItem.SubItems(4).Text = "FAIL"
                    End If
                End Using
            Catch ex As Exception
                PrintLog("PostgreSQL - " & wSqlCopy & vbCrLf & ex.Message, 0, pTableName)
                pItem.SubItems(4).Text = "FAIL"
            End Try
            Application.DoEvents()
        End If
    End Sub

    Private Sub lvTables_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvTables.ColumnClick
        lvTables.Columns.Item(e.Column).ListView.Sorting = IIf(lvTables.Columns.Item(e.Column).ListView.Sorting = Windows.Forms.SortOrder.Ascending,
                                                               Windows.Forms.SortOrder.Descending,
                                                               Windows.Forms.SortOrder.Ascending)

    End Sub

    Private Sub PrintLog(pTopic As String, pStatus As Integer, pTableName As String)
        tabControl.SelectedTab = tpOuput
        If pTopic Like "Create*" Then
            txtOutput.Text = pTableName & vbCrLf & txtOutput.Text
        Else
            txtOutput.Text = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") & " - " & IIf(pStatus = 1, "SUCCESS", "FAIL") & " - " & pTableName & " - " & pTopic & vbCrLf & txtOutput.Text
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub CreateTable(pTableName As String, pScript As String, PPgCnn As NpgsqlConnection)
        Dim wPgCmd As NpgsqlCommand

        wPgCmd = New NpgsqlCommand("CREATE SCHEMA IF NOT EXISTS " & txtDataBase.Text, PPgCnn)
        wPgCmd.ExecuteNonQuery()

        wPgCmd = New NpgsqlCommand("DROP TABLE IF EXISTS " & txtDataBase.Text & "." & pTableName, PPgCnn)
        wPgCmd.ExecuteNonQuery()

        wPgCmd = New NpgsqlCommand(pScript, PPgCnn)
        wPgCmd.ExecuteNonQuery()
        PrintLog("Create Table", 1, pScript)
    End Sub

    Private Sub CreateConstraint(pTableName As String, pScript As String, PPgCnn As NpgsqlConnection, pIsExecute As Boolean)
        Dim wPgCmd As NpgsqlCommand
        If pIsExecute Then
            wPgCmd = New NpgsqlCommand(pScript, PPgCnn)
            wPgCmd.ExecuteNonQuery()
        End If

        PrintLog("Create Table Constraint", 1, pScript)
    End Sub

    Private Sub cmdCreateTable_Click(sender As Object, e As EventArgs) Handles cmdCreateTable.Click
        Dim wSqlCmd As SqlCommand
        Dim wSqlDR As SqlDataReader
        Dim wPgCnn As NpgsqlConnection
        Dim wSqlCreateConstraint As String = ""
        Dim wTableName As String = ""
        Dim wCreateScript As String = ""
        Dim wTables As String = ""
        Dim wCounter As Integer = 0
        Dim wCreateConstraint As Boolean = False

        If lvTables.SelectedItems.Count = 0 Then
            MsgBox("Select any table/s for create")
            Exit Sub
        End If

        wPgCnn = New NpgsqlConnection
        wPgCnn.ConnectionString = "SERVER=" & txtPGServer.Text & ";DATABASE=" & txtPGDatabase.Text & ";USER ID=" & txtPGUserName.Text & ";PASSWORD=" & txtPGPassword.Text & ";PORT=5432"
        wPgCnn.Open()

        For Each witem As ListViewItem In lvTables.SelectedItems
            wtables = wtables & "','" & witem.Text
        Next
        wtables = wtables.Substring(2) & "'"

        Try
            wSqlCmd = myConn.CreateCommand()
            wSqlCmd.CommandText = "select  TABLE_NAME, case when Lower(COLUMN_NAME)='not' then '""not""' else COLUMN_NAME end + ' ' + DATA_TYPE +' ' + case when DATA_TYPE in ('varchar','char', 'decimal','numeric') then data_size else '' end + ' ' + case when IS_NULLABLE='NO' then 'not null' else '' end COLUMN_DEF
      from (select TABLE_NAME, ORDINAL_POSITION, replace(COLUMN_NAME,' ','_') COLUMN_NAME, IS_NULLABLE, 
              case when DATA_TYPE in ('nvarchar','uniqueidentifier','varchar') then case when CHARACTER_MAXIMUM_LENGTH>2000 or CHARACTER_MAXIMUM_LENGTH=-1 then 'text' else 'varchar' end
                   when DATA_TYPE in ('bit','tinyint') then 'smallint'
                   when DATA_TYPE in ('datetime2', 'datetime', 'date','smalldatetime') then 'timestamp'
                   when DATA_TYPE in ('binary','varbinary','image','rowversion') then 'bytea'
                   when DATA_TYPE in ('ntext', 'sql_variant') then 'text'
                   when DATA_TYPE in ('nchar') then 'char'
                   when DATA_TYPE in ('smallmoney') then 'money'
                   else DATA_TYPE 
              end DATA_TYPE,
              '(' + convert(varchar, coalesce(COALESCE (case when CHARACTER_MAXIMUM_LENGTH=-1 then 4000 else CHARACTER_MAXIMUM_LENGTH end, NUMERIC_PRECISION),100)) + case when NUMERIC_SCALE is not null then ',' + convert(varchar, NUMERIC_SCALE) + ')' else ')' end data_size
            from INFORMATION_SCHEMA.COLUMNS 
            where TABLE_NAME in (" & wtables & ")
      ) x 
order by TABLE_NAME, ORDINAL_POSITION"
            wSqlDR = wSqlCmd.ExecuteReader()

            tsspgTables.Minimum = 0
            tsspgTables.Maximum = lvTables.SelectedItems.Count
            tsspgTables.Value = 0

            Do While wSqlDR.Read()
                If wTableName = "" Then
                    wCreateScript = "create table " & txtDataBase.Text & "." & wSqlDR.GetString(0) & " (" & vbCrLf
                ElseIf wTableName <> wSqlDR.GetString(0) Then
                    CreateTable(wTableName, wCreateScript.Substring(0, wCreateScript.Length - 3) & ");", wPgCnn)

                    wCounter = wCounter + 1
                    tsspgTables.Value = wCounter
                    tsslblStatus.Text = wTableName & " Table created ..."
                    Application.DoEvents()

                    wCreateScript = "create table " & txtDataBase.Text & "." & wSqlDR.GetString(0) & " (" & vbCrLf
                End If

                wCreateScript = wCreateScript & vbTab & wSqlDR.GetString(1) & "," & vbCrLf
                wTableName = wSqlDR.GetString(0)

            Loop

            CreateTable(wTableName, wCreateScript.Substring(0, wCreateScript.Length - 3) & ");", wPgCnn)

            wCounter = wCounter + 1
            tsspgTables.Value = wCounter

            PrintLog("-- Create Table" & vbCrLf, 1, wCounter & " tables was created")

            wSqlDR.Close()

            '**************************************
            'Create table constraints
            '**************************************

            If MsgBox("Is create Primary Key constraints?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                wCreateConstraint = True
            End If


            wSqlCmd = myConn.CreateCommand()
            wSqlCmd.CommandText = "select tc.TABLE_NAME, tc.CONSTRAINT_NAME, CONSTRAINT_TYPE, replace(ccu.COLUMN_NAME,' ','_') COLUMN_NAME
from INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc 
join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu on (tc.CONSTRAINT_NAME=ccu.CONSTRAINT_NAME and tc.TABLE_NAME=ccu.TABLE_NAME and tc.TABLE_SCHEMA=ccu.TABLE_SCHEMA)
where CONSTRAINT_TYPE in ('PRIMARY KEY', 'UNIQUE')
and tc.TABLE_NAME in (" & wTables & ")
order by tc.TABLE_NAME, tc.CONSTRAINT_NAME"

            wSqlDR = wSqlCmd.ExecuteReader()

            tsspgTables.Value = 0
            wCreateScript = ""
            wTableName = ""
            wCounter = 0

            Do While wSqlDR.Read()
                If wTableName = "" Then
                    wCreateScript = "alter table " & txtDataBase.Text & "." & wSqlDR.GetString(0) & " add constraint " & wSqlDR.GetString(1) & " " & wSqlDR.GetString(2) & " ("
                ElseIf wTableName <> wSqlDR.GetString(0) Then
                    CreateConstraint(wTableName, wCreateScript.Substring(0, wCreateScript.Length - 1) & ");", wPgCnn, wCreateConstraint)

                    wCounter = wCounter + 1
                    tsspgTables.Value = wCounter
                    tsslblStatus.Text = wTableName & " Table constraint created ..."
                    Application.DoEvents()

                    wCreateScript = "alter table " & txtDataBase.Text & "." & wSqlDR.GetString(0) & " add constraint " & wSqlDR.GetString(1) & " " & wSqlDR.GetString(2) & " ("
                End If

                wCreateScript = wCreateScript & wSqlDR.GetString(3) & ","
                wTableName = wSqlDR.GetString(0)

            Loop

            CreateConstraint(wTableName, wCreateScript.Substring(0, wCreateScript.Length - 1) & ");", wPgCnn, wCreateConstraint)

            wCounter = wCounter + 1
            tsspgTables.Value = tsspgTables.Maximum

            PrintLog("-- Create Table Constraint" & vbCrLf, 1, wCounter & " tables constraint was " & IIf(wCreateConstraint, "created", "prepared"))
            wSqlDR.Close()

            tsslblStatus.Text = tsspgTables.Value & " Table/s created ..."
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkPostgreSQL_CheckedChanged(sender As Object, e As EventArgs) Handles chkPostgreSQL.CheckedChanged
        txtPGDatabase.Enabled = chkPostgreSQL.CheckState
        txtPGPassword.Enabled = chkPostgreSQL.CheckState
        txtPGServer.Enabled = chkPostgreSQL.CheckState
        txtPGUserName.Enabled = chkPostgreSQL.CheckState
    End Sub

    Private Sub chkSFTP_CheckedChanged(sender As Object, e As EventArgs) Handles chkSFTP.CheckedChanged
        txtSftpHost.Enabled = chkSFTP.CheckState
        txtSftpPassword.Enabled = chkSFTP.CheckState
        txtSftpUserName.Enabled = chkSFTP.CheckState
        txtTargetFolder.Enabled = chkSFTP.CheckState
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.Width < 1300 Then
            Me.Width = 1300
        End If
        If Me.Height < 530 Then
            Me.Height = 530
        End If

        tabControl.Width = Me.Width - tabControl.Left - 25
        tabControl.Height = Me.Height - tabControl.Top - 70
        txtOutput.Width = tabControl.Width - 20
        txtOutput.Height = tabControl.Height - 40
        btnExport.Top = Me.Height - 95
        cmdCreateTable.Top = btnExport.Top
        lvTables.Height = Me.Height - 110
    End Sub

    Private Sub AddScript()
        Dim wItem As ListViewItem
        If txtScript.Text <> "" Then
            For Each wScript In txtScript.Text.Split(";")
                If Trim(wScript) <> "" Then
                    wItem = New ListViewItem
                    wItem.Text = wScript
                    wItem.SubItems.Add("")
                    lvScript.Items.Add(wItem)
                End If
            Next
            txtScript.Select()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddScript()
    End Sub

    Private Sub lvScript_KeyDown(sender As Object, e As KeyEventArgs) Handles lvScript.KeyDown
        If e.KeyCode = Keys.Delete Then
            For Each item In lvScript.SelectedItems
                lvScript.Items.Remove(item)
            Next
        End If
    End Sub

    Private Sub txtScript_TextChanged(sender As Object, e As EventArgs) Handles txtScript.TextChanged

    End Sub

    Private Sub txtScript_KeyDown(sender As Object, e As KeyEventArgs) Handles txtScript.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddScript()
        End If
    End Sub
End Class
