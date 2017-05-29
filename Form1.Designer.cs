namespace XEventHandler
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToSystemTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssSqlConn = new System.Windows.Forms.StatusStrip();
            this.tsslConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSqlHost = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPipe = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPickSession = new System.Windows.Forms.Button();
            this.lblXEventSession = new System.Windows.Forms.Label();
            this.txtXEventSession = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.grpEventsHandled = new System.Windows.Forms.GroupBox();
            this.clbEvents = new System.Windows.Forms.CheckedListBox();
            this.grpEventResponses = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cboSounds = new System.Windows.Forms.ComboBox();
            this.ckSendEmail = new System.Windows.Forms.CheckBox();
            this.ckPlaySysSound = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLastEventHandled = new System.Windows.Forms.Label();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.ssSqlConn.SuspendLayout();
            this.grpEventsHandled.SuspendLayout();
            this.grpEventResponses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(566, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToSQLToolStripMenuItem,
            this.minimizeToSystemTrayToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // connectToSQLToolStripMenuItem
            // 
            this.connectToSQLToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.connectToSQLToolStripMenuItem.Name = "connectToSQLToolStripMenuItem";
            this.connectToSQLToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.connectToSQLToolStripMenuItem.Text = "&Connect to SQL";
            this.connectToSQLToolStripMenuItem.Click += new System.EventHandler(this.connectToSQLToolStripMenuItem_Click);
            // 
            // minimizeToSystemTrayToolStripMenuItem
            // 
            this.minimizeToSystemTrayToolStripMenuItem.CheckOnClick = true;
            this.minimizeToSystemTrayToolStripMenuItem.Name = "minimizeToSystemTrayToolStripMenuItem";
            this.minimizeToSystemTrayToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.minimizeToSystemTrayToolStripMenuItem.Text = "Minimize to System Tray";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ssSqlConn
            // 
            this.ssSqlConn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslConnected,
            this.toolStripStatusLabel2,
            this.tsslSqlHost,
            this.tsslPipe,
            this.tsslLogin});
            this.ssSqlConn.Location = new System.Drawing.Point(0, 335);
            this.ssSqlConn.Name = "ssSqlConn";
            this.ssSqlConn.Size = new System.Drawing.Size(566, 22);
            this.ssSqlConn.TabIndex = 1;
            this.ssSqlConn.Text = "Testint";
            // 
            // tsslConnected
            // 
            this.tsslConnected.Name = "tsslConnected";
            this.tsslConnected.Size = new System.Drawing.Size(88, 17);
            this.tsslConnected.Text = "Not Connected";
            this.tsslConnected.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(360, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // tsslSqlHost
            // 
            this.tsslSqlHost.Name = "tsslSqlHost";
            this.tsslSqlHost.Size = new System.Drawing.Size(56, 17);
            this.tsslSqlHost.Text = "SQL Host";
            // 
            // tsslPipe
            // 
            this.tsslPipe.Name = "tsslPipe";
            this.tsslPipe.Size = new System.Drawing.Size(10, 17);
            this.tsslPipe.Text = "|";
            // 
            // tsslLogin
            // 
            this.tsslLogin.Name = "tsslLogin";
            this.tsslLogin.Size = new System.Drawing.Size(37, 17);
            this.tsslLogin.Text = "Login";
            // 
            // btnPickSession
            // 
            this.btnPickSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickSession.Location = new System.Drawing.Point(479, 42);
            this.btnPickSession.Name = "btnPickSession";
            this.btnPickSession.Size = new System.Drawing.Size(67, 23);
            this.btnPickSession.TabIndex = 2;
            this.btnPickSession.Text = "&Session";
            this.toolTip1.SetToolTip(this.btnPickSession, "Click to choose a Session");
            this.btnPickSession.UseVisualStyleBackColor = true;
            this.btnPickSession.Click += new System.EventHandler(this.btnPickSession_Click);
            // 
            // lblXEventSession
            // 
            this.lblXEventSession.AutoSize = true;
            this.lblXEventSession.Location = new System.Drawing.Point(12, 47);
            this.lblXEventSession.Name = "lblXEventSession";
            this.lblXEventSession.Size = new System.Drawing.Size(131, 13);
            this.lblXEventSession.TabIndex = 3;
            this.lblXEventSession.Text = "Extended Events Session:";
            // 
            // txtXEventSession
            // 
            this.txtXEventSession.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXEventSession.Location = new System.Drawing.Point(149, 43);
            this.txtXEventSession.Name = "txtXEventSession";
            this.txtXEventSession.ReadOnly = true;
            this.txtXEventSession.Size = new System.Drawing.Size(316, 20);
            this.txtXEventSession.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(398, 309);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "&Start";
            this.toolTip1.SetToolTip(this.btnStart, "Start handling events.");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(479, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // grpEventsHandled
            // 
            this.grpEventsHandled.Controls.Add(this.clbEvents);
            this.grpEventsHandled.Location = new System.Drawing.Point(15, 99);
            this.grpEventsHandled.Name = "grpEventsHandled";
            this.grpEventsHandled.Size = new System.Drawing.Size(200, 171);
            this.grpEventsHandled.TabIndex = 8;
            this.grpEventsHandled.TabStop = false;
            this.grpEventsHandled.Text = "Events Handled";
            // 
            // clbEvents
            // 
            this.clbEvents.CheckOnClick = true;
            this.clbEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbEvents.FormattingEnabled = true;
            this.clbEvents.Location = new System.Drawing.Point(3, 16);
            this.clbEvents.Name = "clbEvents";
            this.clbEvents.Size = new System.Drawing.Size(194, 152);
            this.clbEvents.TabIndex = 1;
            // 
            // grpEventResponses
            // 
            this.grpEventResponses.Controls.Add(this.txtEmail);
            this.grpEventResponses.Controls.Add(this.cboSounds);
            this.grpEventResponses.Controls.Add(this.ckSendEmail);
            this.grpEventResponses.Controls.Add(this.ckPlaySysSound);
            this.grpEventResponses.Location = new System.Drawing.Point(265, 99);
            this.grpEventResponses.Name = "grpEventResponses";
            this.grpEventResponses.Size = new System.Drawing.Size(236, 171);
            this.grpEventResponses.TabIndex = 9;
            this.grpEventResponses.TabStop = false;
            this.grpEventResponses.Text = "Event Responses";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(18, 125);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(182, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // cboSounds
            // 
            this.cboSounds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSounds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSounds.FormattingEnabled = true;
            this.cboSounds.Location = new System.Drawing.Point(18, 51);
            this.cboSounds.Name = "cboSounds";
            this.cboSounds.Size = new System.Drawing.Size(182, 21);
            this.cboSounds.TabIndex = 4;
            // 
            // ckSendEmail
            // 
            this.ckSendEmail.AutoSize = true;
            this.ckSendEmail.Location = new System.Drawing.Point(18, 102);
            this.ckSendEmail.Name = "ckSendEmail";
            this.ckSendEmail.Size = new System.Drawing.Size(79, 17);
            this.ckSendEmail.TabIndex = 2;
            this.ckSendEmail.Text = "Send Email";
            this.ckSendEmail.UseVisualStyleBackColor = true;
            // 
            // ckPlaySysSound
            // 
            this.ckPlaySysSound.AutoSize = true;
            this.ckPlaySysSound.Location = new System.Drawing.Point(18, 28);
            this.ckPlaySysSound.Name = "ckPlaySysSound";
            this.ckPlaySysSound.Size = new System.Drawing.Size(126, 17);
            this.ckPlaySysSound.TabIndex = 1;
            this.ckPlaySysSound.Text = "Play a System Sound";
            this.ckPlaySysSound.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Last Event Handled:";
            // 
            // lblLastEventHandled
            // 
            this.lblLastEventHandled.Location = new System.Drawing.Point(125, 292);
            this.lblLastEventHandled.Name = "lblLastEventHandled";
            this.lblLastEventHandled.Size = new System.Drawing.Size(237, 13);
            this.lblLastEventHandled.TabIndex = 11;
            this.lblLastEventHandled.Text = "...";
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 357);
            this.Controls.Add(this.lblLastEventHandled);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpEventResponses);
            this.Controls.Add(this.grpEventsHandled);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtXEventSession);
            this.Controls.Add(this.lblXEventSession);
            this.Controls.Add(this.btnPickSession);
            this.Controls.Add(this.ssSqlConn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XEvent Handler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ssSqlConn.ResumeLayout(false);
            this.ssSqlConn.PerformLayout();
            this.grpEventsHandled.ResumeLayout(false);
            this.grpEventResponses.ResumeLayout(false);
            this.grpEventResponses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip ssSqlConn;
        private System.Windows.Forms.ToolStripStatusLabel tsslLogin;
        private System.Windows.Forms.ToolStripStatusLabel tsslSqlHost;
        private System.Windows.Forms.ToolStripStatusLabel tsslPipe;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnected;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button btnPickSession;
        private System.Windows.Forms.Label lblXEventSession;
        private System.Windows.Forms.TextBox txtXEventSession;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox grpEventsHandled;
        private System.Windows.Forms.CheckedListBox clbEvents;
        private System.Windows.Forms.GroupBox grpEventResponses;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cboSounds;
        private System.Windows.Forms.CheckBox ckSendEmail;
        private System.Windows.Forms.CheckBox ckPlaySysSound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLastEventHandled;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.ToolStripMenuItem minimizeToSystemTrayToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

