namespace SwissTransport.UI
{
    partial class SwissTransportMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btExportXml = new System.Windows.Forms.Button();
            this.btSendMail = new System.Windows.Forms.Button();
            this.pbConnectionSearch = new System.Windows.Forms.ProgressBar();
            this.btSearchConnections = new System.Windows.Forms.Button();
            this.gbExtendedOptions = new System.Windows.Forms.GroupBox();
            this.dtpConnectionSearchTime = new System.Windows.Forms.DateTimePicker();
            this.rbArrivalTime = new System.Windows.Forms.RadioButton();
            this.rbDepartureTime = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpConnectionSearchDate = new System.Windows.Forms.DateTimePicker();
            this.cbShowExtendedOptions = new System.Windows.Forms.CheckBox();
            this.lvConnections = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbArrival = new System.Windows.Forms.ComboBox();
            this.cbDeparture = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbMoreStationOptions = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpStationBoardDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpStationBoardTime = new System.Windows.Forms.DateTimePicker();
            this.cbMoreStationBoardOptions = new System.Windows.Forms.CheckBox();
            this.lvStationBoard = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btSearchStationBoard = new System.Windows.Forms.Button();
            this.pbStationBoard = new System.Windows.Forms.ProgressBar();
            this.cbSearchStationBoard = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbSearchStation = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wbStations = new System.Windows.Forms.WebBrowser();
            this.tbStationLatitude = new System.Windows.Forms.TextBox();
            this.tbStationLongitude = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lvStations = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btStationSearch = new System.Windows.Forms.Button();
            this.pbStationSearch = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbExtendedOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbMoreStationOptions.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1386, 808);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btExportXml);
            this.tabPage2.Controls.Add(this.btSendMail);
            this.tabPage2.Controls.Add(this.pbConnectionSearch);
            this.tabPage2.Controls.Add(this.btSearchConnections);
            this.tabPage2.Controls.Add(this.gbExtendedOptions);
            this.tabPage2.Controls.Add(this.cbShowExtendedOptions);
            this.tabPage2.Controls.Add(this.lvConnections);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1370, 761);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Verbindungen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btExportXml
            // 
            this.btExportXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExportXml.Location = new System.Drawing.Point(211, 705);
            this.btExportXml.Name = "btExportXml";
            this.btExportXml.Size = new System.Drawing.Size(202, 50);
            this.btExportXml.TabIndex = 7;
            this.btExportXml.Text = "XML Export";
            this.btExportXml.UseVisualStyleBackColor = true;
            // 
            // btSendMail
            // 
            this.btSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSendMail.Location = new System.Drawing.Point(6, 705);
            this.btSendMail.Name = "btSendMail";
            this.btSendMail.Size = new System.Drawing.Size(199, 50);
            this.btSendMail.TabIndex = 6;
            this.btSendMail.Text = "Mail senden";
            this.btSendMail.UseVisualStyleBackColor = true;
            // 
            // pbConnectionSearch
            // 
            this.pbConnectionSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbConnectionSearch.Location = new System.Drawing.Point(6, 649);
            this.pbConnectionSearch.MarqueeAnimationSpeed = 500;
            this.pbConnectionSearch.Name = "pbConnectionSearch";
            this.pbConnectionSearch.Size = new System.Drawing.Size(407, 50);
            this.pbConnectionSearch.TabIndex = 5;
            // 
            // btSearchConnections
            // 
            this.btSearchConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSearchConnections.Enabled = false;
            this.btSearchConnections.Location = new System.Drawing.Point(6, 593);
            this.btSearchConnections.Name = "btSearchConnections";
            this.btSearchConnections.Size = new System.Drawing.Size(407, 50);
            this.btSearchConnections.TabIndex = 4;
            this.btSearchConnections.Text = "Verbindungen suchen";
            this.btSearchConnections.UseVisualStyleBackColor = true;
            this.btSearchConnections.Click += new System.EventHandler(this.SearchConnections_Click);
            // 
            // gbExtendedOptions
            // 
            this.gbExtendedOptions.Controls.Add(this.dtpConnectionSearchTime);
            this.gbExtendedOptions.Controls.Add(this.rbArrivalTime);
            this.gbExtendedOptions.Controls.Add(this.rbDepartureTime);
            this.gbExtendedOptions.Controls.Add(this.label5);
            this.gbExtendedOptions.Controls.Add(this.label4);
            this.gbExtendedOptions.Controls.Add(this.label3);
            this.gbExtendedOptions.Controls.Add(this.dtpConnectionSearchDate);
            this.gbExtendedOptions.Location = new System.Drawing.Point(6, 235);
            this.gbExtendedOptions.Name = "gbExtendedOptions";
            this.gbExtendedOptions.Size = new System.Drawing.Size(407, 333);
            this.gbExtendedOptions.TabIndex = 3;
            this.gbExtendedOptions.TabStop = false;
            this.gbExtendedOptions.Text = "Detail-Einstellungen";
            this.gbExtendedOptions.Visible = false;
            // 
            // dtpConnectionSearchTime
            // 
            this.dtpConnectionSearchTime.CustomFormat = "HH:mm";
            this.dtpConnectionSearchTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpConnectionSearchTime.Location = new System.Drawing.Point(11, 191);
            this.dtpConnectionSearchTime.Name = "dtpConnectionSearchTime";
            this.dtpConnectionSearchTime.ShowUpDown = true;
            this.dtpConnectionSearchTime.Size = new System.Drawing.Size(374, 31);
            this.dtpConnectionSearchTime.TabIndex = 7;
            // 
            // rbArrivalTime
            // 
            this.rbArrivalTime.AutoSize = true;
            this.rbArrivalTime.Location = new System.Drawing.Point(198, 280);
            this.rbArrivalTime.Name = "rbArrivalTime";
            this.rbArrivalTime.Size = new System.Drawing.Size(161, 29);
            this.rbArrivalTime.TabIndex = 6;
            this.rbArrivalTime.TabStop = true;
            this.rbArrivalTime.Text = "Ankunftszeit";
            this.rbArrivalTime.UseVisualStyleBackColor = true;
            // 
            // rbDepartureTime
            // 
            this.rbDepartureTime.AutoSize = true;
            this.rbDepartureTime.Checked = true;
            this.rbDepartureTime.Location = new System.Drawing.Point(11, 280);
            this.rbDepartureTime.Name = "rbDepartureTime";
            this.rbDepartureTime.Size = new System.Drawing.Size(157, 29);
            this.rbDepartureTime.TabIndex = 5;
            this.rbDepartureTime.TabStop = true;
            this.rbDepartureTime.Text = "Abfahrtszeit";
            this.rbDepartureTime.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Typ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Zeit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Datum";
            // 
            // dtpConnectionSearchDate
            // 
            this.dtpConnectionSearchDate.Location = new System.Drawing.Point(11, 92);
            this.dtpConnectionSearchDate.Name = "dtpConnectionSearchDate";
            this.dtpConnectionSearchDate.Size = new System.Drawing.Size(374, 31);
            this.dtpConnectionSearchDate.TabIndex = 0;
            // 
            // cbShowExtendedOptions
            // 
            this.cbShowExtendedOptions.AutoSize = true;
            this.cbShowExtendedOptions.Location = new System.Drawing.Point(6, 191);
            this.cbShowExtendedOptions.Name = "cbShowExtendedOptions";
            this.cbShowExtendedOptions.Size = new System.Drawing.Size(280, 29);
            this.cbShowExtendedOptions.TabIndex = 2;
            this.cbShowExtendedOptions.Text = "Mehr Optionen anzeigen";
            this.cbShowExtendedOptions.UseVisualStyleBackColor = true;
            this.cbShowExtendedOptions.CheckedChanged += new System.EventHandler(this.ShowExtendedOptions_CheckedChanged);
            // 
            // lvConnections
            // 
            this.lvConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader13});
            this.lvConnections.FullRowSelect = true;
            this.lvConnections.GridLines = true;
            this.lvConnections.HoverSelection = true;
            this.lvConnections.Location = new System.Drawing.Point(419, 6);
            this.lvConnections.Name = "lvConnections";
            this.lvConnections.Size = new System.Drawing.Size(945, 749);
            this.lvConnections.TabIndex = 1;
            this.lvConnections.UseCompatibleStateImageBehavior = false;
            this.lvConnections.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Verkehrsmittel";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ab";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "An";
            this.columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Dauer";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Abfahrts-Plattform";
            this.columnHeader5.Width = 140;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Ankunfts-Plattform";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbArrival);
            this.groupBox1.Controls.Add(this.cbDeparture);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informationen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nach";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Von";
            // 
            // cbArrival
            // 
            this.cbArrival.FormattingEnabled = true;
            this.cbArrival.Location = new System.Drawing.Point(116, 97);
            this.cbArrival.Name = "cbArrival";
            this.cbArrival.Size = new System.Drawing.Size(269, 33);
            this.cbArrival.TabIndex = 1;
            this.cbArrival.DropDown += new System.EventHandler(this.LoadStationCombobox);
            this.cbArrival.SelectedIndexChanged += new System.EventHandler(this.ConnectionButtonValidation);
            this.cbArrival.Leave += new System.EventHandler(this.ConnectionButtonValidation);
            // 
            // cbDeparture
            // 
            this.cbDeparture.FormattingEnabled = true;
            this.cbDeparture.Location = new System.Drawing.Point(116, 44);
            this.cbDeparture.Name = "cbDeparture";
            this.cbDeparture.Size = new System.Drawing.Size(269, 33);
            this.cbDeparture.TabIndex = 0;
            this.cbDeparture.DropDown += new System.EventHandler(this.LoadStationCombobox);
            this.cbDeparture.SelectedIndexChanged += new System.EventHandler(this.ConnectionButtonValidation);
            this.cbDeparture.Leave += new System.EventHandler(this.ConnectionButtonValidation);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbMoreStationOptions);
            this.tabPage1.Controls.Add(this.cbMoreStationBoardOptions);
            this.tabPage1.Controls.Add(this.lvStationBoard);
            this.tabPage1.Controls.Add(this.btSearchStationBoard);
            this.tabPage1.Controls.Add(this.pbStationBoard);
            this.tabPage1.Controls.Add(this.cbSearchStationBoard);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1370, 761);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Abfahrtstafel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbMoreStationOptions
            // 
            this.gbMoreStationOptions.Controls.Add(this.label7);
            this.gbMoreStationOptions.Controls.Add(this.dtpStationBoardDate);
            this.gbMoreStationOptions.Controls.Add(this.label11);
            this.gbMoreStationOptions.Controls.Add(this.dtpStationBoardTime);
            this.gbMoreStationOptions.Location = new System.Drawing.Point(17, 139);
            this.gbMoreStationOptions.Name = "gbMoreStationOptions";
            this.gbMoreStationOptions.Size = new System.Drawing.Size(406, 219);
            this.gbMoreStationOptions.TabIndex = 12;
            this.gbMoreStationOptions.TabStop = false;
            this.gbMoreStationOptions.Text = "Mehr Optionen";
            this.gbMoreStationOptions.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Datum";
            // 
            // dtpStationBoardDate
            // 
            this.dtpStationBoardDate.Location = new System.Drawing.Point(21, 72);
            this.dtpStationBoardDate.Name = "dtpStationBoardDate";
            this.dtpStationBoardDate.Size = new System.Drawing.Size(367, 31);
            this.dtpStationBoardDate.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 25);
            this.label11.TabIndex = 10;
            this.label11.Text = "Zeit";
            // 
            // dtpStationBoardTime
            // 
            this.dtpStationBoardTime.CustomFormat = "HH:mm";
            this.dtpStationBoardTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStationBoardTime.Location = new System.Drawing.Point(21, 167);
            this.dtpStationBoardTime.Name = "dtpStationBoardTime";
            this.dtpStationBoardTime.ShowUpDown = true;
            this.dtpStationBoardTime.Size = new System.Drawing.Size(367, 31);
            this.dtpStationBoardTime.TabIndex = 9;
            // 
            // cbMoreStationBoardOptions
            // 
            this.cbMoreStationBoardOptions.AutoSize = true;
            this.cbMoreStationBoardOptions.Location = new System.Drawing.Point(17, 104);
            this.cbMoreStationBoardOptions.Name = "cbMoreStationBoardOptions";
            this.cbMoreStationBoardOptions.Size = new System.Drawing.Size(217, 29);
            this.cbMoreStationBoardOptions.TabIndex = 11;
            this.cbMoreStationBoardOptions.Text = "Mehrere Optionen";
            this.cbMoreStationBoardOptions.UseVisualStyleBackColor = true;
            this.cbMoreStationBoardOptions.CheckedChanged += new System.EventHandler(this.MoreStationBoardOptions_CheckedChanged);
            // 
            // lvStationBoard
            // 
            this.lvStationBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvStationBoard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader11,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader14});
            this.lvStationBoard.FullRowSelect = true;
            this.lvStationBoard.GridLines = true;
            this.lvStationBoard.HoverSelection = true;
            this.lvStationBoard.Location = new System.Drawing.Point(429, 26);
            this.lvStationBoard.Name = "lvStationBoard";
            this.lvStationBoard.Size = new System.Drawing.Size(920, 717);
            this.lvStationBoard.TabIndex = 8;
            this.lvStationBoard.UseCompatibleStateImageBehavior = false;
            this.lvStationBoard.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Verkehrsmittel";
            this.columnHeader6.Width = 320;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ab";
            this.columnHeader7.Width = 130;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Richtung";
            this.columnHeader11.Width = 158;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "An";
            this.columnHeader8.Width = 130;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Dauer";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Abfahrts-Plattform";
            this.columnHeader10.Width = 140;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Ankunfts-Plattform";
            this.columnHeader14.Width = 50;
            // 
            // btSearchStationBoard
            // 
            this.btSearchStationBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSearchStationBoard.Enabled = false;
            this.btSearchStationBoard.Location = new System.Drawing.Point(17, 587);
            this.btSearchStationBoard.Name = "btSearchStationBoard";
            this.btSearchStationBoard.Size = new System.Drawing.Size(406, 66);
            this.btSearchStationBoard.TabIndex = 7;
            this.btSearchStationBoard.Text = "Anzeigen";
            this.btSearchStationBoard.UseVisualStyleBackColor = true;
            this.btSearchStationBoard.Click += new System.EventHandler(this.SearchStationBoard_Click);
            // 
            // pbStationBoard
            // 
            this.pbStationBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbStationBoard.Location = new System.Drawing.Point(17, 659);
            this.pbStationBoard.Name = "pbStationBoard";
            this.pbStationBoard.Size = new System.Drawing.Size(406, 81);
            this.pbStationBoard.TabIndex = 3;
            // 
            // cbSearchStationBoard
            // 
            this.cbSearchStationBoard.FormattingEnabled = true;
            this.cbSearchStationBoard.Location = new System.Drawing.Point(17, 54);
            this.cbSearchStationBoard.Name = "cbSearchStationBoard";
            this.cbSearchStationBoard.Size = new System.Drawing.Size(406, 33);
            this.cbSearchStationBoard.TabIndex = 2;
            this.cbSearchStationBoard.DropDown += new System.EventHandler(this.LoadStationCombobox);
            this.cbSearchStationBoard.SelectedIndexChanged += new System.EventHandler(this.StationBoardDisplayButtonValidation);
            this.cbSearchStationBoard.Leave += new System.EventHandler(this.StationBoardDisplayButtonValidation);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Station";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbSearchStation);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.lvStations);
            this.tabPage3.Controls.Add(this.btStationSearch);
            this.tabPage3.Controls.Add(this.pbStationSearch);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(8, 39);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1370, 761);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Stationen";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbSearchStation
            // 
            this.tbSearchStation.Location = new System.Drawing.Point(129, 22);
            this.tbSearchStation.Name = "tbSearchStation";
            this.tbSearchStation.Size = new System.Drawing.Size(356, 31);
            this.tbSearchStation.TabIndex = 10;
            this.tbSearchStation.TextChanged += new System.EventHandler(this.SearchStation_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.wbStations);
            this.groupBox2.Controls.Add(this.tbStationLatitude);
            this.groupBox2.Controls.Add(this.tbStationLongitude);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(504, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(842, 719);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stationsinformationen";
            // 
            // wbStations
            // 
            this.wbStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbStations.Location = new System.Drawing.Point(22, 88);
            this.wbStations.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbStations.Name = "wbStations";
            this.wbStations.Size = new System.Drawing.Size(804, 607);
            this.wbStations.TabIndex = 4;
            // 
            // tbStationLatitude
            // 
            this.tbStationLatitude.Location = new System.Drawing.Point(552, 38);
            this.tbStationLatitude.Name = "tbStationLatitude";
            this.tbStationLatitude.ReadOnly = true;
            this.tbStationLatitude.Size = new System.Drawing.Size(274, 31);
            this.tbStationLatitude.TabIndex = 3;
            // 
            // tbStationLongitude
            // 
            this.tbStationLongitude.Location = new System.Drawing.Point(272, 38);
            this.tbStationLongitude.Name = "tbStationLongitude";
            this.tbStationLongitude.ReadOnly = true;
            this.tbStationLongitude.Size = new System.Drawing.Size(274, 31);
            this.tbStationLongitude.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(256, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Längengrad / Breitengrad";
            // 
            // lvStations
            // 
            this.lvStations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvStations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12});
            this.lvStations.FullRowSelect = true;
            this.lvStations.Location = new System.Drawing.Point(27, 171);
            this.lvStations.MultiSelect = false;
            this.lvStations.Name = "lvStations";
            this.lvStations.Size = new System.Drawing.Size(458, 573);
            this.lvStations.TabIndex = 8;
            this.lvStations.UseCompatibleStateImageBehavior = false;
            this.lvStations.View = System.Windows.Forms.View.Details;
            this.lvStations.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.Stations_ColumnWidthChanging);
            this.lvStations.SelectedIndexChanged += new System.EventHandler(this.Stations_SelectedIndexChanged);
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Name";
            this.columnHeader12.Width = 450;
            // 
            // btStationSearch
            // 
            this.btStationSearch.Enabled = false;
            this.btStationSearch.Location = new System.Drawing.Point(129, 66);
            this.btStationSearch.Name = "btStationSearch";
            this.btStationSearch.Size = new System.Drawing.Size(356, 45);
            this.btStationSearch.TabIndex = 7;
            this.btStationSearch.Text = "Suchen";
            this.btStationSearch.UseVisualStyleBackColor = true;
            this.btStationSearch.Click += new System.EventHandler(this.StationSearch_Click);
            // 
            // pbStationSearch
            // 
            this.pbStationSearch.Location = new System.Drawing.Point(129, 123);
            this.pbStationSearch.Name = "pbStationSearch";
            this.pbStationSearch.Size = new System.Drawing.Size(356, 33);
            this.pbStationSearch.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 25);
            this.label8.TabIndex = 4;
            this.label8.Text = "Station";
            // 
            // SwissTransportMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 808);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(1412, 879);
            this.Name = "SwissTransportMainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Swiss Transport - by Thomas Gassmann";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbExtendedOptions.ResumeLayout(false);
            this.gbExtendedOptions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbMoreStationOptions.ResumeLayout(false);
            this.gbMoreStationOptions.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvConnections;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.CheckBox cbShowExtendedOptions;
        private System.Windows.Forms.GroupBox gbExtendedOptions;
        private System.Windows.Forms.ComboBox cbArrival;
        private System.Windows.Forms.ComboBox cbDeparture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpConnectionSearchDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbArrivalTime;
        private System.Windows.Forms.RadioButton rbDepartureTime;
        private System.Windows.Forms.Button btSearchConnections;
        private System.Windows.Forms.ProgressBar pbConnectionSearch;
        private System.Windows.Forms.Button btExportXml;
        private System.Windows.Forms.Button btSendMail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSearchStationBoard;
        private System.Windows.Forms.ProgressBar pbStationBoard;
        private System.Windows.Forms.DateTimePicker dtpStationBoardDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btSearchStationBoard;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ProgressBar pbStationSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btStationSearch;
        private System.Windows.Forms.ListView lvStations;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbStationLatitude;
        private System.Windows.Forms.TextBox tbStationLongitude;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.WebBrowser wbStations;
        private System.Windows.Forms.DateTimePicker dtpConnectionSearchTime;
        private System.Windows.Forms.DateTimePicker dtpStationBoardTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbMoreStationBoardOptions;
        private System.Windows.Forms.GroupBox gbMoreStationOptions;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ListView lvStationBoard;
        private System.Windows.Forms.TextBox tbSearchStation;
    }
}

