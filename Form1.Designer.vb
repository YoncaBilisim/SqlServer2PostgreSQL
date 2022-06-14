<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdConnect = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDataBase = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFolder = New System.Windows.Forms.Button()
        Me.txtFolder = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDateFormat = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDelimeter = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTargetFolder = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSftpPassword = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSftpUserName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSftpHost = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPGPassword = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPGUserName = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPGDatabase = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPGServer = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkPostgreSQL = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkSFTP = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsspgTables = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsslblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lvTables = New System.Windows.Forms.ListView()
        Me.colTableName = New System.Windows.Forms.ColumnHeader()
        Me.colRecordCount = New System.Windows.Forms.ColumnHeader()
        Me.colExport = New System.Windows.Forms.ColumnHeader()
        Me.colSftp = New System.Windows.Forms.ColumnHeader()
        Me.colPGCopy = New System.Windows.Forms.ColumnHeader()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tpSettings = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lvScript = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader()
        Me.txtScript = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tpOuput = New System.Windows.Forms.TabPage()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.cmdCreateTable = New System.Windows.Forms.Button()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.tpSettings.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tpOuput.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(6, 6)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutput.Size = New System.Drawing.Size(754, 406)
        Me.txtOutput.TabIndex = 15
        '
        'cmdConnect
        '
        Me.cmdConnect.Location = New System.Drawing.Point(234, 311)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(282, 23)
        Me.cmdConnect.TabIndex = 22
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(80, 113)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 23)
        Me.txtPassword.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Password"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(80, 84)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(100, 23)
        Me.txtUserName.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "User Name"
        '
        'txtDataBase
        '
        Me.txtDataBase.Location = New System.Drawing.Point(80, 55)
        Me.txtDataBase.Name = "txtDataBase"
        Me.txtDataBase.Size = New System.Drawing.Size(100, 23)
        Me.txtDataBase.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "DataBase"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(80, 26)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(100, 23)
        Me.txtServer.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Server"
        '
        'btnFolder
        '
        Me.btnFolder.Location = New System.Drawing.Point(245, 82)
        Me.btnFolder.Name = "btnFolder"
        Me.btnFolder.Size = New System.Drawing.Size(27, 23)
        Me.btnFolder.TabIndex = 30
        Me.btnFolder.Text = "..."
        Me.btnFolder.UseVisualStyleBackColor = True
        '
        'txtFolder
        '
        Me.txtFolder.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtFolder.Enabled = False
        Me.txtFolder.Location = New System.Drawing.Point(94, 82)
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.Size = New System.Drawing.Size(145, 23)
        Me.txtFolder.TabIndex = 29
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 15)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Output Folder"
        '
        'txtDateFormat
        '
        Me.txtDateFormat.Location = New System.Drawing.Point(94, 54)
        Me.txtDateFormat.Name = "txtDateFormat"
        Me.txtDateFormat.Size = New System.Drawing.Size(145, 23)
        Me.txtDateFormat.TabIndex = 27
        Me.txtDateFormat.Text = "yyyy-MM-dd HH:mm:ss"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Date Format"
        '
        'txtDelimeter
        '
        Me.txtDelimeter.Location = New System.Drawing.Point(94, 25)
        Me.txtDelimeter.MaxLength = 1
        Me.txtDelimeter.Name = "txtDelimeter"
        Me.txtDelimeter.Size = New System.Drawing.Size(22, 23)
        Me.txtDelimeter.TabIndex = 25
        Me.txtDelimeter.Text = "~"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 15)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Delimeter"
        '
        'txtTargetFolder
        '
        Me.txtTargetFolder.Location = New System.Drawing.Point(86, 112)
        Me.txtTargetFolder.Name = "txtTargetFolder"
        Me.txtTargetFolder.Size = New System.Drawing.Size(186, 23)
        Me.txtTargetFolder.TabIndex = 30
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 115)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 15)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Target Folder"
        '
        'txtSftpPassword
        '
        Me.txtSftpPassword.Location = New System.Drawing.Point(86, 83)
        Me.txtSftpPassword.Name = "txtSftpPassword"
        Me.txtSftpPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSftpPassword.Size = New System.Drawing.Size(100, 23)
        Me.txtSftpPassword.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 15)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Password"
        '
        'txtSftpUserName
        '
        Me.txtSftpUserName.Location = New System.Drawing.Point(86, 54)
        Me.txtSftpUserName.Name = "txtSftpUserName"
        Me.txtSftpUserName.Size = New System.Drawing.Size(100, 23)
        Me.txtSftpUserName.TabIndex = 25
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 15)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "User Name"
        '
        'txtSftpHost
        '
        Me.txtSftpHost.Location = New System.Drawing.Point(86, 26)
        Me.txtSftpHost.Name = "txtSftpHost"
        Me.txtSftpHost.Size = New System.Drawing.Size(100, 23)
        Me.txtSftpHost.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(41, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 15)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Server"
        '
        'txtPGPassword
        '
        Me.txtPGPassword.Location = New System.Drawing.Point(80, 113)
        Me.txtPGPassword.Name = "txtPGPassword"
        Me.txtPGPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPGPassword.Size = New System.Drawing.Size(100, 23)
        Me.txtPGPassword.TabIndex = 30
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 116)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 15)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Password"
        '
        'txtPGUserName
        '
        Me.txtPGUserName.Location = New System.Drawing.Point(80, 84)
        Me.txtPGUserName.Name = "txtPGUserName"
        Me.txtPGUserName.Size = New System.Drawing.Size(100, 23)
        Me.txtPGUserName.TabIndex = 28
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 87)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 15)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "User Name"
        '
        'txtPGDatabase
        '
        Me.txtPGDatabase.Location = New System.Drawing.Point(80, 55)
        Me.txtPGDatabase.Name = "txtPGDatabase"
        Me.txtPGDatabase.Size = New System.Drawing.Size(100, 23)
        Me.txtPGDatabase.TabIndex = 26
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(19, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 15)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "DataBase"
        '
        'txtPGServer
        '
        Me.txtPGServer.Location = New System.Drawing.Point(80, 26)
        Me.txtPGServer.Name = "txtPGServer"
        Me.txtPGServer.Size = New System.Drawing.Size(100, 23)
        Me.txtPGServer.TabIndex = 24
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(35, 29)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 15)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Server"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataBase)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtServer)
        Me.GroupBox1.Controls.Add(Me.txtUserName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(195, 152)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SQL Server Settings"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkPostgreSQL)
        Me.GroupBox2.Controls.Add(Me.txtPGServer)
        Me.GroupBox2.Controls.Add(Me.txtPGPassword)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtPGUserName)
        Me.GroupBox2.Controls.Add(Me.txtPGDatabase)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 182)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(194, 152)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PostgreSQL Settings"
        '
        'chkPostgreSQL
        '
        Me.chkPostgreSQL.AutoSize = True
        Me.chkPostgreSQL.Checked = True
        Me.chkPostgreSQL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPostgreSQL.Location = New System.Drawing.Point(166, 3)
        Me.chkPostgreSQL.Name = "chkPostgreSQL"
        Me.chkPostgreSQL.Size = New System.Drawing.Size(15, 14)
        Me.chkPostgreSQL.TabIndex = 31
        Me.chkPostgreSQL.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkSFTP)
        Me.GroupBox3.Controls.Add(Me.txtTargetFolder)
        Me.GroupBox3.Controls.Add(Me.txtSftpUserName)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtSftpHost)
        Me.GroupBox3.Controls.Add(Me.txtSftpPassword)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(234, 14)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(282, 152)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "SFTP Settings"
        '
        'chkSFTP
        '
        Me.chkSFTP.AutoSize = True
        Me.chkSFTP.Checked = True
        Me.chkSFTP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSFTP.Location = New System.Drawing.Point(257, 3)
        Me.chkSFTP.Name = "chkSFTP"
        Me.chkSFTP.Size = New System.Drawing.Size(15, 14)
        Me.chkSFTP.TabIndex = 31
        Me.chkSFTP.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnFolder)
        Me.GroupBox4.Controls.Add(Me.txtDateFormat)
        Me.GroupBox4.Controls.Add(Me.txtFolder)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtDelimeter)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Location = New System.Drawing.Point(234, 182)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(282, 119)
        Me.GroupBox4.TabIndex = 29
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Export Settings"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsspgTables, Me.tsslblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 568)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1287, 22)
        Me.StatusStrip1.TabIndex = 34
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsspgTables
        '
        Me.tsspgTables.Name = "tsspgTables"
        Me.tsspgTables.Size = New System.Drawing.Size(200, 16)
        '
        'tsslblStatus
        '
        Me.tsslblStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslblStatus.Name = "tsslblStatus"
        Me.tsslblStatus.Size = New System.Drawing.Size(39, 17)
        Me.tsslblStatus.Text = "Status"
        '
        'lvTables
        '
        Me.lvTables.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTableName, Me.colRecordCount, Me.colExport, Me.colSftp, Me.colPGCopy})
        Me.lvTables.FullRowSelect = True
        Me.lvTables.GridLines = True
        Me.lvTables.HideSelection = False
        Me.lvTables.Location = New System.Drawing.Point(12, 12)
        Me.lvTables.Name = "lvTables"
        Me.lvTables.Size = New System.Drawing.Size(491, 417)
        Me.lvTables.TabIndex = 35
        Me.lvTables.UseCompatibleStateImageBehavior = False
        Me.lvTables.View = System.Windows.Forms.View.Details
        '
        'colTableName
        '
        Me.colTableName.Text = "Table Name"
        Me.colTableName.Width = 230
        '
        'colRecordCount
        '
        Me.colRecordCount.Text = "Record Count"
        Me.colRecordCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colRecordCount.Width = 90
        '
        'colExport
        '
        Me.colExport.Tag = "Export"
        Me.colExport.Text = "Export"
        Me.colExport.Width = 50
        '
        'colSftp
        '
        Me.colSftp.Tag = "SFTP"
        Me.colSftp.Text = "SFTP"
        Me.colSftp.Width = 40
        '
        'colPGCopy
        '
        Me.colPGCopy.Tag = "PostgreSQL Copy"
        Me.colPGCopy.Text = "Copy"
        Me.colPGCopy.Width = 40
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tpSettings)
        Me.tabControl.Controls.Add(Me.tpOuput)
        Me.tabControl.Location = New System.Drawing.Point(509, 12)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(774, 542)
        Me.tabControl.TabIndex = 36
        '
        'tpSettings
        '
        Me.tpSettings.Controls.Add(Me.GroupBox5)
        Me.tpSettings.Controls.Add(Me.GroupBox3)
        Me.tpSettings.Controls.Add(Me.cmdConnect)
        Me.tpSettings.Controls.Add(Me.GroupBox4)
        Me.tpSettings.Controls.Add(Me.GroupBox2)
        Me.tpSettings.Controls.Add(Me.GroupBox1)
        Me.tpSettings.Location = New System.Drawing.Point(4, 24)
        Me.tpSettings.Name = "tpSettings"
        Me.tpSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSettings.Size = New System.Drawing.Size(766, 514)
        Me.tpSettings.TabIndex = 0
        Me.tpSettings.Text = "Settings"
        Me.tpSettings.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnAdd)
        Me.GroupBox5.Controls.Add(Me.lvScript)
        Me.GroupBox5.Controls.Add(Me.txtScript)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Location = New System.Drawing.Point(16, 346)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(500, 162)
        Me.GroupBox5.TabIndex = 32
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Post Execute"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(465, 21)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(27, 23)
        Me.btnAdd.TabIndex = 31
        Me.btnAdd.Text = "+"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lvScript
        '
        Me.lvScript.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvScript.FullRowSelect = True
        Me.lvScript.GridLines = True
        Me.lvScript.HideSelection = False
        Me.lvScript.Location = New System.Drawing.Point(7, 55)
        Me.lvScript.Name = "lvScript"
        Me.lvScript.Size = New System.Drawing.Size(484, 101)
        Me.lvScript.TabIndex = 39
        Me.lvScript.UseCompatibleStateImageBehavior = False
        Me.lvScript.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Script"
        Me.ColumnHeader1.Width = 350
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Status"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 90
        '
        'txtScript
        '
        Me.txtScript.Location = New System.Drawing.Point(51, 15)
        Me.txtScript.Multiline = True
        Me.txtScript.Name = "txtScript"
        Me.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtScript.Size = New System.Drawing.Size(408, 34)
        Me.txtScript.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Script"
        '
        'tpOuput
        '
        Me.tpOuput.Controls.Add(Me.txtOutput)
        Me.tpOuput.Location = New System.Drawing.Point(4, 24)
        Me.tpOuput.Name = "tpOuput"
        Me.tpOuput.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOuput.Size = New System.Drawing.Size(766, 514)
        Me.tpOuput.TabIndex = 1
        Me.tpOuput.Text = "Output"
        Me.tpOuput.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(258, 435)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(245, 23)
        Me.btnExport.TabIndex = 37
        Me.btnExport.Text = "Start Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'cmdCreateTable
        '
        Me.cmdCreateTable.Location = New System.Drawing.Point(12, 435)
        Me.cmdCreateTable.Name = "cmdCreateTable"
        Me.cmdCreateTable.Size = New System.Drawing.Size(245, 23)
        Me.cmdCreateTable.TabIndex = 38
        Me.cmdCreateTable.Text = "Create Table"
        Me.cmdCreateTable.UseVisualStyleBackColor = True
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "D:\Projeler\KASKI\Aktarim\format_dosyasi_hazirla\Help\SQL Server to PostgreSQL Da" &
    "ta Transfer Documentation.htm"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1287, 590)
        Me.Controls.Add(Me.cmdCreateTable)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.lvTables)
        Me.Controls.Add(Me.StatusStrip1)
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "SQL Server to PostgreSQL Data Transfer Documentation.htm")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "SQL Server to PostgreSQL"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tabControl.ResumeLayout(False)
        Me.tpSettings.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tpOuput.ResumeLayout(False)
        Me.tpOuput.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents cmdConnect As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDataBase As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtServer As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnFolder As Button
    Friend WithEvents txtFolder As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDateFormat As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDelimeter As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSftpPassword As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtSftpUserName As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtSftpHost As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTargetFolder As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtPGPassword As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtPGUserName As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtPGDatabase As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtPGServer As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsspgTables As ToolStripProgressBar
    Friend WithEvents tsslblStatus As ToolStripStatusLabel
    Friend WithEvents lvTables As ListView
    Friend WithEvents colTableName As ColumnHeader
    Friend WithEvents colExport As ColumnHeader
    Friend WithEvents colSftp As ColumnHeader
    Friend WithEvents colPGCopy As ColumnHeader
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tpSettings As TabPage
    Friend WithEvents tpOuput As TabPage
    Friend WithEvents btnExport As Button
    Friend WithEvents colRecordCount As ColumnHeader
    Friend WithEvents cmdCreateTable As Button
    Friend WithEvents chkPostgreSQL As CheckBox
    Friend WithEvents chkSFTP As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents lvScript As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents txtScript As TextBox
    Friend WithEvents Label5 As Label
    Private WithEvents HelpProvider1 As HelpProvider
End Class
