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
            this.dataView = new System.Windows.Forms.ListView();
            this.bOpenTransformationDialog = new System.Windows.Forms.Button();
            this.meshComponentsView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // MeshSelector
            // 
            this.MeshSelector.FormattingEnabled = true;
            this.MeshSelector.Location = new System.Drawing.Point(28, 27);
            this.MeshSelector.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.MeshSelector.Name = "MeshSelector";
            this.MeshSelector.Size = new System.Drawing.Size(744, 37);
            this.MeshSelector.TabIndex = 0;
            this.MeshSelector.SelectedIndexChanged += new System.EventHandler(this.MeshSelector_SelectedIndexChanged);
            // 
            // dataView
            // 
            this.dataView.AllowColumnReorder = true;
            this.dataView.HideSelection = false;
            this.dataView.Location = new System.Drawing.Point(791, 87);
            this.dataView.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(1850, 921);
            this.dataView.TabIndex = 2;
            this.dataView.UseCompatibleStateImageBehavior = false;
            this.dataView.View = System.Windows.Forms.View.Details;
            // 
            // bOpenTransformationDialog
            // 
            this.bOpenTransformationDialog.Location = new System.Drawing.Point(791, 22);
            this.bOpenTransformationDialog.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.bOpenTransformationDialog.Name = "bOpenTransformationDialog";
            this.bOpenTransformationDialog.Size = new System.Drawing.Size(376, 51);
            this.bOpenTransformationDialog.TabIndex = 3;
            this.bOpenTransformationDialog.Text = "Open transformation dialog";
            this.bOpenTransformationDialog.UseVisualStyleBackColor = true;
            this.bOpenTransformationDialog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BOpenTransformationDialog_MouseClick);
            // 
            // meshComponentsView
            // 
            this.meshComponentsView.Location = new System.Drawing.Point(28, 87);
            this.meshComponentsView.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.meshComponentsView.Name = "meshComponentsView";
            this.meshComponentsView.Size = new System.Drawing.Size(744, 921);
            this.meshComponentsView.TabIndex = 1;
            this.meshComponentsView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MeshComponentsView_AfterSelect);
            // 
            // MeshDetailsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2674, 1040);
            this.Controls.Add(this.bOpenTransformationDialog);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.meshComponentsView);
            this.Controls.Add(this.MeshSelector);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MeshDetailsWindow";
            this.Text = "MeshDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox MeshSelector;
        private System.Windows.Forms.ListView dataView;
        private System.Windows.Forms.Button bOpenTransformationDialog;
        private System.Windows.Forms.TreeView meshComponentsView;
    }
}