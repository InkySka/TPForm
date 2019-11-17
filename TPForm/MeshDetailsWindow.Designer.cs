namespace TPMeshEditor
{
    partial class MeshDetailsWindow
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
            this.MeshSelector = new System.Windows.Forms.ComboBox();
            this.meshComponentsView = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.bOpenTransformationDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MeshSelector
            // 
            this.MeshSelector.FormattingEnabled = true;
            this.MeshSelector.Location = new System.Drawing.Point(12, 12);
            this.MeshSelector.Name = "MeshSelector";
            this.MeshSelector.Size = new System.Drawing.Size(321, 21);
            this.MeshSelector.TabIndex = 0;
            this.MeshSelector.SelectedIndexChanged += new System.EventHandler(this.MeshSelector_SelectedIndexChanged);
            // 
            // meshComponentsView
            // 
            this.meshComponentsView.Location = new System.Drawing.Point(12, 39);
            this.meshComponentsView.Name = "meshComponentsView";
            this.meshComponentsView.Size = new System.Drawing.Size(321, 298);
            this.meshComponentsView.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(340, 39);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(355, 298);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // bOpenTransformationDialog
            // 
            this.bOpenTransformationDialog.Location = new System.Drawing.Point(340, 12);
            this.bOpenTransformationDialog.Name = "bOpenTransformationDialog";
            this.bOpenTransformationDialog.Size = new System.Drawing.Size(161, 23);
            this.bOpenTransformationDialog.TabIndex = 3;
            this.bOpenTransformationDialog.Text = "Open transformation dialog";
            this.bOpenTransformationDialog.UseVisualStyleBackColor = true;
            this.bOpenTransformationDialog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BOpenTransformationDialog_MouseClick);
            // 
            // MeshDetailsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 349);
            this.Controls.Add(this.bOpenTransformationDialog);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.meshComponentsView);
            this.Controls.Add(this.MeshSelector);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "MeshDetailsWindow";
            this.Text = "MeshDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox MeshSelector;
        private System.Windows.Forms.TreeView meshComponentsView;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button bOpenTransformationDialog;
    }
}