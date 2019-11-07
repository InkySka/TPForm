namespace TPMeshEditor
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
            this.log = new System.Windows.Forms.TextBox();
            this.fileList = new System.Windows.Forms.ListView();
            this.importButton = new System.Windows.Forms.Button();
            this.selectedItemsCount = new System.Windows.Forms.TextBox();
            this.FileMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FilesInFolder = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // log
            // 
            this.log.AcceptsReturn = true;
            this.log.Location = new System.Drawing.Point(321, 27);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(467, 411);
            this.log.TabIndex = 1;
            // 
            // fileList
            // 
            this.fileList.CheckBoxes = true;
            this.fileList.HideSelection = false;
            this.fileList.HoverSelection = true;
            this.fileList.Location = new System.Drawing.Point(12, 53);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(303, 355);
            this.fileList.TabIndex = 2;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.List;
            this.fileList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.FileList_ItemChecked);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(214, 414);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(100, 23);
            this.importButton.TabIndex = 4;
            this.importButton.Text = "Import selected";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // selectedItemsCount
            // 
            this.selectedItemsCount.Location = new System.Drawing.Point(12, 416);
            this.selectedItemsCount.Name = "selectedItemsCount";
            this.selectedItemsCount.ReadOnly = true;
            this.selectedItemsCount.Size = new System.Drawing.Size(196, 20);
            this.selectedItemsCount.TabIndex = 5;
            // 
            // FileMenuStrip
            // 
            this.FileMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.FileMenuStrip.Name = "FileMenuStrip";
            this.FileMenuStrip.Size = new System.Drawing.Size(37, 20);
            this.FileMenuStrip.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.CheckOnClick = true;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // FilesInFolder
            // 
            this.FilesInFolder.Location = new System.Drawing.Point(12, 27);
            this.FilesInFolder.Name = "FilesInFolder";
            this.FilesInFolder.ReadOnly = true;
            this.FilesInFolder.Size = new System.Drawing.Size(303, 20);
            this.FilesInFolder.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FilesInFolder);
            this.Controls.Add(this.selectedItemsCount);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.log);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "TPMeshEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.TextBox selectedItemsCount;
        private System.Windows.Forms.ToolStripMenuItem FileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox FilesInFolder;
    }
}

