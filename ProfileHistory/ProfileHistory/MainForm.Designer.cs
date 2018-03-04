namespace DoenaSoft.DVDProfiler.ProfileHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RootMenuStrip = new System.Windows.Forms.MenuStrip();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReadMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenProfilesFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinMergeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.WinMergeTextBox = new System.Windows.Forms.TextBox();
            this.WinMergeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ProfileFolderTextBox = new System.Windows.Forms.TextBox();
            this.ProfileFolderButton = new System.Windows.Forms.Button();
            this.CheckProfileHistoryButton = new System.Windows.Forms.Button();
            this.ProfileListView = new System.Windows.Forms.ListView();
            this.SortTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Locality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.RootMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // RootMenuStrip
            // 
            this.RootMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem});
            this.RootMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.RootMenuStrip.Name = "RootMenuStrip";
            this.RootMenuStrip.Size = new System.Drawing.Size(1058, 24);
            this.RootMenuStrip.TabIndex = 0;
            this.RootMenuStrip.Text = "menuStrip1";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReadMeToolStripMenuItem,
            this.CheckForUpdatesToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpToolStripMenuItem.Text = "&Help";
            // 
            // ReadMeToolStripMenuItem
            // 
            this.ReadMeToolStripMenuItem.Enabled = false;
            this.ReadMeToolStripMenuItem.Name = "ReadMeToolStripMenuItem";
            this.ReadMeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ReadMeToolStripMenuItem.Text = "&Read Me";
            this.ReadMeToolStripMenuItem.Click += new System.EventHandler(this.OnReadMeToolStripMenuItemClick);
            // 
            // CheckForUpdatesToolStripMenuItem
            // 
            this.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem";
            this.CheckForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.CheckForUpdatesToolStripMenuItem.Text = "&Check for Updates";
            this.CheckForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.OnCheckForUpdatesToolStripMenuItemClick);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.AboutToolStripMenuItem.Text = "&About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolStripMenuItemClick);
            // 
            // OpenProfilesFolderToolStripMenuItem
            // 
            this.OpenProfilesFolderToolStripMenuItem.Name = "OpenProfilesFolderToolStripMenuItem";
            this.OpenProfilesFolderToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // WinMergeLinkLabel
            // 
            this.WinMergeLinkLabel.AutoSize = true;
            this.WinMergeLinkLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.WinMergeLinkLabel.Location = new System.Drawing.Point(12, 81);
            this.WinMergeLinkLabel.Name = "WinMergeLinkLabel";
            this.WinMergeLinkLabel.Size = new System.Drawing.Size(201, 13);
            this.WinMergeLinkLabel.TabIndex = 19;
            this.WinMergeLinkLabel.TabStop = true;
            this.WinMergeLinkLabel.Text = "What is WinMerge and where do I get it?";
            this.WinMergeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnWinMergeLinkLabelLinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "WinMerge:";
            // 
            // WinMergeTextBox
            // 
            this.WinMergeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WinMergeTextBox.Location = new System.Drawing.Point(94, 58);
            this.WinMergeTextBox.Name = "WinMergeTextBox";
            this.WinMergeTextBox.ReadOnly = true;
            this.WinMergeTextBox.Size = new System.Drawing.Size(907, 20);
            this.WinMergeTextBox.TabIndex = 17;
            // 
            // WinMergeButton
            // 
            this.WinMergeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WinMergeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.WinMergeButton.Location = new System.Drawing.Point(1007, 56);
            this.WinMergeButton.Name = "WinMergeButton";
            this.WinMergeButton.Size = new System.Drawing.Size(39, 23);
            this.WinMergeButton.TabIndex = 16;
            this.WinMergeButton.Text = "...";
            this.WinMergeButton.UseVisualStyleBackColor = true;
            this.WinMergeButton.Click += new System.EventHandler(this.OnWinMergeButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Profiles Folder:";
            // 
            // ProfileFolderTextBox
            // 
            this.ProfileFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileFolderTextBox.Location = new System.Drawing.Point(94, 29);
            this.ProfileFolderTextBox.Name = "ProfileFolderTextBox";
            this.ProfileFolderTextBox.ReadOnly = true;
            this.ProfileFolderTextBox.Size = new System.Drawing.Size(907, 20);
            this.ProfileFolderTextBox.TabIndex = 12;
            // 
            // ProfileFolderButton
            // 
            this.ProfileFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileFolderButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ProfileFolderButton.Location = new System.Drawing.Point(1007, 27);
            this.ProfileFolderButton.Name = "ProfileFolderButton";
            this.ProfileFolderButton.Size = new System.Drawing.Size(39, 23);
            this.ProfileFolderButton.TabIndex = 10;
            this.ProfileFolderButton.Text = "...";
            this.ProfileFolderButton.UseVisualStyleBackColor = true;
            this.ProfileFolderButton.Click += new System.EventHandler(this.OnProfileFolderButtonClick);
            // 
            // CheckProfileHistoryButton
            // 
            this.CheckProfileHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckProfileHistoryButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckProfileHistoryButton.Location = new System.Drawing.Point(896, 100);
            this.CheckProfileHistoryButton.Name = "CheckProfileHistoryButton";
            this.CheckProfileHistoryButton.Size = new System.Drawing.Size(150, 23);
            this.CheckProfileHistoryButton.TabIndex = 20;
            this.CheckProfileHistoryButton.Text = "Überprüfe Profilgeschichte";
            this.CheckProfileHistoryButton.UseVisualStyleBackColor = true;
            this.CheckProfileHistoryButton.Click += new System.EventHandler(this.OnCheckProfileHistoryButtonClick);
            // 
            // ProfileListView
            // 
            this.ProfileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SortTitle,
            this.Title,
            this.UPC,
            this.Locality});
            this.ProfileListView.FullRowSelect = true;
            this.ProfileListView.Location = new System.Drawing.Point(12, 146);
            this.ProfileListView.MultiSelect = false;
            this.ProfileListView.Name = "ProfileListView";
            this.ProfileListView.Size = new System.Drawing.Size(1034, 550);
            this.ProfileListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ProfileListView.TabIndex = 22;
            this.ProfileListView.UseCompatibleStateImageBehavior = false;
            this.ProfileListView.View = System.Windows.Forms.View.Details;
            // 
            // SortTitle
            // 
            this.SortTitle.Text = "Sort Title";
            this.SortTitle.Width = 0;
            // 
            // Title
            // 
            this.Title.Text = "Newest Profile Title";
            this.Title.Width = 400;
            // 
            // UPC
            // 
            this.UPC.Text = "UPC / EAN";
            this.UPC.Width = 200;
            // 
            // Locality
            // 
            this.Locality.Text = "Country";
            this.Locality.Width = 150;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(343, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "List of Profiles that have multiple profile version (double-click for details):";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 708);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProfileListView);
            this.Controls.Add(this.CheckProfileHistoryButton);
            this.Controls.Add(this.WinMergeLinkLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WinMergeTextBox);
            this.Controls.Add(this.WinMergeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProfileFolderTextBox);
            this.Controls.Add(this.ProfileFolderButton);
            this.Controls.Add(this.RootMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.RootMenuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.Text = "Profile History";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.RootMenuStrip.ResumeLayout(false);
            this.RootMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip RootMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OpenProfilesFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReadMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.LinkLabel WinMergeLinkLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox WinMergeTextBox;
        private System.Windows.Forms.Button WinMergeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProfileFolderTextBox;
        private System.Windows.Forms.Button ProfileFolderButton;
        private System.Windows.Forms.Button CheckProfileHistoryButton;
        private System.Windows.Forms.ListView ProfileListView;
        private System.Windows.Forms.ColumnHeader SortTitle;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader UPC;
        private System.Windows.Forms.ColumnHeader Locality;
        private System.Windows.Forms.Label label4;
    }
}

