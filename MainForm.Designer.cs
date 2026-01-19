namespace BruteForceTool
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstResults = new System.Windows.Forms.ListView();
            this.columnTime = new System.Windows.Forms.ColumnHeader();
            this.columnUsername = new System.Windows.Forms.ColumnHeader();
            this.columnPassword = new System.Windows.Forms.ColumnHeader();
            this.columnStatus = new System.Windows.Forms.ColumnHeader();
            this.columnService = new System.Windows.Forms.ColumnHeader();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.lblStats = new System.Windows.Forms.Label();
            this.chkContinue = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numThreads = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.btnBrowsePassword = new System.Windows.Forms.Button();
            this.txtPasswordFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowseUsername = new System.Windows.Forms.Button();
            this.txtUsernameFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbProtocol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 60);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SSH/FTP/SFTP Brute Force Tool - Team OffSec";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gbResults);
            this.panel2.Controls.Add(this.gbSettings);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1000, 640);
            this.panel2.TabIndex = 1;
            // 
            // gbResults
            // 
            this.gbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResults.Controls.Add(this.btnExport);
            this.gbResults.Controls.Add(this.btnClearLog);
            this.gbResults.Controls.Add(this.splitContainer1);
            this.gbResults.ForeColor = System.Drawing.Color.White;
            this.gbResults.Location = new System.Drawing.Point(13, 196);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(974, 431);
            this.gbResults.TabIndex = 2;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Results";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(830, 395);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(138, 30);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export Results";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.ForeColor = System.Drawing.Color.White;
            this.btnClearLog.Location = new System.Drawing.Point(6, 395);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(138, 30);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 22);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstResults);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtLog);
            this.splitContainer1.Size = new System.Drawing.Size(962, 367);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstResults
            // 
            this.lstResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTime,
            this.columnUsername,
            this.columnPassword,
            this.columnStatus,
            this.columnService});
            this.lstResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResults.FullRowSelect = true;
            this.lstResults.GridLines = true;
            this.lstResults.Location = new System.Drawing.Point(0, 0);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(962, 200);
            this.lstResults.TabIndex = 0;
            this.lstResults.UseCompatibleStateImageBehavior = false;
            this.lstResults.View = System.Windows.Forms.View.Details;
            // 
            // columnTime
            // 
            this.columnTime.Text = "Time";
            this.columnTime.Width = 80;
            // 
            // columnUsername
            // 
            this.columnUsername.Text = "Username";
            this.columnUsername.Width = 150;
            // 
            // columnPassword
            // 
            this.columnPassword.Text = "Password";
            this.columnPassword.Width = 150;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 80;
            // 
            // columnService
            // 
            this.columnService.Text = "Service Status";
            this.columnService.Width = 120;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.ForeColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(962, 163);
            this.txtLog.TabIndex = 0;
            // 
            // gbSettings
            // 
            this.gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSettings.Controls.Add(this.lblStats);
            this.gbSettings.Controls.Add(this.chkContinue);
            this.gbSettings.Controls.Add(this.label6);
            this.gbSettings.Controls.Add(this.numThreads);
            this.gbSettings.Controls.Add(this.label5);
            this.gbSettings.Controls.Add(this.numDelay);
            this.gbSettings.Controls.Add(this.btnBrowsePassword);
            this.gbSettings.Controls.Add(this.txtPasswordFile);
            this.gbSettings.Controls.Add(this.label4);
            this.gbSettings.Controls.Add(this.btnBrowseUsername);
            this.gbSettings.Controls.Add(this.txtUsernameFile);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.cmbProtocol);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.txtTarget);
            this.gbSettings.ForeColor = System.Drawing.Color.White;
            this.gbSettings.Location = new System.Drawing.Point(13, 13);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(974, 177);
            this.gbSettings.TabIndex = 1;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Attack Settings";
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStats.ForeColor = System.Drawing.Color.Lime;
            this.lblStats.Location = new System.Drawing.Point(6, 149);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(97, 15);
            this.lblStats.TabIndex = 14;
            this.lblStats.Text = "Attempts: 0 | Success: 0";
            // 
            // chkContinue
            // 
            this.chkContinue.AutoSize = true;
            this.chkContinue.Location = new System.Drawing.Point(621, 108);
            this.chkContinue.Name = "chkContinue";
            this.chkContinue.Size = new System.Drawing.Size(166, 19);
            this.chkContinue.TabIndex = 13;
            this.chkContinue.Text = "Continue after success";
            this.chkContinue.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Threads:";
            // 
            // numThreads
            // 
            this.numThreads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numThreads.ForeColor = System.Drawing.Color.White;
            this.numThreads.Location = new System.Drawing.Point(502, 107);
            this.numThreads.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThreads.Name = "numThreads";
            this.numThreads.Size = new System.Drawing.Size(100, 23);
            this.numThreads.TabIndex = 11;
            this.numThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Delay (sec):";
            // 
            // numDelay
            // 
            this.numDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numDelay.ForeColor = System.Drawing.Color.White;
            this.numDelay.Location = new System.Drawing.Point(289, 107);
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(100, 23);
            this.numDelay.TabIndex = 9;
            // 
            // btnBrowsePassword
            // 
            this.btnBrowsePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBrowsePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowsePassword.ForeColor = System.Drawing.Color.White;
            this.btnBrowsePassword.Location = new System.Drawing.Point(893, 71);
            this.btnBrowsePassword.Name = "btnBrowsePassword";
            this.btnBrowsePassword.Size = new System.Drawing.Size(75, 23);
            this.btnBrowsePassword.TabIndex = 8;
            this.btnBrowsePassword.Text = "Browse";
            this.btnBrowsePassword.UseVisualStyleBackColor = false;
            this.btnBrowsePassword.Click += new System.EventHandler(this.btnBrowsePassword_Click);
            // 
            // txtPasswordFile
            // 
            this.txtPasswordFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPasswordFile.ForeColor = System.Drawing.Color.White;
            this.txtPasswordFile.Location = new System.Drawing.Point(100, 71);
            this.txtPasswordFile.Name = "txtPasswordFile";
            this.txtPasswordFile.Size = new System.Drawing.Size(787, 23);
            this.txtPasswordFile.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password File:";
            // 
            // btnBrowseUsername
            // 
            this.btnBrowseUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBrowseUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseUsername.ForeColor = System.Drawing.Color.White;
            this.btnBrowseUsername.Location = new System.Drawing.Point(893, 42);
            this.btnBrowseUsername.Name = "btnBrowseUsername";
            this.btnBrowseUsername.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseUsername.TabIndex = 5;
            this.btnBrowseUsername.Text = "Browse";
            this.btnBrowseUsername.UseVisualStyleBackColor = false;
            this.btnBrowseUsername.Click += new System.EventHandler(this.btnBrowseUsername_Click);
            // 
            // txtUsernameFile
            // 
            this.txtUsernameFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsernameFile.ForeColor = System.Drawing.Color.White;
            this.txtUsernameFile.Location = new System.Drawing.Point(100, 42);
            this.txtUsernameFile.Name = "txtUsernameFile";
            this.txtUsernameFile.Size = new System.Drawing.Size(787, 23);
            this.txtUsernameFile.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username File:";
            // 
            // cmbProtocol
            // 
            this.cmbProtocol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProtocol.ForeColor = System.Drawing.Color.White;
            this.cmbProtocol.FormattingEnabled = true;
            this.cmbProtocol.Location = new System.Drawing.Point(289, 13);
            this.cmbProtocol.Name = "cmbProtocol";
            this.cmbProtocol.Size = new System.Drawing.Size(121, 23);
            this.cmbProtocol.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Protocol:";
            // 
            // txtTarget
            // 
            this.txtTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTarget.ForeColor = System.Drawing.Color.White;
            this.txtTarget.Location = new System.Drawing.Point(100, 13);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.PlaceholderText = "hostname or IP address";
            this.txtTarget.Size = new System.Drawing.Size(100, 23);
            this.txtTarget.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(849, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(138, 40);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Attack";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brute Force Tool";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.gbResults.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private GroupBox gbSettings;
        private TextBox txtTarget;
        private Button btnStart;
        private ComboBox cmbProtocol;
        private Label label2;
        private Button btnBrowsePassword;
        private TextBox txtPasswordFile;
        private Label label4;
        private Button btnBrowseUsername;
        private TextBox txtUsernameFile;
        private Label label3;
        private Label label6;
        private NumericUpDown numThreads;
        private Label label5;
        private NumericUpDown numDelay;
        private GroupBox gbResults;
        private SplitContainer splitContainer1;
        private ListView lstResults;
        private ColumnHeader columnTime;
        private ColumnHeader columnUsername;
        private ColumnHeader columnPassword;
        private ColumnHeader columnStatus;
        private ColumnHeader columnService;
        private TextBox txtLog;
        private Button btnClearLog;
        private Button btnExport;
        private CheckBox chkContinue;
        private Label lblStats;
    }
}
