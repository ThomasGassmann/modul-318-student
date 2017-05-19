﻿namespace SwissTransport.UI
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
            this.btSearchStationBoard = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
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
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbSelectedTab = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbExtendedOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbMoreStationOptions.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 127);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1396, 833);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btSearchConnections);
            this.tabPage2.Controls.Add(this.gbExtendedOptions);
            this.tabPage2.Controls.Add(this.cbShowExtendedOptions);
            this.tabPage2.Controls.Add(this.lvConnections);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1380, 786);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Verbindungen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btSearchConnections
            // 
            this.btSearchConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSearchConnections.Enabled = false;
            this.btSearchConnections.Location = new System.Drawing.Point(18, 720);
            this.btSearchConnections.Margin = new System.Windows.Forms.Padding(4);
            this.btSearchConnections.Name = "btSearchConnections";
            this.btSearchConnections.Size = new System.Drawing.Size(376, 50);
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
            this.gbExtendedOptions.Location = new System.Drawing.Point(6, 208);
            this.gbExtendedOptions.Margin = new System.Windows.Forms.Padding(4);
            this.gbExtendedOptions.Name = "gbExtendedOptions";
            this.gbExtendedOptions.Padding = new System.Windows.Forms.Padding(4);
            this.gbExtendedOptions.Size = new System.Drawing.Size(408, 333);
            this.gbExtendedOptions.TabIndex = 3;
            this.gbExtendedOptions.TabStop = false;
            this.gbExtendedOptions.Text = "Detail-Einstellungen";
            this.gbExtendedOptions.Visible = false;
            // 
            // dtpConnectionSearchTime
            // 
            this.dtpConnectionSearchTime.CustomFormat = "HH:mm";
            this.dtpConnectionSearchTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpConnectionSearchTime.Location = new System.Drawing.Point(12, 190);
            this.dtpConnectionSearchTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpConnectionSearchTime.Name = "dtpConnectionSearchTime";
            this.dtpConnectionSearchTime.ShowUpDown = true;
            this.dtpConnectionSearchTime.Size = new System.Drawing.Size(372, 31);
            this.dtpConnectionSearchTime.TabIndex = 7;
            // 
            // rbArrivalTime
            // 
            this.rbArrivalTime.AutoSize = true;
            this.rbArrivalTime.Location = new System.Drawing.Point(198, 281);
            this.rbArrivalTime.Margin = new System.Windows.Forms.Padding(4);
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
            this.rbDepartureTime.Location = new System.Drawing.Point(12, 281);
            this.rbDepartureTime.Margin = new System.Windows.Forms.Padding(4);
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
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Typ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Zeit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Datum";
            // 
            // dtpConnectionSearchDate
            // 
            this.dtpConnectionSearchDate.Location = new System.Drawing.Point(12, 92);
            this.dtpConnectionSearchDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpConnectionSearchDate.Name = "dtpConnectionSearchDate";
            this.dtpConnectionSearchDate.Size = new System.Drawing.Size(372, 31);
            this.dtpConnectionSearchDate.TabIndex = 0;
            // 
            // cbShowExtendedOptions
            // 
            this.cbShowExtendedOptions.AutoSize = true;
            this.cbShowExtendedOptions.Location = new System.Drawing.Point(18, 167);
            this.cbShowExtendedOptions.Margin = new System.Windows.Forms.Padding(4);
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
            this.lvConnections.Location = new System.Drawing.Point(420, 6);
            this.lvConnections.Margin = new System.Windows.Forms.Padding(4);
            this.lvConnections.Name = "lvConnections";
            this.lvConnections.Size = new System.Drawing.Size(954, 764);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbArrival);
            this.groupBox1.Controls.Add(this.cbDeparture);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(408, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informationen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nach";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Von";
            // 
            // cbArrival
            // 
            this.cbArrival.FormattingEnabled = true;
            this.cbArrival.Location = new System.Drawing.Point(116, 96);
            this.cbArrival.Margin = new System.Windows.Forms.Padding(4);
            this.cbArrival.Name = "cbArrival";
            this.cbArrival.Size = new System.Drawing.Size(268, 33);
            this.cbArrival.TabIndex = 1;
            this.cbArrival.DropDown += new System.EventHandler(this.LoadStationCombobox);
            this.cbArrival.SelectedIndexChanged += new System.EventHandler(this.ConnectionButtonValidation);
            this.cbArrival.TextChanged += new System.EventHandler(this.ConnectionButtonValidation);
            this.cbArrival.Leave += new System.EventHandler(this.ConnectionButtonValidation);
            // 
            // cbDeparture
            // 
            this.cbDeparture.FormattingEnabled = true;
            this.cbDeparture.Location = new System.Drawing.Point(116, 44);
            this.cbDeparture.Margin = new System.Windows.Forms.Padding(4);
            this.cbDeparture.Name = "cbDeparture";
            this.cbDeparture.Size = new System.Drawing.Size(268, 33);
            this.cbDeparture.TabIndex = 0;
            this.cbDeparture.DropDown += new System.EventHandler(this.LoadStationCombobox);
            this.cbDeparture.SelectedIndexChanged += new System.EventHandler(this.ConnectionButtonValidation);
            this.cbDeparture.TextChanged += new System.EventHandler(this.ConnectionButtonValidation);
            this.cbDeparture.Leave += new System.EventHandler(this.ConnectionButtonValidation);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbMoreStationOptions);
            this.tabPage1.Controls.Add(this.cbMoreStationBoardOptions);
            this.tabPage1.Controls.Add(this.lvStationBoard);
            this.tabPage1.Controls.Add(this.btSearchStationBoard);
            this.tabPage1.Controls.Add(this.cbSearchStationBoard);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1380, 786);
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
            this.gbMoreStationOptions.Location = new System.Drawing.Point(16, 138);
            this.gbMoreStationOptions.Margin = new System.Windows.Forms.Padding(4);
            this.gbMoreStationOptions.Name = "gbMoreStationOptions";
            this.gbMoreStationOptions.Padding = new System.Windows.Forms.Padding(4);
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
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Datum";
            // 
            // dtpStationBoardDate
            // 
            this.dtpStationBoardDate.Location = new System.Drawing.Point(20, 71);
            this.dtpStationBoardDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStationBoardDate.Name = "dtpStationBoardDate";
            this.dtpStationBoardDate.Size = new System.Drawing.Size(368, 31);
            this.dtpStationBoardDate.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 138);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 25);
            this.label11.TabIndex = 10;
            this.label11.Text = "Zeit";
            // 
            // dtpStationBoardTime
            // 
            this.dtpStationBoardTime.CustomFormat = "HH:mm";
            this.dtpStationBoardTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStationBoardTime.Location = new System.Drawing.Point(20, 167);
            this.dtpStationBoardTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStationBoardTime.Name = "dtpStationBoardTime";
            this.dtpStationBoardTime.ShowUpDown = true;
            this.dtpStationBoardTime.Size = new System.Drawing.Size(368, 31);
            this.dtpStationBoardTime.TabIndex = 9;
            // 
            // cbMoreStationBoardOptions
            // 
            this.cbMoreStationBoardOptions.AutoSize = true;
            this.cbMoreStationBoardOptions.Location = new System.Drawing.Point(36, 102);
            this.cbMoreStationBoardOptions.Margin = new System.Windows.Forms.Padding(4);
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
            this.columnHeader11});
            this.lvStationBoard.FullRowSelect = true;
            this.lvStationBoard.GridLines = true;
            this.lvStationBoard.Location = new System.Drawing.Point(428, 27);
            this.lvStationBoard.Margin = new System.Windows.Forms.Padding(4);
            this.lvStationBoard.Name = "lvStationBoard";
            this.lvStationBoard.Size = new System.Drawing.Size(930, 736);
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
            // btSearchStationBoard
            // 
            this.btSearchStationBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSearchStationBoard.Enabled = false;
            this.btSearchStationBoard.Location = new System.Drawing.Point(32, 698);
            this.btSearchStationBoard.Margin = new System.Windows.Forms.Padding(4);
            this.btSearchStationBoard.Name = "btSearchStationBoard";
            this.btSearchStationBoard.Size = new System.Drawing.Size(372, 65);
            this.btSearchStationBoard.TabIndex = 7;
            this.btSearchStationBoard.Text = "Anzeigen";
            this.btSearchStationBoard.UseVisualStyleBackColor = true;
            this.btSearchStationBoard.Click += new System.EventHandler(this.SearchStationBoard_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(1068, 60);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.MarqueeAnimationSpeed = 90;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(296, 44);
            this.progressBar.TabIndex = 3;
            // 
            // cbSearchStationBoard
            // 
            this.cbSearchStationBoard.FormattingEnabled = true;
            this.cbSearchStationBoard.Location = new System.Drawing.Point(36, 54);
            this.cbSearchStationBoard.Margin = new System.Windows.Forms.Padding(4);
            this.cbSearchStationBoard.Name = "cbSearchStationBoard";
            this.cbSearchStationBoard.Size = new System.Drawing.Size(368, 33);
            this.cbSearchStationBoard.TabIndex = 2;
            this.cbSearchStationBoard.DropDown += new System.EventHandler(this.LoadStationCombobox);
            this.cbSearchStationBoard.SelectedIndexChanged += new System.EventHandler(this.StationBoardDisplayButtonValidation);
            this.cbSearchStationBoard.TextChanged += new System.EventHandler(this.StationBoardDisplayButtonValidation);
            this.cbSearchStationBoard.Leave += new System.EventHandler(this.StationBoardDisplayButtonValidation);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(8, 39);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1380, 786);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Stationen";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbSearchStation
            // 
            this.tbSearchStation.Location = new System.Drawing.Point(128, 21);
            this.tbSearchStation.Margin = new System.Windows.Forms.Padding(4);
            this.tbSearchStation.Name = "tbSearchStation";
            this.tbSearchStation.Size = new System.Drawing.Size(352, 31);
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
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(852, 737);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stationsinformationen";
            // 
            // wbStations
            // 
            this.wbStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbStations.Location = new System.Drawing.Point(22, 85);
            this.wbStations.Margin = new System.Windows.Forms.Padding(4);
            this.wbStations.MinimumSize = new System.Drawing.Size(20, 19);
            this.wbStations.Name = "wbStations";
            this.wbStations.Size = new System.Drawing.Size(814, 629);
            this.wbStations.TabIndex = 4;
            // 
            // tbStationLatitude
            // 
            this.tbStationLatitude.Location = new System.Drawing.Point(558, 38);
            this.tbStationLatitude.Margin = new System.Windows.Forms.Padding(4);
            this.tbStationLatitude.Name = "tbStationLatitude";
            this.tbStationLatitude.ReadOnly = true;
            this.tbStationLatitude.Size = new System.Drawing.Size(256, 31);
            this.tbStationLatitude.TabIndex = 3;
            // 
            // tbStationLongitude
            // 
            this.tbStationLongitude.Location = new System.Drawing.Point(282, 38);
            this.tbStationLongitude.Margin = new System.Windows.Forms.Padding(4);
            this.tbStationLongitude.Name = "tbStationLongitude";
            this.tbStationLongitude.ReadOnly = true;
            this.tbStationLongitude.Size = new System.Drawing.Size(256, 31);
            this.tbStationLongitude.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 40);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.lvStations.Location = new System.Drawing.Point(28, 117);
            this.lvStations.Margin = new System.Windows.Forms.Padding(4);
            this.lvStations.MultiSelect = false;
            this.lvStations.Name = "lvStations";
            this.lvStations.Size = new System.Drawing.Size(458, 645);
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
            this.btStationSearch.Location = new System.Drawing.Point(128, 65);
            this.btStationSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btStationSearch.Name = "btStationSearch";
            this.btStationSearch.Size = new System.Drawing.Size(356, 44);
            this.btStationSearch.TabIndex = 7;
            this.btStationSearch.Text = "Suchen";
            this.btStationSearch.UseVisualStyleBackColor = true;
            this.btStationSearch.Click += new System.EventHandler(this.StationSearch_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 25);
            this.label8.TabIndex = 4;
            this.label8.Text = "Station";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1396, 44);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(83, 36);
            this.fileToolStripMenuItem.Text = "Datei";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.exportToolStripMenuItem.Text = "Export";
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
            // lbSelectedTab
            // 
            this.lbSelectedTab.AutoSize = true;
            this.lbSelectedTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectedTab.Location = new System.Drawing.Point(37, 60);
            this.lbSelectedTab.Name = "lbSelectedTab";
            this.lbSelectedTab.Size = new System.Drawing.Size(256, 44);
            this.lbSelectedTab.TabIndex = 4;
            this.lbSelectedTab.Text = "Verbindungen";
            // 
            // SwissTransportMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 962);
            this.Controls.Add(this.lbSelectedTab);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.progressBar);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1402, 850);
            this.Name = "SwissTransportMainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Swiss Transport - by Thomas Gassmann";
            this.Load += new System.EventHandler(this.SwissTransportMainForm_Load);
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSearchStationBoard;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.DateTimePicker dtpStationBoardDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btSearchStationBoard;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader11;
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
        private System.Windows.Forms.ListView lvStationBoard;
        private System.Windows.Forms.TextBox tbSearchStation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Label lbSelectedTab;
    }
}

