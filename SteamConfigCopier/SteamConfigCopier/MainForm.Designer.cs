namespace SteamConfigCopier
{
    partial class MainForm
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
            this.lblSteamPath = new System.Windows.Forms.Label();
            this.txtSteamPath = new System.Windows.Forms.TextBox();
            this.lblSourceId = new System.Windows.Forms.Label();
            this.txtSourceId = new System.Windows.Forms.TextBox();
            this.txtDestIds = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lstSteamIds = new System.Windows.Forms.ListBox();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.chkDryRun = new System.Windows.Forms.CheckBox();
            this.chkBackup = new System.Windows.Forms.CheckBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblCredits = new System.Windows.Forms.Label();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.grpIds = new System.Windows.Forms.GroupBox();
            this.btnUseAsSource = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.grpCopy = new System.Windows.Forms.GroupBox();
            this.btnAddToDest = new System.Windows.Forms.Button();
            this.btnRefreshIds = new System.Windows.Forms.Button();
            this.btnClearDest = new System.Windows.Forms.Button();
            this.grpGeneral.SuspendLayout();
            this.grpIds.SuspendLayout();
            this.grpCopy.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSteamPath
            // 
            this.lblSteamPath.AutoSize = true;
            this.lblSteamPath.Location = new System.Drawing.Point(6, 16);
            this.lblSteamPath.Name = "lblSteamPath";
            this.lblSteamPath.Size = new System.Drawing.Size(73, 15);
            this.lblSteamPath.TabIndex = 0;
            this.lblSteamPath.Text = "Steam path:";
            // 
            // txtSteamPath
            // 
            this.txtSteamPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSteamPath.Location = new System.Drawing.Point(128, 16);
            this.txtSteamPath.Name = "txtSteamPath";
            this.txtSteamPath.Size = new System.Drawing.Size(574, 20);
            this.txtSteamPath.TabIndex = 1;
            // 
            // lblSourceId
            // 
            this.lblSourceId.AutoSize = true;
            this.lblSourceId.Location = new System.Drawing.Point(6, 52);
            this.lblSourceId.Name = "lblSourceId";
            this.lblSourceId.Size = new System.Drawing.Size(100, 15);
            this.lblSourceId.TabIndex = 2;
            this.lblSourceId.Text = "Source SteamID:";
            // 
            // txtSourceId
            // 
            this.txtSourceId.Location = new System.Drawing.Point(128, 49);
            this.txtSourceId.Name = "txtSourceId";
            this.txtSourceId.Size = new System.Drawing.Size(100, 20);
            this.txtSourceId.TabIndex = 3;
            // 
            // txtDestIds
            // 
            this.txtDestIds.Location = new System.Drawing.Point(6, 33);
            this.txtDestIds.Multiline = true;
            this.txtDestIds.Name = "txtDestIds";
            this.txtDestIds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDestIds.Size = new System.Drawing.Size(200, 200);
            this.txtDestIds.TabIndex = 5;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(213, 159);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Copy Config";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(19, 754);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 15);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Ready.";
            // 
            // lstSteamIds
            // 
            this.lstSteamIds.FormattingEnabled = true;
            this.lstSteamIds.Location = new System.Drawing.Point(6, 33);
            this.lstSteamIds.Name = "lstSteamIds";
            this.lstSteamIds.Size = new System.Drawing.Size(200, 199);
            this.lstSteamIds.TabIndex = 9;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(22, 386);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSelected.TabIndex = 11;
            this.btnDeleteSelected.Text = "Delete selected config";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            // 
            // chkDryRun
            // 
            this.chkDryRun.AutoSize = true;
            this.chkDryRun.Location = new System.Drawing.Point(213, 188);
            this.chkDryRun.Name = "chkDryRun";
            this.chkDryRun.Size = new System.Drawing.Size(143, 19);
            this.chkDryRun.TabIndex = 12;
            this.chkDryRun.Text = "Dry run (no changes)";
            this.chkDryRun.UseVisualStyleBackColor = true;
            // 
            // chkBackup
            // 
            this.chkBackup.AutoSize = true;
            this.chkBackup.Location = new System.Drawing.Point(213, 213);
            this.chkBackup.Name = "chkBackup";
            this.chkBackup.Size = new System.Drawing.Size(223, 19);
            this.chkBackup.TabIndex = 13;
            this.chkBackup.Text = "Backup destination before overwrite";
            this.chkBackup.UseVisualStyleBackColor = true;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(25, 446);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(31, 15);
            this.lblLog.TabIndex = 14;
            this.lblLog.Text = "Log:";
            this.lblLog.Click += new System.EventHandler(this.lblLog_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(22, 474);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(794, 200);
            this.txtLog.TabIndex = 15;
            // 
            // lblCredits
            // 
            this.lblCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCredits.AutoSize = true;
            this.lblCredits.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCredits.Location = new System.Drawing.Point(678, 689);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(138, 15);
            this.lblCredits.TabIndex = 16;
            this.lblCredits.Text = "© 2025 Lajos + Cipotalp";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.lblSteamPath);
            this.grpGeneral.Controls.Add(this.lblSourceId);
            this.grpGeneral.Controls.Add(this.txtSourceId);
            this.grpGeneral.Controls.Add(this.txtSteamPath);
            this.grpGeneral.Location = new System.Drawing.Point(24, 12);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(795, 78);
            this.grpGeneral.TabIndex = 17;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // grpIds
            // 
            this.grpIds.Controls.Add(this.btnRefreshIds);
            this.grpIds.Controls.Add(this.btnUseAsSource);
            this.grpIds.Controls.Add(this.label1);
            this.grpIds.Controls.Add(this.lstSteamIds);
            this.grpIds.Location = new System.Drawing.Point(22, 112);
            this.grpIds.Name = "grpIds";
            this.grpIds.Size = new System.Drawing.Size(306, 311);
            this.grpIds.TabIndex = 18;
            this.grpIds.TabStop = false;
            this.grpIds.Text = "Detected SteamIDs";
            // 
            // btnUseAsSource
            // 
            this.btnUseAsSource.Location = new System.Drawing.Point(215, 33);
            this.btnUseAsSource.Name = "btnUseAsSource";
            this.btnUseAsSource.Size = new System.Drawing.Size(75, 50);
            this.btnUseAsSource.TabIndex = 12;
            this.btnUseAsSource.Text = "Use as Source";
            this.btnUseAsSource.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Double-click or Ctrl+C to copy";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // grpCopy
            // 
            this.grpCopy.Controls.Add(this.btnClearDest);
            this.grpCopy.Controls.Add(this.btnAddToDest);
            this.grpCopy.Controls.Add(this.txtDestIds);
            this.grpCopy.Controls.Add(this.btnRun);
            this.grpCopy.Controls.Add(this.chkDryRun);
            this.grpCopy.Controls.Add(this.chkBackup);
            this.grpCopy.Location = new System.Drawing.Point(384, 112);
            this.grpCopy.Name = "grpCopy";
            this.grpCopy.Size = new System.Drawing.Size(435, 311);
            this.grpCopy.TabIndex = 20;
            this.grpCopy.TabStop = false;
            this.grpCopy.Text = "Destination SteamIDs (one per line):";
            // 
            // btnAddToDest
            // 
            this.btnAddToDest.Location = new System.Drawing.Point(213, 33);
            this.btnAddToDest.Name = "btnAddToDest";
            this.btnAddToDest.Size = new System.Drawing.Size(75, 50);
            this.btnAddToDest.TabIndex = 14;
            this.btnAddToDest.Text = "Add to Dest";
            this.btnAddToDest.UseVisualStyleBackColor = true;
            // 
            // btnRefreshIds
            // 
            this.btnRefreshIds.AutoSize = true;
            this.btnRefreshIds.Location = new System.Drawing.Point(215, 172);
            this.btnRefreshIds.Name = "btnRefreshIds";
            this.btnRefreshIds.Size = new System.Drawing.Size(81, 61);
            this.btnRefreshIds.TabIndex = 13;
            this.btnRefreshIds.Text = "Refresh IDs";
            this.btnRefreshIds.UseVisualStyleBackColor = true;
            // 
            // btnClearDest
            // 
            this.btnClearDest.Location = new System.Drawing.Point(213, 89);
            this.btnClearDest.Name = "btnClearDest";
            this.btnClearDest.Size = new System.Drawing.Size(75, 23);
            this.btnClearDest.TabIndex = 15;
            this.btnClearDest.Text = "Clear";
            this.btnClearDest.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 723);
            this.Controls.Add(this.grpCopy);
            this.Controls.Add(this.grpIds);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steam Config Copier – © 2025 Lajos & Cipotalp";
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpIds.ResumeLayout(false);
            this.grpIds.PerformLayout();
            this.grpCopy.ResumeLayout(false);
            this.grpCopy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSteamPath;
        private System.Windows.Forms.TextBox txtSteamPath;
        private System.Windows.Forms.Label lblSourceId;
        private System.Windows.Forms.TextBox txtSourceId;
        private System.Windows.Forms.TextBox txtDestIds;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lstSteamIds;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.CheckBox chkDryRun;
        private System.Windows.Forms.CheckBox chkBackup;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.GroupBox grpIds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox grpCopy;
        private System.Windows.Forms.Button btnUseAsSource;
        private System.Windows.Forms.Button btnAddToDest;
        private System.Windows.Forms.Button btnRefreshIds;
        private System.Windows.Forms.Button btnClearDest;
    }
}