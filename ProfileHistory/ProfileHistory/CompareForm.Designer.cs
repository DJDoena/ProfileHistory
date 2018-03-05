namespace DoenaSoft.DVDProfiler.ProfileHistory
{
    partial class CompareForm
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
            System.Windows.Forms.ColumnHeader Date;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareForm));
            System.Windows.Forms.ColumnHeader Title;
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader2;
            this.LeftListView = new System.Windows.Forms.ListView();
            this.RightListView = new System.Windows.Forms.ListView();
            this.CompareButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Date
            // 
            resources.ApplyResources(Date, "Date");
            // 
            // Title
            // 
            resources.ApplyResources(Title, "Title");
            // 
            // columnHeader1
            // 
            resources.ApplyResources(columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(columnHeader2, "columnHeader2");
            // 
            // LeftListView
            // 
            resources.ApplyResources(this.LeftListView, "LeftListView");
            this.LeftListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Date,
            Title});
            this.LeftListView.FullRowSelect = true;
            this.LeftListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LeftListView.HideSelection = false;
            this.LeftListView.MultiSelect = false;
            this.LeftListView.Name = "LeftListView";
            this.LeftListView.UseCompatibleStateImageBehavior = false;
            this.LeftListView.View = System.Windows.Forms.View.Details;
            // 
            // RightListView
            // 
            resources.ApplyResources(this.RightListView, "RightListView");
            this.RightListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            columnHeader2});
            this.RightListView.FullRowSelect = true;
            this.RightListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.RightListView.HideSelection = false;
            this.RightListView.MultiSelect = false;
            this.RightListView.Name = "RightListView";
            this.RightListView.UseCompatibleStateImageBehavior = false;
            this.RightListView.View = System.Windows.Forms.View.Details;
            // 
            // CompareButton
            // 
            resources.ApplyResources(this.CompareButton, "CompareButton");
            this.CompareButton.Name = "CompareButton";
            this.CompareButton.UseVisualStyleBackColor = true;
            this.CompareButton.Click += new System.EventHandler(this.OnCompareButtonClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CompareForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CompareButton);
            this.Controls.Add(this.RightListView);
            this.Controls.Add(this.LeftListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompareForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LeftListView;
        private System.Windows.Forms.ListView RightListView;
        private System.Windows.Forms.Button CompareButton;
        private System.Windows.Forms.Label label1;
    }
}