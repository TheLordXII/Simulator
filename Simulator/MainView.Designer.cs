namespace Simulator
{
    partial class MainView
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schließenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aufgabenstellungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bewertungsschemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenblattToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dokuFazitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBLST = new System.Windows.Forms.GroupBox();
            this.lvAusgabe = new System.Windows.Forms.ListView();
            this.Programm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpBedienung = new System.Windows.Forms.GroupBox();
            this.btnStopp = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnEinzelschritt = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.gpRegister = new System.Windows.Forms.GroupBox();
            this.lblTimer0 = new System.Windows.Forms.Label();
            this.lblTimer0Text = new System.Windows.Forms.Label();
            this.lblVorteiler = new System.Windows.Forms.Label();
            this.lblVorteilerText = new System.Windows.Forms.Label();
            this.lblOption = new System.Windows.Forms.Label();
            this.lblOptionText1 = new System.Windows.Forms.Label();
            this.lblFSR = new System.Windows.Forms.Label();
            this.lblFSRText = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusText2 = new System.Windows.Forms.Label();
            this.lblPCIntern = new System.Windows.Forms.Label();
            this.lblPCInternText = new System.Windows.Forms.Label();
            this.lblPCLATCH = new System.Windows.Forms.Label();
            this.lblPCLATCHText = new System.Windows.Forms.Label();
            this.lblPCL = new System.Windows.Forms.Label();
            this.lblPCLText = new System.Windows.Forms.Label();
            this.lblWReg = new System.Windows.Forms.Label();
            this.lblWRegText = new System.Windows.Forms.Label();
            this.GuiThread = new System.ComponentModel.BackgroundWorker();
            this.gbPortA = new System.Windows.Forms.GroupBox();
            this.cbPinA4 = new System.Windows.Forms.CheckBox();
            this.cbPinA3 = new System.Windows.Forms.CheckBox();
            this.cbPinA2 = new System.Windows.Forms.CheckBox();
            this.cbPinA1 = new System.Windows.Forms.CheckBox();
            this.cbPinA0 = new System.Windows.Forms.CheckBox();
            this.cbTrisA0 = new System.Windows.Forms.CheckBox();
            this.cbTrisA1 = new System.Windows.Forms.CheckBox();
            this.cbTrisA2 = new System.Windows.Forms.CheckBox();
            this.cbTrisA3 = new System.Windows.Forms.CheckBox();
            this.cbTrisA4 = new System.Windows.Forms.CheckBox();
            this.cbTrisA5 = new System.Windows.Forms.CheckBox();
            this.cbTrisA6 = new System.Windows.Forms.CheckBox();
            this.cbTrisA7 = new System.Windows.Forms.CheckBox();
            this.lblPinA = new System.Windows.Forms.Label();
            this.lblTrisA = new System.Windows.Forms.Label();
            this.gbPortB = new System.Windows.Forms.GroupBox();
            this.cbPinB7 = new System.Windows.Forms.CheckBox();
            this.cbPinB6 = new System.Windows.Forms.CheckBox();
            this.cbPinB5 = new System.Windows.Forms.CheckBox();
            this.cbPinB4 = new System.Windows.Forms.CheckBox();
            this.cbPinB3 = new System.Windows.Forms.CheckBox();
            this.cbPinB2 = new System.Windows.Forms.CheckBox();
            this.cbPinB1 = new System.Windows.Forms.CheckBox();
            this.cbPinB0 = new System.Windows.Forms.CheckBox();
            this.cbTrisB0 = new System.Windows.Forms.CheckBox();
            this.cbTrisB1 = new System.Windows.Forms.CheckBox();
            this.cbTrisB2 = new System.Windows.Forms.CheckBox();
            this.cbTrisB3 = new System.Windows.Forms.CheckBox();
            this.cbTrisB4 = new System.Windows.Forms.CheckBox();
            this.cbTrisB5 = new System.Windows.Forms.CheckBox();
            this.cbTrisB6 = new System.Windows.Forms.CheckBox();
            this.cbTrisB7 = new System.Windows.Forms.CheckBox();
            this.lblPinB = new System.Windows.Forms.Label();
            this.lblTrisB = new System.Windows.Forms.Label();
            this.gBTiming = new System.Windows.Forms.GroupBox();
            this.lblWatchdog = new System.Windows.Forms.Label();
            this.lblWatchdogText = new System.Windows.Forms.Label();
            this.cbWatchdog = new System.Windows.Forms.CheckBox();
            this.cbQuarz = new System.Windows.Forms.ComboBox();
            this.lblQuarz = new System.Windows.Forms.Label();
            this.lblLaufzeitMyh = new System.Windows.Forms.Label();
            this.lblLaufzeit = new System.Windows.Forms.Label();
            this.lblLaufzeitText = new System.Windows.Forms.Label();
            this.gbStack = new System.Windows.Forms.GroupBox();
            this.lblStack8 = new System.Windows.Forms.Label();
            this.lblStack6 = new System.Windows.Forms.Label();
            this.lblStack7 = new System.Windows.Forms.Label();
            this.lblStack5 = new System.Windows.Forms.Label();
            this.lblStack4 = new System.Windows.Forms.Label();
            this.lblStack3 = new System.Windows.Forms.Label();
            this.lblStack2 = new System.Windows.Forms.Label();
            this.lblStack1 = new System.Windows.Forms.Label();
            this.gbSFR = new System.Windows.Forms.GroupBox();
            this.lblRIF = new System.Windows.Forms.Label();
            this.lblIF = new System.Windows.Forms.Label();
            this.lblTIF = new System.Windows.Forms.Label();
            this.lblRIE = new System.Windows.Forms.Label();
            this.lblIE = new System.Windows.Forms.Label();
            this.lblTIE = new System.Windows.Forms.Label();
            this.lblEIE = new System.Windows.Forms.Label();
            this.lblGIE = new System.Windows.Forms.Label();
            this.lblRIFText = new System.Windows.Forms.Label();
            this.lblIFText = new System.Windows.Forms.Label();
            this.lblTIFText = new System.Windows.Forms.Label();
            this.lblRIEText = new System.Windows.Forms.Label();
            this.lblIEText = new System.Windows.Forms.Label();
            this.lblTIEText = new System.Windows.Forms.Label();
            this.lblEIEText = new System.Windows.Forms.Label();
            this.lblGIEText = new System.Windows.Forms.Label();
            this.lblIntcon = new System.Windows.Forms.Label();
            this.lblPS0 = new System.Windows.Forms.Label();
            this.lblPS1 = new System.Windows.Forms.Label();
            this.lblPS2 = new System.Windows.Forms.Label();
            this.lblPSA = new System.Windows.Forms.Label();
            this.lblTSe = new System.Windows.Forms.Label();
            this.lblTCs = new System.Windows.Forms.Label();
            this.lblIEg = new System.Windows.Forms.Label();
            this.lblRPu = new System.Windows.Forms.Label();
            this.lblPS0Text = new System.Windows.Forms.Label();
            this.lblPS1Text = new System.Windows.Forms.Label();
            this.lblPS2Text = new System.Windows.Forms.Label();
            this.lblPSAText = new System.Windows.Forms.Label();
            this.lblTSeText = new System.Windows.Forms.Label();
            this.lblTCsText = new System.Windows.Forms.Label();
            this.lblIEgText = new System.Windows.Forms.Label();
            this.lblRPuText = new System.Windows.Forms.Label();
            this.lblOptionText2 = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblDC = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblPD = new System.Windows.Forms.Label();
            this.lblTO = new System.Windows.Forms.Label();
            this.lblRP0 = new System.Windows.Forms.Label();
            this.lblRP1 = new System.Windows.Forms.Label();
            this.lblIRP = new System.Windows.Forms.Label();
            this.lblCText = new System.Windows.Forms.Label();
            this.lblDCText = new System.Windows.Forms.Label();
            this.lblZText = new System.Windows.Forms.Label();
            this.lblPDText = new System.Windows.Forms.Label();
            this.lblTOText = new System.Windows.Forms.Label();
            this.lblRP0Text = new System.Windows.Forms.Label();
            this.lblRP1Text = new System.Windows.Forms.Label();
            this.lblIRPText = new System.Windows.Forms.Label();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.gbFileregister = new System.Windows.Forms.GroupBox();
            this.dgvFileregister = new System.Windows.Forms.DataGridView();
            this.spalte1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spalte2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spalte3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spalte4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spalte5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spalte6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spalte7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spalte8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wbPDF = new System.Windows.Forms.WebBrowser();
            this.gbFileregBearbeiten = new System.Windows.Forms.GroupBox();
            this.lblSpeicherstelle = new System.Windows.Forms.Label();
            this.tbSpeicherstelle = new System.Windows.Forms.TextBox();
            this.lblWert = new System.Windows.Forms.Label();
            this.tbWert = new System.Windows.Forms.TextBox();
            this.btnUpdateFile = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.gBLST.SuspendLayout();
            this.gpBedienung.SuspendLayout();
            this.gpRegister.SuspendLayout();
            this.gbPortA.SuspendLayout();
            this.gbPortB.SuspendLayout();
            this.gBTiming.SuspendLayout();
            this.gbStack.SuspendLayout();
            this.gbSFR.SuspendLayout();
            this.gbFileregister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileregister)).BeginInit();
            this.gbFileregBearbeiten.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1175, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ladenToolStripMenuItem,
            this.schließenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.ladenToolStripMenuItem.Text = "Laden";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // schließenToolStripMenuItem
            // 
            this.schließenToolStripMenuItem.Name = "schließenToolStripMenuItem";
            this.schließenToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.schließenToolStripMenuItem.Text = "Schließen";
            this.schließenToolStripMenuItem.Click += new System.EventHandler(this.schließenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aufgabenstellungToolStripMenuItem,
            this.bewertungsschemaToolStripMenuItem,
            this.datenblattToolStripMenuItem,
            this.dokuFazitToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // gBLST
            // 
            this.gBLST.Controls.Add(this.lvAusgabe);
            this.gBLST.Location = new System.Drawing.Point(12, 223);
            this.gBLST.Name = "gBLST";
            this.gBLST.Size = new System.Drawing.Size(430, 519);
            this.gBLST.TabIndex = 1;
            this.gBLST.TabStop = false;
            this.gBLST.Text = "Programm LST-Datei";
            // 
            // lvAusgabe
            // 
            this.lvAusgabe.BackColor = System.Drawing.SystemColors.Window;
            this.lvAusgabe.CheckBoxes = true;
            this.lvAusgabe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Programm});
            this.lvAusgabe.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvAusgabe.HideSelection = false;
            this.lvAusgabe.LabelEdit = true;
            this.lvAusgabe.Location = new System.Drawing.Point(7, 19);
            this.lvAusgabe.Name = "lvAusgabe";
            this.lvAusgabe.Size = new System.Drawing.Size(411, 488);
            this.lvAusgabe.TabIndex = 9;
            this.lvAusgabe.UseCompatibleStateImageBehavior = false;
            this.lvAusgabe.View = System.Windows.Forms.View.Details;
            // 
            // Programm
            // 
            this.Programm.Text = "Breakpoint / Programm";
            this.Programm.Width = 405;
            // 
            // gpBedienung
            // 
            this.gpBedienung.Controls.Add(this.btnStopp);
            this.gpBedienung.Controls.Add(this.btnStart);
            this.gpBedienung.Controls.Add(this.btnEinzelschritt);
            this.gpBedienung.Controls.Add(this.btnReset);
            this.gpBedienung.Location = new System.Drawing.Point(650, 54);
            this.gpBedienung.Name = "gpBedienung";
            this.gpBedienung.Size = new System.Drawing.Size(121, 151);
            this.gpBedienung.TabIndex = 2;
            this.gpBedienung.TabStop = false;
            this.gpBedienung.Text = "Bedienung";
            // 
            // btnStopp
            // 
            this.btnStopp.Location = new System.Drawing.Point(24, 106);
            this.btnStopp.Name = "btnStopp";
            this.btnStopp.Size = new System.Drawing.Size(75, 23);
            this.btnStopp.TabIndex = 3;
            this.btnStopp.Text = "Stopp";
            this.btnStopp.UseVisualStyleBackColor = true;
            this.btnStopp.Click += new System.EventHandler(this.btnStopp_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(24, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEinzelschritt
            // 
            this.btnEinzelschritt.Location = new System.Drawing.Point(24, 77);
            this.btnEinzelschritt.Name = "btnEinzelschritt";
            this.btnEinzelschritt.Size = new System.Drawing.Size(75, 23);
            this.btnEinzelschritt.TabIndex = 1;
            this.btnEinzelschritt.Text = "Einzelschritt";
            this.btnEinzelschritt.UseVisualStyleBackColor = true;
            this.btnEinzelschritt.Click += new System.EventHandler(this.btnEinzelschritt_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(24, 48);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // gpRegister
            // 
            this.gpRegister.Controls.Add(this.lblTimer0);
            this.gpRegister.Controls.Add(this.lblTimer0Text);
            this.gpRegister.Controls.Add(this.lblVorteiler);
            this.gpRegister.Controls.Add(this.lblVorteilerText);
            this.gpRegister.Controls.Add(this.lblOption);
            this.gpRegister.Controls.Add(this.lblOptionText1);
            this.gpRegister.Controls.Add(this.lblFSR);
            this.gpRegister.Controls.Add(this.lblFSRText);
            this.gpRegister.Controls.Add(this.lblStatus);
            this.gpRegister.Controls.Add(this.lblStatusText2);
            this.gpRegister.Controls.Add(this.lblPCIntern);
            this.gpRegister.Controls.Add(this.lblPCInternText);
            this.gpRegister.Controls.Add(this.lblPCLATCH);
            this.gpRegister.Controls.Add(this.lblPCLATCHText);
            this.gpRegister.Controls.Add(this.lblPCL);
            this.gpRegister.Controls.Add(this.lblPCLText);
            this.gpRegister.Controls.Add(this.lblWReg);
            this.gpRegister.Controls.Add(this.lblWRegText);
            this.gpRegister.Location = new System.Drawing.Point(19, 45);
            this.gpRegister.Name = "gpRegister";
            this.gpRegister.Size = new System.Drawing.Size(211, 139);
            this.gpRegister.TabIndex = 3;
            this.gpRegister.TabStop = false;
            this.gpRegister.Text = "Registerinhalt";
            // 
            // lblTimer0
            // 
            this.lblTimer0.AutoSize = true;
            this.lblTimer0.Location = new System.Drawing.Point(172, 109);
            this.lblTimer0.Name = "lblTimer0";
            this.lblTimer0.Size = new System.Drawing.Size(19, 13);
            this.lblTimer0.TabIndex = 17;
            this.lblTimer0.Text = "00";
            // 
            // lblTimer0Text
            // 
            this.lblTimer0Text.AutoSize = true;
            this.lblTimer0Text.Location = new System.Drawing.Point(102, 109);
            this.lblTimer0Text.Name = "lblTimer0Text";
            this.lblTimer0Text.Size = new System.Drawing.Size(42, 13);
            this.lblTimer0Text.TabIndex = 16;
            this.lblTimer0Text.Text = "Timer0:";
            // 
            // lblVorteiler
            // 
            this.lblVorteiler.AutoSize = true;
            this.lblVorteiler.Location = new System.Drawing.Point(172, 92);
            this.lblVorteiler.Name = "lblVorteiler";
            this.lblVorteiler.Size = new System.Drawing.Size(22, 13);
            this.lblVorteiler.TabIndex = 15;
            this.lblVorteiler.Text = "1:1";
            // 
            // lblVorteilerText
            // 
            this.lblVorteilerText.AutoSize = true;
            this.lblVorteilerText.Location = new System.Drawing.Point(102, 92);
            this.lblVorteilerText.Name = "lblVorteilerText";
            this.lblVorteilerText.Size = new System.Drawing.Size(48, 13);
            this.lblVorteilerText.TabIndex = 14;
            this.lblVorteilerText.Text = "Vorteiler:";
            // 
            // lblOption
            // 
            this.lblOption.AutoSize = true;
            this.lblOption.Location = new System.Drawing.Point(172, 68);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(19, 13);
            this.lblOption.TabIndex = 13;
            this.lblOption.Text = "00";
            // 
            // lblOptionText1
            // 
            this.lblOptionText1.AutoSize = true;
            this.lblOptionText1.Location = new System.Drawing.Point(102, 68);
            this.lblOptionText1.Name = "lblOptionText1";
            this.lblOptionText1.Size = new System.Drawing.Size(41, 13);
            this.lblOptionText1.TabIndex = 12;
            this.lblOptionText1.Text = "Option:";
            // 
            // lblFSR
            // 
            this.lblFSR.AutoSize = true;
            this.lblFSR.Location = new System.Drawing.Point(172, 45);
            this.lblFSR.Name = "lblFSR";
            this.lblFSR.Size = new System.Drawing.Size(19, 13);
            this.lblFSR.TabIndex = 11;
            this.lblFSR.Text = "00";
            // 
            // lblFSRText
            // 
            this.lblFSRText.AutoSize = true;
            this.lblFSRText.Location = new System.Drawing.Point(102, 45);
            this.lblFSRText.Name = "lblFSRText";
            this.lblFSRText.Size = new System.Drawing.Size(31, 13);
            this.lblFSRText.TabIndex = 10;
            this.lblFSRText.Text = "FSR:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(172, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(19, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "00";
            // 
            // lblStatusText2
            // 
            this.lblStatusText2.AutoSize = true;
            this.lblStatusText2.Location = new System.Drawing.Point(102, 20);
            this.lblStatusText2.Name = "lblStatusText2";
            this.lblStatusText2.Size = new System.Drawing.Size(40, 13);
            this.lblStatusText2.TabIndex = 8;
            this.lblStatusText2.Text = "Status:";
            // 
            // lblPCIntern
            // 
            this.lblPCIntern.AutoSize = true;
            this.lblPCIntern.Location = new System.Drawing.Point(77, 92);
            this.lblPCIntern.Name = "lblPCIntern";
            this.lblPCIntern.Size = new System.Drawing.Size(19, 13);
            this.lblPCIntern.TabIndex = 7;
            this.lblPCIntern.Text = "00";
            // 
            // lblPCInternText
            // 
            this.lblPCInternText.AutoSize = true;
            this.lblPCInternText.Location = new System.Drawing.Point(7, 92);
            this.lblPCInternText.Name = "lblPCInternText";
            this.lblPCInternText.Size = new System.Drawing.Size(53, 13);
            this.lblPCInternText.TabIndex = 6;
            this.lblPCInternText.Text = "PC intern:";
            // 
            // lblPCLATCH
            // 
            this.lblPCLATCH.AutoSize = true;
            this.lblPCLATCH.Location = new System.Drawing.Point(77, 68);
            this.lblPCLATCH.Name = "lblPCLATCH";
            this.lblPCLATCH.Size = new System.Drawing.Size(19, 13);
            this.lblPCLATCH.TabIndex = 5;
            this.lblPCLATCH.Text = "00";
            // 
            // lblPCLATCHText
            // 
            this.lblPCLATCHText.AutoSize = true;
            this.lblPCLATCHText.Location = new System.Drawing.Point(7, 68);
            this.lblPCLATCHText.Name = "lblPCLATCHText";
            this.lblPCLATCHText.Size = new System.Drawing.Size(59, 13);
            this.lblPCLATCHText.TabIndex = 4;
            this.lblPCLATCHText.Text = "PCLATCH:";
            // 
            // lblPCL
            // 
            this.lblPCL.AutoSize = true;
            this.lblPCL.Location = new System.Drawing.Point(77, 45);
            this.lblPCL.Name = "lblPCL";
            this.lblPCL.Size = new System.Drawing.Size(19, 13);
            this.lblPCL.TabIndex = 3;
            this.lblPCL.Text = "00";
            // 
            // lblPCLText
            // 
            this.lblPCLText.AutoSize = true;
            this.lblPCLText.Location = new System.Drawing.Point(7, 45);
            this.lblPCLText.Name = "lblPCLText";
            this.lblPCLText.Size = new System.Drawing.Size(30, 13);
            this.lblPCLText.TabIndex = 2;
            this.lblPCLText.Text = "PCL:";
            // 
            // lblWReg
            // 
            this.lblWReg.AutoSize = true;
            this.lblWReg.Location = new System.Drawing.Point(77, 20);
            this.lblWReg.Name = "lblWReg";
            this.lblWReg.Size = new System.Drawing.Size(19, 13);
            this.lblWReg.TabIndex = 1;
            this.lblWReg.Text = "00";
            // 
            // lblWRegText
            // 
            this.lblWRegText.AutoSize = true;
            this.lblWRegText.Location = new System.Drawing.Point(7, 20);
            this.lblWRegText.Name = "lblWRegText";
            this.lblWRegText.Size = new System.Drawing.Size(63, 13);
            this.lblWRegText.TabIndex = 0;
            this.lblWRegText.Text = "W-Register:";
            // 
            // gbPortA
            // 
            this.gbPortA.Controls.Add(this.cbPinA4);
            this.gbPortA.Controls.Add(this.cbPinA3);
            this.gbPortA.Controls.Add(this.cbPinA2);
            this.gbPortA.Controls.Add(this.cbPinA1);
            this.gbPortA.Controls.Add(this.cbPinA0);
            this.gbPortA.Controls.Add(this.cbTrisA0);
            this.gbPortA.Controls.Add(this.cbTrisA1);
            this.gbPortA.Controls.Add(this.cbTrisA2);
            this.gbPortA.Controls.Add(this.cbTrisA3);
            this.gbPortA.Controls.Add(this.cbTrisA4);
            this.gbPortA.Controls.Add(this.cbTrisA5);
            this.gbPortA.Controls.Add(this.cbTrisA6);
            this.gbPortA.Controls.Add(this.cbTrisA7);
            this.gbPortA.Controls.Add(this.lblPinA);
            this.gbPortA.Controls.Add(this.lblTrisA);
            this.gbPortA.Location = new System.Drawing.Point(794, 54);
            this.gbPortA.Name = "gbPortA";
            this.gbPortA.Size = new System.Drawing.Size(354, 107);
            this.gbPortA.TabIndex = 4;
            this.gbPortA.TabStop = false;
            this.gbPortA.Text = "PortA";
            // 
            // cbPinA4
            // 
            this.cbPinA4.AutoSize = true;
            this.cbPinA4.Location = new System.Drawing.Point(162, 59);
            this.cbPinA4.Name = "cbPinA4";
            this.cbPinA4.Size = new System.Drawing.Size(32, 17);
            this.cbPinA4.TabIndex = 14;
            this.cbPinA4.Text = "4";
            this.cbPinA4.UseVisualStyleBackColor = true;
            // 
            // cbPinA3
            // 
            this.cbPinA3.AutoSize = true;
            this.cbPinA3.Location = new System.Drawing.Point(201, 60);
            this.cbPinA3.Name = "cbPinA3";
            this.cbPinA3.Size = new System.Drawing.Size(32, 17);
            this.cbPinA3.TabIndex = 13;
            this.cbPinA3.Text = "3";
            this.cbPinA3.UseVisualStyleBackColor = true;
            // 
            // cbPinA2
            // 
            this.cbPinA2.AutoSize = true;
            this.cbPinA2.Location = new System.Drawing.Point(240, 60);
            this.cbPinA2.Name = "cbPinA2";
            this.cbPinA2.Size = new System.Drawing.Size(32, 17);
            this.cbPinA2.TabIndex = 12;
            this.cbPinA2.Text = "2";
            this.cbPinA2.UseVisualStyleBackColor = true;
            // 
            // cbPinA1
            // 
            this.cbPinA1.AutoSize = true;
            this.cbPinA1.Location = new System.Drawing.Point(279, 60);
            this.cbPinA1.Name = "cbPinA1";
            this.cbPinA1.Size = new System.Drawing.Size(32, 17);
            this.cbPinA1.TabIndex = 11;
            this.cbPinA1.Text = "1";
            this.cbPinA1.UseVisualStyleBackColor = true;
            // 
            // cbPinA0
            // 
            this.cbPinA0.AutoSize = true;
            this.cbPinA0.Location = new System.Drawing.Point(318, 60);
            this.cbPinA0.Name = "cbPinA0";
            this.cbPinA0.Size = new System.Drawing.Size(32, 17);
            this.cbPinA0.TabIndex = 10;
            this.cbPinA0.Text = "0";
            this.cbPinA0.UseVisualStyleBackColor = true;
            // 
            // cbTrisA0
            // 
            this.cbTrisA0.AutoSize = true;
            this.cbTrisA0.Enabled = false;
            this.cbTrisA0.Location = new System.Drawing.Point(318, 20);
            this.cbTrisA0.Name = "cbTrisA0";
            this.cbTrisA0.Size = new System.Drawing.Size(32, 17);
            this.cbTrisA0.TabIndex = 9;
            this.cbTrisA0.Text = "0";
            this.cbTrisA0.UseVisualStyleBackColor = true;
            // 
            // cbTrisA1
            // 
            this.cbTrisA1.AutoSize = true;
            this.cbTrisA1.Enabled = false;
            this.cbTrisA1.Location = new System.Drawing.Point(279, 20);
            this.cbTrisA1.Name = "cbTrisA1";
            this.cbTrisA1.Size = new System.Drawing.Size(32, 17);
            this.cbTrisA1.TabIndex = 8;
            this.cbTrisA1.Text = "1";
            this.cbTrisA1.UseVisualStyleBackColor = true;
            // 
            // cbTrisA2
            // 
            this.cbTrisA2.AutoSize = true;
            this.cbTrisA2.Enabled = false;
            this.cbTrisA2.Location = new System.Drawing.Point(240, 20);
            this.cbTrisA2.Name = "cbTrisA2";
            this.cbTrisA2.Size = new System.Drawing.Size(32, 17);
            this.cbTrisA2.TabIndex = 7;
            this.cbTrisA2.Text = "2";
            this.cbTrisA2.UseVisualStyleBackColor = true;
            // 
            // cbTrisA3
            // 
            this.cbTrisA3.AutoSize = true;
            this.cbTrisA3.Enabled = false;
            this.cbTrisA3.Location = new System.Drawing.Point(201, 20);
            this.cbTrisA3.Name = "cbTrisA3";
            this.cbTrisA3.Size = new System.Drawing.Size(32, 17);
            this.cbTrisA3.TabIndex = 6;
            this.cbTrisA3.Text = "3";
            this.cbTrisA3.UseVisualStyleBackColor = true;
            // 
            // cbTrisA4
            // 
            this.cbTrisA4.AutoSize = true;
            this.cbTrisA4.Enabled = false;
            this.cbTrisA4.Location = new System.Drawing.Point(162, 20);
            this.cbTrisA4.Name = "cbTrisA4";
            this.cbTrisA4.Size = new System.Drawing.Size(32, 17);
            this.cbTrisA4.TabIndex = 5;
            this.cbTrisA4.Text = "4";
            this.cbTrisA4.UseVisualStyleBackColor = true;
            // 
            // cbTrisA5
            // 
            this.cbTrisA5.AutoSize = true;
            this.cbTrisA5.Enabled = false;
            this.cbTrisA5.Location = new System.Drawing.Point(123, 19);
            this.cbTrisA5.Name = "cbTrisA5";
            this.cbTrisA5.Size = new System.Drawing.Size(32, 17);
            this.cbTrisA5.TabIndex = 4;
            this.cbTrisA5.Text = "5";
            this.cbTrisA5.UseVisualStyleBackColor = true;
            // 
            // cbTrisA6
            // 
            this.cbTrisA6.AutoSize = true;
            this.cbTrisA6.Enabled = false;
            this.cbTrisA6.Location = new System.Drawing.Point(84, 19);
            this.cbTrisA6.Name = "cbTrisA6";
            this.cbTrisA6.Size = new System.Drawing.Size(32, 17);
            this.cbTrisA6.TabIndex = 3;
            this.cbTrisA6.Text = "6";
            this.cbTrisA6.UseVisualStyleBackColor = true;
            // 
            // cbTrisA7
            // 
            this.cbTrisA7.AutoSize = true;
            this.cbTrisA7.Enabled = false;
            this.cbTrisA7.Location = new System.Drawing.Point(46, 20);
            this.cbTrisA7.Name = "cbTrisA7";
            this.cbTrisA7.Size = new System.Drawing.Size(32, 17);
            this.cbTrisA7.TabIndex = 2;
            this.cbTrisA7.Text = "7";
            this.cbTrisA7.UseVisualStyleBackColor = true;
            // 
            // lblPinA
            // 
            this.lblPinA.AutoSize = true;
            this.lblPinA.Location = new System.Drawing.Point(7, 65);
            this.lblPinA.Name = "lblPinA";
            this.lblPinA.Size = new System.Drawing.Size(22, 13);
            this.lblPinA.TabIndex = 1;
            this.lblPinA.Text = "Pin";
            // 
            // lblTrisA
            // 
            this.lblTrisA.AutoSize = true;
            this.lblTrisA.Location = new System.Drawing.Point(7, 20);
            this.lblTrisA.Name = "lblTrisA";
            this.lblTrisA.Size = new System.Drawing.Size(24, 13);
            this.lblTrisA.TabIndex = 0;
            this.lblTrisA.Text = "Tris";
            // 
            // gbPortB
            // 
            this.gbPortB.Controls.Add(this.cbPinB7);
            this.gbPortB.Controls.Add(this.cbPinB6);
            this.gbPortB.Controls.Add(this.cbPinB5);
            this.gbPortB.Controls.Add(this.cbPinB4);
            this.gbPortB.Controls.Add(this.cbPinB3);
            this.gbPortB.Controls.Add(this.cbPinB2);
            this.gbPortB.Controls.Add(this.cbPinB1);
            this.gbPortB.Controls.Add(this.cbPinB0);
            this.gbPortB.Controls.Add(this.cbTrisB0);
            this.gbPortB.Controls.Add(this.cbTrisB1);
            this.gbPortB.Controls.Add(this.cbTrisB2);
            this.gbPortB.Controls.Add(this.cbTrisB3);
            this.gbPortB.Controls.Add(this.cbTrisB4);
            this.gbPortB.Controls.Add(this.cbTrisB5);
            this.gbPortB.Controls.Add(this.cbTrisB6);
            this.gbPortB.Controls.Add(this.cbTrisB7);
            this.gbPortB.Controls.Add(this.lblPinB);
            this.gbPortB.Controls.Add(this.lblTrisB);
            this.gbPortB.Location = new System.Drawing.Point(794, 164);
            this.gbPortB.Name = "gbPortB";
            this.gbPortB.Size = new System.Drawing.Size(354, 114);
            this.gbPortB.TabIndex = 5;
            this.gbPortB.TabStop = false;
            this.gbPortB.Text = "PortB";
            // 
            // cbPinB7
            // 
            this.cbPinB7.AutoSize = true;
            this.cbPinB7.Location = new System.Drawing.Point(46, 66);
            this.cbPinB7.Name = "cbPinB7";
            this.cbPinB7.Size = new System.Drawing.Size(32, 17);
            this.cbPinB7.TabIndex = 31;
            this.cbPinB7.Text = "7";
            this.cbPinB7.UseVisualStyleBackColor = true;
            // 
            // cbPinB6
            // 
            this.cbPinB6.AutoSize = true;
            this.cbPinB6.Location = new System.Drawing.Point(84, 66);
            this.cbPinB6.Name = "cbPinB6";
            this.cbPinB6.Size = new System.Drawing.Size(32, 17);
            this.cbPinB6.TabIndex = 30;
            this.cbPinB6.Text = "6";
            this.cbPinB6.UseVisualStyleBackColor = true;
            // 
            // cbPinB5
            // 
            this.cbPinB5.AutoSize = true;
            this.cbPinB5.Location = new System.Drawing.Point(123, 66);
            this.cbPinB5.Name = "cbPinB5";
            this.cbPinB5.Size = new System.Drawing.Size(32, 17);
            this.cbPinB5.TabIndex = 29;
            this.cbPinB5.Text = "5";
            this.cbPinB5.UseVisualStyleBackColor = true;
            // 
            // cbPinB4
            // 
            this.cbPinB4.AutoSize = true;
            this.cbPinB4.Location = new System.Drawing.Point(162, 66);
            this.cbPinB4.Name = "cbPinB4";
            this.cbPinB4.Size = new System.Drawing.Size(32, 17);
            this.cbPinB4.TabIndex = 28;
            this.cbPinB4.Text = "4";
            this.cbPinB4.UseVisualStyleBackColor = true;
            // 
            // cbPinB3
            // 
            this.cbPinB3.AutoSize = true;
            this.cbPinB3.Location = new System.Drawing.Point(201, 66);
            this.cbPinB3.Name = "cbPinB3";
            this.cbPinB3.Size = new System.Drawing.Size(32, 17);
            this.cbPinB3.TabIndex = 27;
            this.cbPinB3.Text = "3";
            this.cbPinB3.UseVisualStyleBackColor = true;
            // 
            // cbPinB2
            // 
            this.cbPinB2.AutoSize = true;
            this.cbPinB2.Location = new System.Drawing.Point(240, 66);
            this.cbPinB2.Name = "cbPinB2";
            this.cbPinB2.Size = new System.Drawing.Size(32, 17);
            this.cbPinB2.TabIndex = 26;
            this.cbPinB2.Text = "2";
            this.cbPinB2.UseVisualStyleBackColor = true;
            // 
            // cbPinB1
            // 
            this.cbPinB1.AutoSize = true;
            this.cbPinB1.Location = new System.Drawing.Point(279, 66);
            this.cbPinB1.Name = "cbPinB1";
            this.cbPinB1.Size = new System.Drawing.Size(32, 17);
            this.cbPinB1.TabIndex = 25;
            this.cbPinB1.Text = "1";
            this.cbPinB1.UseVisualStyleBackColor = true;
            // 
            // cbPinB0
            // 
            this.cbPinB0.AutoSize = true;
            this.cbPinB0.Location = new System.Drawing.Point(318, 66);
            this.cbPinB0.Name = "cbPinB0";
            this.cbPinB0.Size = new System.Drawing.Size(32, 17);
            this.cbPinB0.TabIndex = 24;
            this.cbPinB0.Text = "0";
            this.cbPinB0.UseVisualStyleBackColor = true;
            // 
            // cbTrisB0
            // 
            this.cbTrisB0.AutoSize = true;
            this.cbTrisB0.Enabled = false;
            this.cbTrisB0.Location = new System.Drawing.Point(318, 26);
            this.cbTrisB0.Name = "cbTrisB0";
            this.cbTrisB0.Size = new System.Drawing.Size(32, 17);
            this.cbTrisB0.TabIndex = 23;
            this.cbTrisB0.Text = "0";
            this.cbTrisB0.UseVisualStyleBackColor = true;
            // 
            // cbTrisB1
            // 
            this.cbTrisB1.AutoSize = true;
            this.cbTrisB1.Enabled = false;
            this.cbTrisB1.Location = new System.Drawing.Point(279, 26);
            this.cbTrisB1.Name = "cbTrisB1";
            this.cbTrisB1.Size = new System.Drawing.Size(32, 17);
            this.cbTrisB1.TabIndex = 22;
            this.cbTrisB1.Text = "1";
            this.cbTrisB1.UseVisualStyleBackColor = true;
            // 
            // cbTrisB2
            // 
            this.cbTrisB2.AutoSize = true;
            this.cbTrisB2.Enabled = false;
            this.cbTrisB2.Location = new System.Drawing.Point(240, 26);
            this.cbTrisB2.Name = "cbTrisB2";
            this.cbTrisB2.Size = new System.Drawing.Size(32, 17);
            this.cbTrisB2.TabIndex = 21;
            this.cbTrisB2.Text = "2";
            this.cbTrisB2.UseVisualStyleBackColor = true;
            // 
            // cbTrisB3
            // 
            this.cbTrisB3.AutoSize = true;
            this.cbTrisB3.Enabled = false;
            this.cbTrisB3.Location = new System.Drawing.Point(201, 26);
            this.cbTrisB3.Name = "cbTrisB3";
            this.cbTrisB3.Size = new System.Drawing.Size(32, 17);
            this.cbTrisB3.TabIndex = 20;
            this.cbTrisB3.Text = "3";
            this.cbTrisB3.UseVisualStyleBackColor = true;
            // 
            // cbTrisB4
            // 
            this.cbTrisB4.AutoSize = true;
            this.cbTrisB4.Enabled = false;
            this.cbTrisB4.Location = new System.Drawing.Point(162, 26);
            this.cbTrisB4.Name = "cbTrisB4";
            this.cbTrisB4.Size = new System.Drawing.Size(32, 17);
            this.cbTrisB4.TabIndex = 19;
            this.cbTrisB4.Text = "4";
            this.cbTrisB4.UseVisualStyleBackColor = true;
            // 
            // cbTrisB5
            // 
            this.cbTrisB5.AutoSize = true;
            this.cbTrisB5.Enabled = false;
            this.cbTrisB5.Location = new System.Drawing.Point(123, 25);
            this.cbTrisB5.Name = "cbTrisB5";
            this.cbTrisB5.Size = new System.Drawing.Size(32, 17);
            this.cbTrisB5.TabIndex = 18;
            this.cbTrisB5.Text = "5";
            this.cbTrisB5.UseVisualStyleBackColor = true;
            // 
            // cbTrisB6
            // 
            this.cbTrisB6.AutoSize = true;
            this.cbTrisB6.Enabled = false;
            this.cbTrisB6.Location = new System.Drawing.Point(84, 25);
            this.cbTrisB6.Name = "cbTrisB6";
            this.cbTrisB6.Size = new System.Drawing.Size(32, 17);
            this.cbTrisB6.TabIndex = 17;
            this.cbTrisB6.Text = "6";
            this.cbTrisB6.UseVisualStyleBackColor = true;
            // 
            // cbTrisB7
            // 
            this.cbTrisB7.AutoSize = true;
            this.cbTrisB7.Enabled = false;
            this.cbTrisB7.Location = new System.Drawing.Point(46, 26);
            this.cbTrisB7.Name = "cbTrisB7";
            this.cbTrisB7.Size = new System.Drawing.Size(32, 17);
            this.cbTrisB7.TabIndex = 16;
            this.cbTrisB7.Text = "7";
            this.cbTrisB7.UseVisualStyleBackColor = true;
            // 
            // lblPinB
            // 
            this.lblPinB.AutoSize = true;
            this.lblPinB.Location = new System.Drawing.Point(7, 71);
            this.lblPinB.Name = "lblPinB";
            this.lblPinB.Size = new System.Drawing.Size(22, 13);
            this.lblPinB.TabIndex = 15;
            this.lblPinB.Text = "Pin";
            // 
            // lblTrisB
            // 
            this.lblTrisB.AutoSize = true;
            this.lblTrisB.Location = new System.Drawing.Point(7, 26);
            this.lblTrisB.Name = "lblTrisB";
            this.lblTrisB.Size = new System.Drawing.Size(24, 13);
            this.lblTrisB.TabIndex = 14;
            this.lblTrisB.Text = "Tris";
            // 
            // gBTiming
            // 
            this.gBTiming.Controls.Add(this.lblWatchdog);
            this.gBTiming.Controls.Add(this.lblWatchdogText);
            this.gBTiming.Controls.Add(this.cbWatchdog);
            this.gBTiming.Controls.Add(this.cbQuarz);
            this.gBTiming.Controls.Add(this.lblQuarz);
            this.gBTiming.Controls.Add(this.lblLaufzeitMyh);
            this.gBTiming.Controls.Add(this.lblLaufzeit);
            this.gBTiming.Controls.Add(this.lblLaufzeitText);
            this.gBTiming.Location = new System.Drawing.Point(448, 223);
            this.gBTiming.Name = "gBTiming";
            this.gBTiming.Size = new System.Drawing.Size(340, 80);
            this.gBTiming.TabIndex = 6;
            this.gBTiming.TabStop = false;
            this.gBTiming.Text = "Timing";
            this.gBTiming.Enter += new System.EventHandler(this.gBTiming_Enter);
            // 
            // lblWatchdog
            // 
            this.lblWatchdog.AutoSize = true;
            this.lblWatchdog.Location = new System.Drawing.Point(281, 52);
            this.lblWatchdog.Name = "lblWatchdog";
            this.lblWatchdog.Size = new System.Drawing.Size(19, 13);
            this.lblWatchdog.TabIndex = 7;
            this.lblWatchdog.Text = "00";
            // 
            // lblWatchdogText
            // 
            this.lblWatchdogText.AutoSize = true;
            this.lblWatchdogText.Location = new System.Drawing.Point(214, 52);
            this.lblWatchdogText.Name = "lblWatchdogText";
            this.lblWatchdogText.Size = new System.Drawing.Size(60, 13);
            this.lblWatchdogText.TabIndex = 6;
            this.lblWatchdogText.Text = "Watchdog:";
            // 
            // cbWatchdog
            // 
            this.cbWatchdog.AutoSize = true;
            this.cbWatchdog.Location = new System.Drawing.Point(214, 18);
            this.cbWatchdog.Name = "cbWatchdog";
            this.cbWatchdog.Size = new System.Drawing.Size(120, 17);
            this.cbWatchdog.TabIndex = 5;
            this.cbWatchdog.Text = "Freigabe Watchdog";
            this.cbWatchdog.UseVisualStyleBackColor = true;
            // 
            // cbQuarz
            // 
            this.cbQuarz.Items.AddRange(new object[] {
            "64 kHz",
            "1 MHz",
            "10 MHz"});
            this.cbQuarz.Location = new System.Drawing.Point(78, 43);
            this.cbQuarz.Name = "cbQuarz";
            this.cbQuarz.Size = new System.Drawing.Size(121, 21);
            this.cbQuarz.TabIndex = 4;
            this.cbQuarz.Text = "32 kHz";
            // 
            // lblQuarz
            // 
            this.lblQuarz.AutoSize = true;
            this.lblQuarz.Location = new System.Drawing.Point(7, 46);
            this.lblQuarz.Name = "lblQuarz";
            this.lblQuarz.Size = new System.Drawing.Size(38, 13);
            this.lblQuarz.TabIndex = 3;
            this.lblQuarz.Text = "Quarz:";
            // 
            // lblLaufzeitMyh
            // 
            this.lblLaufzeitMyh.AutoSize = true;
            this.lblLaufzeitMyh.Location = new System.Drawing.Point(183, 20);
            this.lblLaufzeitMyh.Name = "lblLaufzeitMyh";
            this.lblLaufzeitMyh.Size = new System.Drawing.Size(13, 13);
            this.lblLaufzeitMyh.TabIndex = 2;
            this.lblLaufzeitMyh.Text = "µ";
            // 
            // lblLaufzeit
            // 
            this.lblLaufzeit.AutoSize = true;
            this.lblLaufzeit.Location = new System.Drawing.Point(78, 20);
            this.lblLaufzeit.Name = "lblLaufzeit";
            this.lblLaufzeit.Size = new System.Drawing.Size(13, 13);
            this.lblLaufzeit.TabIndex = 1;
            this.lblLaufzeit.Text = "0";
            // 
            // lblLaufzeitText
            // 
            this.lblLaufzeitText.AutoSize = true;
            this.lblLaufzeitText.Location = new System.Drawing.Point(7, 20);
            this.lblLaufzeitText.Name = "lblLaufzeitText";
            this.lblLaufzeitText.Size = new System.Drawing.Size(47, 13);
            this.lblLaufzeitText.TabIndex = 0;
            this.lblLaufzeitText.Text = "Laufzeit:";
            // 
            // gbStack
            // 
            this.gbStack.Controls.Add(this.lblStack8);
            this.gbStack.Controls.Add(this.lblStack6);
            this.gbStack.Controls.Add(this.lblStack7);
            this.gbStack.Controls.Add(this.lblStack5);
            this.gbStack.Controls.Add(this.lblStack4);
            this.gbStack.Controls.Add(this.lblStack3);
            this.gbStack.Controls.Add(this.lblStack2);
            this.gbStack.Controls.Add(this.lblStack1);
            this.gbStack.Location = new System.Drawing.Point(576, 45);
            this.gbStack.Name = "gbStack";
            this.gbStack.Size = new System.Drawing.Size(68, 160);
            this.gbStack.TabIndex = 7;
            this.gbStack.TabStop = false;
            this.gbStack.Text = "Stack";
            // 
            // lblStack8
            // 
            this.lblStack8.AutoSize = true;
            this.lblStack8.Location = new System.Drawing.Point(17, 122);
            this.lblStack8.Name = "lblStack8";
            this.lblStack8.Size = new System.Drawing.Size(31, 13);
            this.lblStack8.TabIndex = 7;
            this.lblStack8.Text = "0008";
            // 
            // lblStack6
            // 
            this.lblStack6.AutoSize = true;
            this.lblStack6.Location = new System.Drawing.Point(17, 96);
            this.lblStack6.Name = "lblStack6";
            this.lblStack6.Size = new System.Drawing.Size(31, 13);
            this.lblStack6.TabIndex = 6;
            this.lblStack6.Text = "0006";
            // 
            // lblStack7
            // 
            this.lblStack7.AutoSize = true;
            this.lblStack7.Location = new System.Drawing.Point(17, 109);
            this.lblStack7.Name = "lblStack7";
            this.lblStack7.Size = new System.Drawing.Size(31, 13);
            this.lblStack7.TabIndex = 5;
            this.lblStack7.Text = "0007";
            // 
            // lblStack5
            // 
            this.lblStack5.AutoSize = true;
            this.lblStack5.Location = new System.Drawing.Point(17, 83);
            this.lblStack5.Name = "lblStack5";
            this.lblStack5.Size = new System.Drawing.Size(31, 13);
            this.lblStack5.TabIndex = 4;
            this.lblStack5.Text = "0005";
            // 
            // lblStack4
            // 
            this.lblStack4.AutoSize = true;
            this.lblStack4.Location = new System.Drawing.Point(17, 70);
            this.lblStack4.Name = "lblStack4";
            this.lblStack4.Size = new System.Drawing.Size(31, 13);
            this.lblStack4.TabIndex = 3;
            this.lblStack4.Text = "0004";
            // 
            // lblStack3
            // 
            this.lblStack3.AutoSize = true;
            this.lblStack3.Location = new System.Drawing.Point(17, 57);
            this.lblStack3.Name = "lblStack3";
            this.lblStack3.Size = new System.Drawing.Size(31, 13);
            this.lblStack3.TabIndex = 2;
            this.lblStack3.Text = "0003";
            // 
            // lblStack2
            // 
            this.lblStack2.AutoSize = true;
            this.lblStack2.Location = new System.Drawing.Point(17, 44);
            this.lblStack2.Name = "lblStack2";
            this.lblStack2.Size = new System.Drawing.Size(31, 13);
            this.lblStack2.TabIndex = 1;
            this.lblStack2.Text = "0002";
            // 
            // lblStack1
            // 
            this.lblStack1.AutoSize = true;
            this.lblStack1.Location = new System.Drawing.Point(17, 31);
            this.lblStack1.Name = "lblStack1";
            this.lblStack1.Size = new System.Drawing.Size(31, 13);
            this.lblStack1.TabIndex = 0;
            this.lblStack1.Text = "0001";
            // 
            // gbSFR
            // 
            this.gbSFR.Controls.Add(this.lblRIF);
            this.gbSFR.Controls.Add(this.lblIF);
            this.gbSFR.Controls.Add(this.lblTIF);
            this.gbSFR.Controls.Add(this.lblRIE);
            this.gbSFR.Controls.Add(this.lblIE);
            this.gbSFR.Controls.Add(this.lblTIE);
            this.gbSFR.Controls.Add(this.lblEIE);
            this.gbSFR.Controls.Add(this.lblGIE);
            this.gbSFR.Controls.Add(this.lblRIFText);
            this.gbSFR.Controls.Add(this.lblIFText);
            this.gbSFR.Controls.Add(this.lblTIFText);
            this.gbSFR.Controls.Add(this.lblRIEText);
            this.gbSFR.Controls.Add(this.lblIEText);
            this.gbSFR.Controls.Add(this.lblTIEText);
            this.gbSFR.Controls.Add(this.lblEIEText);
            this.gbSFR.Controls.Add(this.lblGIEText);
            this.gbSFR.Controls.Add(this.lblIntcon);
            this.gbSFR.Controls.Add(this.lblPS0);
            this.gbSFR.Controls.Add(this.lblPS1);
            this.gbSFR.Controls.Add(this.lblPS2);
            this.gbSFR.Controls.Add(this.lblPSA);
            this.gbSFR.Controls.Add(this.lblTSe);
            this.gbSFR.Controls.Add(this.lblTCs);
            this.gbSFR.Controls.Add(this.lblIEg);
            this.gbSFR.Controls.Add(this.lblRPu);
            this.gbSFR.Controls.Add(this.lblPS0Text);
            this.gbSFR.Controls.Add(this.lblPS1Text);
            this.gbSFR.Controls.Add(this.lblPS2Text);
            this.gbSFR.Controls.Add(this.lblPSAText);
            this.gbSFR.Controls.Add(this.lblTSeText);
            this.gbSFR.Controls.Add(this.lblTCsText);
            this.gbSFR.Controls.Add(this.lblIEgText);
            this.gbSFR.Controls.Add(this.lblRPuText);
            this.gbSFR.Controls.Add(this.lblOptionText2);
            this.gbSFR.Controls.Add(this.lblC);
            this.gbSFR.Controls.Add(this.lblDC);
            this.gbSFR.Controls.Add(this.lblZ);
            this.gbSFR.Controls.Add(this.lblPD);
            this.gbSFR.Controls.Add(this.lblTO);
            this.gbSFR.Controls.Add(this.lblRP0);
            this.gbSFR.Controls.Add(this.lblRP1);
            this.gbSFR.Controls.Add(this.lblIRP);
            this.gbSFR.Controls.Add(this.lblCText);
            this.gbSFR.Controls.Add(this.lblDCText);
            this.gbSFR.Controls.Add(this.lblZText);
            this.gbSFR.Controls.Add(this.lblPDText);
            this.gbSFR.Controls.Add(this.lblTOText);
            this.gbSFR.Controls.Add(this.lblRP0Text);
            this.gbSFR.Controls.Add(this.lblRP1Text);
            this.gbSFR.Controls.Add(this.lblIRPText);
            this.gbSFR.Controls.Add(this.lblStatusText);
            this.gbSFR.Location = new System.Drawing.Point(250, 45);
            this.gbSFR.Name = "gbSFR";
            this.gbSFR.Size = new System.Drawing.Size(311, 160);
            this.gbSFR.TabIndex = 8;
            this.gbSFR.TabStop = false;
            this.gbSFR.Text = "SFR (Bit)";
            // 
            // lblRIF
            // 
            this.lblRIF.AutoSize = true;
            this.lblRIF.Location = new System.Drawing.Point(265, 126);
            this.lblRIF.Name = "lblRIF";
            this.lblRIF.Size = new System.Drawing.Size(13, 13);
            this.lblRIF.TabIndex = 50;
            this.lblRIF.Text = "0";
            // 
            // lblIF
            // 
            this.lblIF.AutoSize = true;
            this.lblIF.Location = new System.Drawing.Point(237, 126);
            this.lblIF.Name = "lblIF";
            this.lblIF.Size = new System.Drawing.Size(13, 13);
            this.lblIF.TabIndex = 49;
            this.lblIF.Text = "0";
            // 
            // lblTIF
            // 
            this.lblTIF.AutoSize = true;
            this.lblTIF.Location = new System.Drawing.Point(212, 126);
            this.lblTIF.Name = "lblTIF";
            this.lblTIF.Size = new System.Drawing.Size(13, 13);
            this.lblTIF.TabIndex = 48;
            this.lblTIF.Text = "0";
            // 
            // lblRIE
            // 
            this.lblRIE.AutoSize = true;
            this.lblRIE.Location = new System.Drawing.Point(184, 126);
            this.lblRIE.Name = "lblRIE";
            this.lblRIE.Size = new System.Drawing.Size(13, 13);
            this.lblRIE.TabIndex = 47;
            this.lblRIE.Text = "0";
            // 
            // lblIE
            // 
            this.lblIE.AutoSize = true;
            this.lblIE.Location = new System.Drawing.Point(150, 126);
            this.lblIE.Name = "lblIE";
            this.lblIE.Size = new System.Drawing.Size(13, 13);
            this.lblIE.TabIndex = 46;
            this.lblIE.Text = "0";
            // 
            // lblTIE
            // 
            this.lblTIE.AutoSize = true;
            this.lblTIE.Location = new System.Drawing.Point(115, 126);
            this.lblTIE.Name = "lblTIE";
            this.lblTIE.Size = new System.Drawing.Size(13, 13);
            this.lblTIE.TabIndex = 45;
            this.lblTIE.Text = "0";
            // 
            // lblEIE
            // 
            this.lblEIE.AutoSize = true;
            this.lblEIE.Location = new System.Drawing.Point(80, 126);
            this.lblEIE.Name = "lblEIE";
            this.lblEIE.Size = new System.Drawing.Size(13, 13);
            this.lblEIE.TabIndex = 44;
            this.lblEIE.Text = "0";
            // 
            // lblGIE
            // 
            this.lblGIE.AutoSize = true;
            this.lblGIE.Location = new System.Drawing.Point(48, 126);
            this.lblGIE.Name = "lblGIE";
            this.lblGIE.Size = new System.Drawing.Size(13, 13);
            this.lblGIE.TabIndex = 43;
            this.lblGIE.Text = "0";
            // 
            // lblRIFText
            // 
            this.lblRIFText.AutoSize = true;
            this.lblRIFText.Location = new System.Drawing.Point(260, 109);
            this.lblRIFText.Name = "lblRIFText";
            this.lblRIFText.Size = new System.Drawing.Size(31, 13);
            this.lblRIFText.TabIndex = 42;
            this.lblRIFText.Text = "RBIF";
            // 
            // lblIFText
            // 
            this.lblIFText.AutoSize = true;
            this.lblIFText.Location = new System.Drawing.Point(231, 109);
            this.lblIFText.Name = "lblIFText";
            this.lblIFText.Size = new System.Drawing.Size(31, 13);
            this.lblIFText.TabIndex = 41;
            this.lblIFText.Text = "INTF";
            // 
            // lblTIFText
            // 
            this.lblTIFText.AutoSize = true;
            this.lblTIFText.Location = new System.Drawing.Point(207, 109);
            this.lblTIFText.Name = "lblTIFText";
            this.lblTIFText.Size = new System.Drawing.Size(29, 13);
            this.lblTIFText.TabIndex = 40;
            this.lblTIFText.Text = "T0IF";
            // 
            // lblRIEText
            // 
            this.lblRIEText.AutoSize = true;
            this.lblRIEText.Location = new System.Drawing.Point(175, 109);
            this.lblRIEText.Name = "lblRIEText";
            this.lblRIEText.Size = new System.Drawing.Size(32, 13);
            this.lblRIEText.TabIndex = 39;
            this.lblRIEText.Text = "RBIE";
            // 
            // lblIEText
            // 
            this.lblIEText.AutoSize = true;
            this.lblIEText.Location = new System.Drawing.Point(142, 109);
            this.lblIEText.Name = "lblIEText";
            this.lblIEText.Size = new System.Drawing.Size(35, 13);
            this.lblIEText.TabIndex = 38;
            this.lblIEText.Text = "INTIE";
            // 
            // lblTIEText
            // 
            this.lblTIEText.AutoSize = true;
            this.lblTIEText.Location = new System.Drawing.Point(108, 109);
            this.lblTIEText.Name = "lblTIEText";
            this.lblTIEText.Size = new System.Drawing.Size(30, 13);
            this.lblTIEText.TabIndex = 37;
            this.lblTIEText.Text = "T0IE";
            // 
            // lblEIEText
            // 
            this.lblEIEText.AutoSize = true;
            this.lblEIEText.Location = new System.Drawing.Point(72, 109);
            this.lblEIEText.Name = "lblEIEText";
            this.lblEIEText.Size = new System.Drawing.Size(31, 13);
            this.lblEIEText.TabIndex = 36;
            this.lblEIEText.Text = "EEIE";
            // 
            // lblGIEText
            // 
            this.lblGIEText.AutoSize = true;
            this.lblGIEText.Location = new System.Drawing.Point(45, 109);
            this.lblGIEText.Name = "lblGIEText";
            this.lblGIEText.Size = new System.Drawing.Size(25, 13);
            this.lblGIEText.TabIndex = 35;
            this.lblGIEText.Text = "GIE";
            // 
            // lblIntcon
            // 
            this.lblIntcon.AutoSize = true;
            this.lblIntcon.Location = new System.Drawing.Point(6, 109);
            this.lblIntcon.Name = "lblIntcon";
            this.lblIntcon.Size = new System.Drawing.Size(40, 13);
            this.lblIntcon.TabIndex = 34;
            this.lblIntcon.Text = "Intcon:";
            // 
            // lblPS0
            // 
            this.lblPS0.AutoSize = true;
            this.lblPS0.Location = new System.Drawing.Point(265, 83);
            this.lblPS0.Name = "lblPS0";
            this.lblPS0.Size = new System.Drawing.Size(13, 13);
            this.lblPS0.TabIndex = 33;
            this.lblPS0.Text = "0";
            // 
            // lblPS1
            // 
            this.lblPS1.AutoSize = true;
            this.lblPS1.Location = new System.Drawing.Point(237, 83);
            this.lblPS1.Name = "lblPS1";
            this.lblPS1.Size = new System.Drawing.Size(13, 13);
            this.lblPS1.TabIndex = 32;
            this.lblPS1.Text = "0";
            // 
            // lblPS2
            // 
            this.lblPS2.AutoSize = true;
            this.lblPS2.Location = new System.Drawing.Point(212, 83);
            this.lblPS2.Name = "lblPS2";
            this.lblPS2.Size = new System.Drawing.Size(13, 13);
            this.lblPS2.TabIndex = 31;
            this.lblPS2.Text = "0";
            // 
            // lblPSA
            // 
            this.lblPSA.AutoSize = true;
            this.lblPSA.Location = new System.Drawing.Point(184, 83);
            this.lblPSA.Name = "lblPSA";
            this.lblPSA.Size = new System.Drawing.Size(13, 13);
            this.lblPSA.TabIndex = 30;
            this.lblPSA.Text = "0";
            // 
            // lblTSe
            // 
            this.lblTSe.AutoSize = true;
            this.lblTSe.Location = new System.Drawing.Point(150, 83);
            this.lblTSe.Name = "lblTSe";
            this.lblTSe.Size = new System.Drawing.Size(13, 13);
            this.lblTSe.TabIndex = 29;
            this.lblTSe.Text = "0";
            // 
            // lblTCs
            // 
            this.lblTCs.AutoSize = true;
            this.lblTCs.Location = new System.Drawing.Point(115, 83);
            this.lblTCs.Name = "lblTCs";
            this.lblTCs.Size = new System.Drawing.Size(13, 13);
            this.lblTCs.TabIndex = 28;
            this.lblTCs.Text = "0";
            // 
            // lblIEg
            // 
            this.lblIEg.AutoSize = true;
            this.lblIEg.Location = new System.Drawing.Point(80, 83);
            this.lblIEg.Name = "lblIEg";
            this.lblIEg.Size = new System.Drawing.Size(13, 13);
            this.lblIEg.TabIndex = 27;
            this.lblIEg.Text = "0";
            // 
            // lblRPu
            // 
            this.lblRPu.AutoSize = true;
            this.lblRPu.Location = new System.Drawing.Point(48, 83);
            this.lblRPu.Name = "lblRPu";
            this.lblRPu.Size = new System.Drawing.Size(13, 13);
            this.lblRPu.TabIndex = 26;
            this.lblRPu.Text = "0";
            // 
            // lblPS0Text
            // 
            this.lblPS0Text.AutoSize = true;
            this.lblPS0Text.Location = new System.Drawing.Point(265, 66);
            this.lblPS0Text.Name = "lblPS0Text";
            this.lblPS0Text.Size = new System.Drawing.Size(27, 13);
            this.lblPS0Text.TabIndex = 25;
            this.lblPS0Text.Text = "PS0";
            // 
            // lblPS1Text
            // 
            this.lblPS1Text.AutoSize = true;
            this.lblPS1Text.Location = new System.Drawing.Point(236, 66);
            this.lblPS1Text.Name = "lblPS1Text";
            this.lblPS1Text.Size = new System.Drawing.Size(27, 13);
            this.lblPS1Text.TabIndex = 24;
            this.lblPS1Text.Text = "PS1";
            // 
            // lblPS2Text
            // 
            this.lblPS2Text.AutoSize = true;
            this.lblPS2Text.Location = new System.Drawing.Point(212, 66);
            this.lblPS2Text.Name = "lblPS2Text";
            this.lblPS2Text.Size = new System.Drawing.Size(27, 13);
            this.lblPS2Text.TabIndex = 23;
            this.lblPS2Text.Text = "PS2";
            // 
            // lblPSAText
            // 
            this.lblPSAText.AutoSize = true;
            this.lblPSAText.Location = new System.Drawing.Point(184, 66);
            this.lblPSAText.Name = "lblPSAText";
            this.lblPSAText.Size = new System.Drawing.Size(28, 13);
            this.lblPSAText.TabIndex = 22;
            this.lblPSAText.Text = "PSA";
            // 
            // lblTSeText
            // 
            this.lblTSeText.AutoSize = true;
            this.lblTSeText.Location = new System.Drawing.Point(142, 66);
            this.lblTSeText.Name = "lblTSeText";
            this.lblTSeText.Size = new System.Drawing.Size(34, 13);
            this.lblTSeText.TabIndex = 21;
            this.lblTSeText.Text = "T0SE";
            // 
            // lblTCsText
            // 
            this.lblTCsText.AutoSize = true;
            this.lblTCsText.Location = new System.Drawing.Point(107, 66);
            this.lblTCsText.Name = "lblTCsText";
            this.lblTCsText.Size = new System.Drawing.Size(34, 13);
            this.lblTCsText.TabIndex = 20;
            this.lblTCsText.Text = "T0CS";
            // 
            // lblIEgText
            // 
            this.lblIEgText.AutoSize = true;
            this.lblIEgText.Location = new System.Drawing.Point(77, 66);
            this.lblIEgText.Name = "lblIEgText";
            this.lblIEgText.Size = new System.Drawing.Size(23, 13);
            this.lblIEgText.TabIndex = 19;
            this.lblIEgText.Text = "IEg";
            // 
            // lblRPuText
            // 
            this.lblRPuText.AutoSize = true;
            this.lblRPuText.Location = new System.Drawing.Point(45, 66);
            this.lblRPuText.Name = "lblRPuText";
            this.lblRPuText.Size = new System.Drawing.Size(28, 13);
            this.lblRPuText.TabIndex = 18;
            this.lblRPuText.Text = "RPu";
            // 
            // lblOptionText2
            // 
            this.lblOptionText2.AutoSize = true;
            this.lblOptionText2.Location = new System.Drawing.Point(6, 66);
            this.lblOptionText2.Name = "lblOptionText2";
            this.lblOptionText2.Size = new System.Drawing.Size(41, 13);
            this.lblOptionText2.TabIndex = 17;
            this.lblOptionText2.Text = "Option:";
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Location = new System.Drawing.Point(265, 37);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(13, 13);
            this.lblC.TabIndex = 16;
            this.lblC.Text = "0";
            // 
            // lblDC
            // 
            this.lblDC.AutoSize = true;
            this.lblDC.Location = new System.Drawing.Point(237, 37);
            this.lblDC.Name = "lblDC";
            this.lblDC.Size = new System.Drawing.Size(13, 13);
            this.lblDC.TabIndex = 15;
            this.lblDC.Text = "0";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(212, 37);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(13, 13);
            this.lblZ.TabIndex = 14;
            this.lblZ.Text = "0";
            // 
            // lblPD
            // 
            this.lblPD.AutoSize = true;
            this.lblPD.Location = new System.Drawing.Point(184, 37);
            this.lblPD.Name = "lblPD";
            this.lblPD.Size = new System.Drawing.Size(13, 13);
            this.lblPD.TabIndex = 13;
            this.lblPD.Text = "0";
            // 
            // lblTO
            // 
            this.lblTO.AutoSize = true;
            this.lblTO.Location = new System.Drawing.Point(150, 37);
            this.lblTO.Name = "lblTO";
            this.lblTO.Size = new System.Drawing.Size(13, 13);
            this.lblTO.TabIndex = 12;
            this.lblTO.Text = "0";
            // 
            // lblRP0
            // 
            this.lblRP0.AutoSize = true;
            this.lblRP0.Location = new System.Drawing.Point(115, 37);
            this.lblRP0.Name = "lblRP0";
            this.lblRP0.Size = new System.Drawing.Size(13, 13);
            this.lblRP0.TabIndex = 11;
            this.lblRP0.Text = "0";
            // 
            // lblRP1
            // 
            this.lblRP1.AutoSize = true;
            this.lblRP1.Location = new System.Drawing.Point(80, 37);
            this.lblRP1.Name = "lblRP1";
            this.lblRP1.Size = new System.Drawing.Size(13, 13);
            this.lblRP1.TabIndex = 10;
            this.lblRP1.Text = "0";
            // 
            // lblIRP
            // 
            this.lblIRP.AutoSize = true;
            this.lblIRP.Location = new System.Drawing.Point(48, 37);
            this.lblIRP.Name = "lblIRP";
            this.lblIRP.Size = new System.Drawing.Size(13, 13);
            this.lblIRP.TabIndex = 9;
            this.lblIRP.Text = "0";
            // 
            // lblCText
            // 
            this.lblCText.AutoSize = true;
            this.lblCText.Location = new System.Drawing.Point(265, 20);
            this.lblCText.Name = "lblCText";
            this.lblCText.Size = new System.Drawing.Size(14, 13);
            this.lblCText.TabIndex = 8;
            this.lblCText.Text = "C";
            // 
            // lblDCText
            // 
            this.lblDCText.AutoSize = true;
            this.lblDCText.Location = new System.Drawing.Point(236, 20);
            this.lblDCText.Name = "lblDCText";
            this.lblDCText.Size = new System.Drawing.Size(22, 13);
            this.lblDCText.TabIndex = 7;
            this.lblDCText.Text = "DC";
            // 
            // lblZText
            // 
            this.lblZText.AutoSize = true;
            this.lblZText.Location = new System.Drawing.Point(212, 20);
            this.lblZText.Name = "lblZText";
            this.lblZText.Size = new System.Drawing.Size(14, 13);
            this.lblZText.TabIndex = 6;
            this.lblZText.Text = "Z";
            // 
            // lblPDText
            // 
            this.lblPDText.AutoSize = true;
            this.lblPDText.Location = new System.Drawing.Point(184, 20);
            this.lblPDText.Name = "lblPDText";
            this.lblPDText.Size = new System.Drawing.Size(22, 13);
            this.lblPDText.TabIndex = 5;
            this.lblPDText.Text = "PD";
            // 
            // lblTOText
            // 
            this.lblTOText.AutoSize = true;
            this.lblTOText.Location = new System.Drawing.Point(149, 20);
            this.lblTOText.Name = "lblTOText";
            this.lblTOText.Size = new System.Drawing.Size(22, 13);
            this.lblTOText.TabIndex = 4;
            this.lblTOText.Text = "TO";
            // 
            // lblRP0Text
            // 
            this.lblRP0Text.AutoSize = true;
            this.lblRP0Text.Location = new System.Drawing.Point(115, 20);
            this.lblRP0Text.Name = "lblRP0Text";
            this.lblRP0Text.Size = new System.Drawing.Size(28, 13);
            this.lblRP0Text.TabIndex = 3;
            this.lblRP0Text.Text = "RP0";
            // 
            // lblRP1Text
            // 
            this.lblRP1Text.AutoSize = true;
            this.lblRP1Text.Location = new System.Drawing.Point(77, 20);
            this.lblRP1Text.Name = "lblRP1Text";
            this.lblRP1Text.Size = new System.Drawing.Size(31, 13);
            this.lblRP1Text.TabIndex = 2;
            this.lblRP1Text.Text = "RP1 ";
            // 
            // lblIRPText
            // 
            this.lblIRPText.AutoSize = true;
            this.lblIRPText.Location = new System.Drawing.Point(45, 20);
            this.lblIRPText.Name = "lblIRPText";
            this.lblIRPText.Size = new System.Drawing.Size(25, 13);
            this.lblIRPText.TabIndex = 1;
            this.lblIRPText.Text = "IRP";
            // 
            // lblStatusText
            // 
            this.lblStatusText.AutoSize = true;
            this.lblStatusText.Location = new System.Drawing.Point(6, 20);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(40, 13);
            this.lblStatusText.TabIndex = 0;
            this.lblStatusText.Text = "Status:";
            // 
            // gbFileregister
            // 
            this.gbFileregister.Controls.Add(this.dgvFileregister);
            this.gbFileregister.Controls.Add(this.wbPDF);
            this.gbFileregister.Location = new System.Drawing.Point(505, 326);
            this.gbFileregister.Name = "gbFileregister";
            this.gbFileregister.Size = new System.Drawing.Size(648, 416);
            this.gbFileregister.TabIndex = 9;
            this.gbFileregister.TabStop = false;
            this.gbFileregister.Text = "FileRegister";
            // 
            // dgvFileregister
            // 
            this.dgvFileregister.AllowUserToAddRows = false;
            this.dgvFileregister.AllowUserToDeleteRows = false;
            this.dgvFileregister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileregister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.spalte1,
            this.row,
            this.spalte2,
            this.spalte3,
            this.spalte4,
            this.spalte5,
            this.spalte6,
            this.spalte7,
            this.spalte8});
            this.dgvFileregister.Location = new System.Drawing.Point(10, 19);
            this.dgvFileregister.Name = "dgvFileregister";
            this.dgvFileregister.ReadOnly = true;
            this.dgvFileregister.Size = new System.Drawing.Size(629, 385);
            this.dgvFileregister.TabIndex = 10;
            // 
            // spalte1
            // 
            this.spalte1.HeaderText = "0x";
            this.spalte1.Name = "spalte1";
            this.spalte1.ReadOnly = true;
            this.spalte1.Width = 60;
            // 
            // row
            // 
            this.row.HeaderText = "+0";
            this.row.Name = "row";
            this.row.ReadOnly = true;
            this.row.Width = 60;
            // 
            // spalte2
            // 
            this.spalte2.HeaderText = "+1";
            this.spalte2.Name = "spalte2";
            this.spalte2.ReadOnly = true;
            this.spalte2.Width = 60;
            // 
            // spalte3
            // 
            this.spalte3.HeaderText = "+2";
            this.spalte3.Name = "spalte3";
            this.spalte3.ReadOnly = true;
            this.spalte3.Width = 60;
            // 
            // spalte4
            // 
            this.spalte4.HeaderText = "+3";
            this.spalte4.Name = "spalte4";
            this.spalte4.ReadOnly = true;
            this.spalte4.Width = 60;
            // 
            // spalte5
            // 
            this.spalte5.HeaderText = "+4";
            this.spalte5.Name = "spalte5";
            this.spalte5.ReadOnly = true;
            this.spalte5.Width = 60;
            // 
            // spalte6
            // 
            this.spalte6.HeaderText = "+5";
            this.spalte6.Name = "spalte6";
            this.spalte6.ReadOnly = true;
            this.spalte6.Width = 60;
            // 
            // spalte7
            // 
            this.spalte7.HeaderText = "+6";
            this.spalte7.Name = "spalte7";
            this.spalte7.ReadOnly = true;
            this.spalte7.Width = 60;
            // 
            // spalte8
            // 
            this.spalte8.HeaderText = "+7";
            this.spalte8.Name = "spalte8";
            this.spalte8.ReadOnly = true;
            this.spalte8.Width = 60;
            // 
            // wbPDF
            // 
            this.wbPDF.Location = new System.Drawing.Point(74, 130);
            this.wbPDF.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPDF.Name = "wbPDF";
            this.wbPDF.Size = new System.Drawing.Size(112, 20);
            this.wbPDF.TabIndex = 10;
            // 
            // gbFileregBearbeiten
            // 
            this.gbFileregBearbeiten.Controls.Add(this.btnUpdateFile);
            this.gbFileregBearbeiten.Controls.Add(this.tbWert);
            this.gbFileregBearbeiten.Controls.Add(this.lblWert);
            this.gbFileregBearbeiten.Controls.Add(this.tbSpeicherstelle);
            this.gbFileregBearbeiten.Controls.Add(this.lblSpeicherstelle);
            this.gbFileregBearbeiten.Location = new System.Drawing.Point(795, 282);
            this.gbFileregBearbeiten.Name = "gbFileregBearbeiten";
            this.gbFileregBearbeiten.Size = new System.Drawing.Size(351, 45);
            this.gbFileregBearbeiten.TabIndex = 10;
            this.gbFileregBearbeiten.TabStop = false;
            this.gbFileregBearbeiten.Text = "Fileregister bearbeiten";
            // 
            // lblSpeicherstelle
            // 
            this.lblSpeicherstelle.AutoSize = true;
            this.lblSpeicherstelle.Location = new System.Drawing.Point(7, 23);
            this.lblSpeicherstelle.Name = "lblSpeicherstelle";
            this.lblSpeicherstelle.Size = new System.Drawing.Size(101, 13);
            this.lblSpeicherstelle.TabIndex = 0;
            this.lblSpeicherstelle.Text = "HEX Speicherstelle:";
            // 
            // tbSpeicherstelle
            // 
            this.tbSpeicherstelle.Location = new System.Drawing.Point(106, 20);
            this.tbSpeicherstelle.Name = "tbSpeicherstelle";
            this.tbSpeicherstelle.Size = new System.Drawing.Size(48, 20);
            this.tbSpeicherstelle.TabIndex = 1;
            // 
            // lblWert
            // 
            this.lblWert.AutoSize = true;
            this.lblWert.Location = new System.Drawing.Point(159, 23);
            this.lblWert.Name = "lblWert";
            this.lblWert.Size = new System.Drawing.Size(61, 13);
            this.lblWert.TabIndex = 2;
            this.lblWert.Text = "HEX Wert: ";
            // 
            // tbWert
            // 
            this.tbWert.Location = new System.Drawing.Point(225, 19);
            this.tbWert.Name = "tbWert";
            this.tbWert.Size = new System.Drawing.Size(46, 20);
            this.tbWert.TabIndex = 3;
            // 
            // btnUpdateFile
            // 
            this.btnUpdateFile.Location = new System.Drawing.Point(278, 16);
            this.btnUpdateFile.Name = "btnUpdateFile";
            this.btnUpdateFile.Size = new System.Drawing.Size(68, 23);
            this.btnUpdateFile.TabIndex = 4;
            this.btnUpdateFile.Text = "Speichern";
            this.btnUpdateFile.UseVisualStyleBackColor = true;
            this.btnUpdateFile.Click += new System.EventHandler(this.btnUpdateFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 751);
            this.Controls.Add(this.gbFileregBearbeiten);
            this.Controls.Add(this.gBTiming);
            this.Controls.Add(this.gbFileregister);
            this.Controls.Add(this.gbSFR);
            this.Controls.Add(this.gbStack);
            this.Controls.Add(this.gbPortB);
            this.Controls.Add(this.gbPortA);
            this.Controls.Add(this.gpRegister);
            this.Controls.Add(this.gpBedienung);
            this.Controls.Add(this.gBLST);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gBLST.ResumeLayout(false);
            this.gpBedienung.ResumeLayout(false);
            this.gpRegister.ResumeLayout(false);
            this.gpRegister.PerformLayout();
            this.gbPortA.ResumeLayout(false);
            this.gbPortA.PerformLayout();
            this.gbPortB.ResumeLayout(false);
            this.gbPortB.PerformLayout();
            this.gBTiming.ResumeLayout(false);
            this.gBTiming.PerformLayout();
            this.gbStack.ResumeLayout(false);
            this.gbStack.PerformLayout();
            this.gbSFR.ResumeLayout(false);
            this.gbSFR.PerformLayout();
            this.gbFileregister.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileregister)).EndInit();
            this.gbFileregBearbeiten.ResumeLayout(false);
            this.gbFileregBearbeiten.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schließenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.GroupBox gBLST;
        private System.Windows.Forms.ToolStripMenuItem aufgabenstellungToolStripMenuItem;
        private System.Windows.Forms.GroupBox gpBedienung;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStopp;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEinzelschritt;
        private System.Windows.Forms.GroupBox gpRegister;
        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.Label lblOptionText1;
        private System.Windows.Forms.Label lblFSR;
        private System.Windows.Forms.Label lblFSRText;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusText2;
        private System.Windows.Forms.Label lblPCIntern;
        private System.Windows.Forms.Label lblPCInternText;
        private System.Windows.Forms.Label lblPCLATCH;
        private System.Windows.Forms.Label lblPCLATCHText;
        private System.Windows.Forms.Label lblPCL;
        private System.Windows.Forms.Label lblPCLText;
        private System.Windows.Forms.Label lblWReg;
        private System.Windows.Forms.Label lblWRegText;
        private System.ComponentModel.BackgroundWorker GuiThread;
        private System.Windows.Forms.GroupBox gbPortA;
        private System.Windows.Forms.CheckBox cbPinA3;
        private System.Windows.Forms.CheckBox cbPinA2;
        private System.Windows.Forms.CheckBox cbPinA1;
        private System.Windows.Forms.CheckBox cbPinA0;
        private System.Windows.Forms.CheckBox cbTrisA0;
        private System.Windows.Forms.CheckBox cbTrisA1;
        private System.Windows.Forms.CheckBox cbTrisA2;
        private System.Windows.Forms.CheckBox cbTrisA3;
        private System.Windows.Forms.CheckBox cbTrisA4;
        private System.Windows.Forms.CheckBox cbTrisA5;
        private System.Windows.Forms.CheckBox cbTrisA6;
        private System.Windows.Forms.CheckBox cbTrisA7;
        private System.Windows.Forms.Label lblPinA;
        private System.Windows.Forms.Label lblTrisA;
        private System.Windows.Forms.GroupBox gbPortB;
        private System.Windows.Forms.CheckBox cbPinB7;
        private System.Windows.Forms.CheckBox cbPinB6;
        private System.Windows.Forms.CheckBox cbPinB5;
        private System.Windows.Forms.CheckBox cbPinB4;
        private System.Windows.Forms.CheckBox cbPinB3;
        private System.Windows.Forms.CheckBox cbPinB2;
        private System.Windows.Forms.CheckBox cbPinB1;
        private System.Windows.Forms.CheckBox cbPinB0;
        private System.Windows.Forms.CheckBox cbTrisB0;
        private System.Windows.Forms.CheckBox cbTrisB1;
        private System.Windows.Forms.CheckBox cbTrisB2;
        private System.Windows.Forms.CheckBox cbTrisB3;
        private System.Windows.Forms.CheckBox cbTrisB4;
        private System.Windows.Forms.CheckBox cbTrisB5;
        private System.Windows.Forms.CheckBox cbTrisB6;
        private System.Windows.Forms.CheckBox cbTrisB7;
        private System.Windows.Forms.Label lblPinB;
        private System.Windows.Forms.Label lblTrisB;
        private System.Windows.Forms.GroupBox gBTiming;
        private System.Windows.Forms.Label lblLaufzeitMyh;
        private System.Windows.Forms.Label lblLaufzeit;
        private System.Windows.Forms.Label lblLaufzeitText;
        private System.Windows.Forms.ComboBox cbQuarz;
        private System.Windows.Forms.Label lblQuarz;
        private System.Windows.Forms.Label lblWatchdog;
        private System.Windows.Forms.Label lblWatchdogText;
        private System.Windows.Forms.CheckBox cbWatchdog;
        private System.Windows.Forms.GroupBox gbStack;
        private System.Windows.Forms.GroupBox gbSFR;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.Label lblRIF;
        private System.Windows.Forms.Label lblIF;
        private System.Windows.Forms.Label lblTIF;
        private System.Windows.Forms.Label lblRIE;
        private System.Windows.Forms.Label lblIE;
        private System.Windows.Forms.Label lblTIE;
        private System.Windows.Forms.Label lblEIE;
        private System.Windows.Forms.Label lblGIE;
        private System.Windows.Forms.Label lblRIFText;
        private System.Windows.Forms.Label lblIFText;
        private System.Windows.Forms.Label lblTIFText;
        private System.Windows.Forms.Label lblRIEText;
        private System.Windows.Forms.Label lblIEText;
        private System.Windows.Forms.Label lblTIEText;
        private System.Windows.Forms.Label lblEIEText;
        private System.Windows.Forms.Label lblGIEText;
        private System.Windows.Forms.Label lblIntcon;
        private System.Windows.Forms.Label lblPS0;
        private System.Windows.Forms.Label lblPS1;
        private System.Windows.Forms.Label lblPS2;
        private System.Windows.Forms.Label lblPSA;
        private System.Windows.Forms.Label lblTSe;
        private System.Windows.Forms.Label lblTCs;
        private System.Windows.Forms.Label lblIEg;
        private System.Windows.Forms.Label lblRPu;
        private System.Windows.Forms.Label lblPS0Text;
        private System.Windows.Forms.Label lblPS1Text;
        private System.Windows.Forms.Label lblPS2Text;
        private System.Windows.Forms.Label lblPSAText;
        private System.Windows.Forms.Label lblTSeText;
        private System.Windows.Forms.Label lblTCsText;
        private System.Windows.Forms.Label lblIEgText;
        private System.Windows.Forms.Label lblRPuText;
        private System.Windows.Forms.Label lblOptionText2;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblDC;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblPD;
        private System.Windows.Forms.Label lblTO;
        private System.Windows.Forms.Label lblRP0;
        private System.Windows.Forms.Label lblRP1;
        private System.Windows.Forms.Label lblIRP;
        private System.Windows.Forms.Label lblCText;
        private System.Windows.Forms.Label lblDCText;
        private System.Windows.Forms.Label lblZText;
        private System.Windows.Forms.Label lblPDText;
        private System.Windows.Forms.Label lblTOText;
        private System.Windows.Forms.Label lblRP0Text;
        private System.Windows.Forms.Label lblRP1Text;
        private System.Windows.Forms.Label lblIRPText;
        private System.Windows.Forms.Label lblTimer0;
        private System.Windows.Forms.Label lblTimer0Text;
        private System.Windows.Forms.Label lblVorteiler;
        private System.Windows.Forms.Label lblVorteilerText;
        private System.Windows.Forms.ListView lvAusgabe;
        private System.Windows.Forms.ColumnHeader Programm;
        private System.Windows.Forms.GroupBox gbFileregister;
        private System.Windows.Forms.Label lblStack3;
        private System.Windows.Forms.Label lblStack2;
        private System.Windows.Forms.Label lblStack1;
        private System.Windows.Forms.Label lblStack8;
        private System.Windows.Forms.Label lblStack6;
        private System.Windows.Forms.Label lblStack7;
        private System.Windows.Forms.Label lblStack5;
        private System.Windows.Forms.Label lblStack4;
        private System.Windows.Forms.CheckBox cbPinA4;
        private System.Windows.Forms.ToolStripMenuItem bewertungsschemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datenblattToolStripMenuItem;
        private System.Windows.Forms.WebBrowser wbPDF;
        private System.Windows.Forms.ToolStripMenuItem dokuFazitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvFileregister;
        private System.Windows.Forms.DataGridViewTextBoxColumn spalte1;
        private System.Windows.Forms.DataGridViewTextBoxColumn row;
        private System.Windows.Forms.DataGridViewTextBoxColumn spalte2;
        private System.Windows.Forms.DataGridViewTextBoxColumn spalte3;
        private System.Windows.Forms.DataGridViewTextBoxColumn spalte4;
        private System.Windows.Forms.DataGridViewTextBoxColumn spalte5;
        private System.Windows.Forms.DataGridViewTextBoxColumn spalte6;
        private System.Windows.Forms.DataGridViewTextBoxColumn spalte7;
        private System.Windows.Forms.DataGridViewTextBoxColumn spalte8;
        private System.Windows.Forms.GroupBox gbFileregBearbeiten;
        private System.Windows.Forms.Button btnUpdateFile;
        private System.Windows.Forms.TextBox tbWert;
        private System.Windows.Forms.Label lblWert;
        private System.Windows.Forms.TextBox tbSpeicherstelle;
        private System.Windows.Forms.Label lblSpeicherstelle;
    }
}

