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
            System.Windows.Forms.ColumnHeader SortTitle;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ColumnHeader Title;
            System.Windows.Forms.ColumnHeader UPC;
            System.Windows.Forms.ColumnHeader Locality;
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
            this.label4 = new System.Windows.Forms.Label();
            this.IgnoreRemovedProfilesCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectFilterListButton = new System.Windows.Forms.Button();
            this.FilterListTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            SortTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            UPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Locality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RootMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SortTitle
            // 
            resources.ApplyResources(SortTitle, "SortTitle");
            // 
            // Title
            // 
            resources.ApplyResources(Title, "Title");
            // 
            // UPC
            // 
            resources.ApplyResources(UPC, "UPC");
            // 
            // Locality
            // 
            resources.ApplyResources(Locality, "Locality");
            // 
            // RootMenuStrip
            // 
            this.RootMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem});
            resources.ApplyResources(this.RootMenuStrip, "RootMenuStrip");
            this.RootMenuStrip.Name = "RootMenuStrip";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReadMeToolStripMenuItem,
            this.CheckForUpdatesToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            resources.ApplyResources(this.HelpToolStripMenuItem, "HelpToolStripMenuItem");
            // 
            // ReadMeToolStripMenuItem
            // 
            resources.ApplyResources(this.ReadMeToolStripMenuItem, "ReadMeToolStripMenuItem");
            this.ReadMeToolStripMenuItem.Name = "ReadMeToolStripMenuItem";
            this.ReadMeToolStripMenuItem.Click += new System.EventHandler(this.OnReadMeToolStripMenuItemClick);
            // 
            // CheckForUpdatesToolStripMenuItem
            // 
            this.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem";
            resources.ApplyResources(this.CheckForUpdatesToolStripMenuItem, "CheckForUpdatesToolStripMenuItem");
            this.CheckForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.OnCheckForUpdatesToolStripMenuItemClick);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            resources.ApplyResources(this.AboutToolStripMenuItem, "AboutToolStripMenuItem");
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolStripMenuItemClick);
            // 
            // OpenProfilesFolderToolStripMenuItem
            // 
            this.OpenProfilesFolderToolStripMenuItem.Name = "OpenProfilesFolderToolStripMenuItem";
            resources.ApplyResources(this.OpenProfilesFolderToolStripMenuItem, "OpenProfilesFolderToolStripMenuItem");
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            resources.ApplyResources(this.ExitToolStripMenuItem, "ExitToolStripMenuItem");
            // 
            // WinMergeLinkLabel
            // 
            resources.ApplyResources(this.WinMergeLinkLabel, "WinMergeLinkLabel");
            this.WinMergeLinkLabel.Name = "WinMergeLinkLabel";
            this.WinMergeLinkLabel.TabStop = true;
            this.WinMergeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnWinMergeLinkLabelLinkClicked);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // WinMergeTextBox
            // 
            resources.ApplyResources(this.WinMergeTextBox, "WinMergeTextBox");
            this.WinMergeTextBox.Name = "WinMergeTextBox";
            this.WinMergeTextBox.ReadOnly = true;
            // 
            // WinMergeButton
            // 
            resources.ApplyResources(this.WinMergeButton, "WinMergeButton");
            this.WinMergeButton.Name = "WinMergeButton";
            this.WinMergeButton.UseVisualStyleBackColor = true;
            this.WinMergeButton.Click += new System.EventHandler(this.OnWinMergeButtonClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ProfileFolderTextBox
            // 
            resources.ApplyResources(this.ProfileFolderTextBox, "ProfileFolderTextBox");
            this.ProfileFolderTextBox.Name = "ProfileFolderTextBox";
            this.ProfileFolderTextBox.ReadOnly = true;
            // 
            // ProfileFolderButton
            // 
            resources.ApplyResources(this.ProfileFolderButton, "ProfileFolderButton");
            this.ProfileFolderButton.Name = "ProfileFolderButton";
            this.ProfileFolderButton.UseVisualStyleBackColor = true;
            this.ProfileFolderButton.Click += new System.EventHandler(this.OnProfileFolderButtonClick);
            // 
            // CheckProfileHistoryButton
            // 
            resources.ApplyResources(this.CheckProfileHistoryButton, "CheckProfileHistoryButton");
            this.CheckProfileHistoryButton.Name = "CheckProfileHistoryButton";
            this.CheckProfileHistoryButton.UseVisualStyleBackColor = true;
            this.CheckProfileHistoryButton.Click += new System.EventHandler(this.OnCheckProfileHistoryButtonClick);
            // 
            // ProfileListView
            // 
            resources.ApplyResources(this.ProfileListView, "ProfileListView");
            this.ProfileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            SortTitle,
            Title,
            UPC,
            Locality});
            this.ProfileListView.FullRowSelect = true;
            this.ProfileListView.MultiSelect = false;
            this.ProfileListView.Name = "ProfileListView";
            this.ProfileListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ProfileListView.UseCompatibleStateImageBehavior = false;
            this.ProfileListView.View = System.Windows.Forms.View.Details;
            this.ProfileListView.DoubleClick += new System.EventHandler(this.OnListViewDoubleClick);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // IgnoreRemovedProfilesCheckBox
            // 
            resources.ApplyResources(this.IgnoreRemovedProfilesCheckBox, "IgnoreRemovedProfilesCheckBox");
            this.IgnoreRemovedProfilesCheckBox.Checked = true;
            this.IgnoreRemovedProfilesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IgnoreRemovedProfilesCheckBox.Name = "IgnoreRemovedProfilesCheckBox";
            this.IgnoreRemovedProfilesCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // SelectFilterListButton
            // 
            resources.ApplyResources(this.SelectFilterListButton, "SelectFilterListButton");
            this.SelectFilterListButton.Name = "SelectFilterListButton";
            this.SelectFilterListButton.UseVisualStyleBackColor = true;
            this.SelectFilterListButton.Click += new System.EventHandler(this.OnSelectFilterListButtonClick);
            // 
            // FilterListTextBox
            // 
            resources.ApplyResources(this.FilterListTextBox, "FilterListTextBox");
            this.FilterListTextBox.Name = "FilterListTextBox";
            this.FilterListTextBox.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FilterListTextBox);
            this.Controls.Add(this.SelectFilterListButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IgnoreRemovedProfilesCheckBox);
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
            this.MainMenuStrip = this.RootMenuStrip;
            this.Name = "MainForm";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox IgnoreRemovedProfilesCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SelectFilterListButton;
        private System.Windows.Forms.TextBox FilterListTextBox;
        private System.Windows.Forms.Label label5;
    }
}

