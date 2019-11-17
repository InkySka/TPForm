namespace TPMeshEditor
{
    partial class ConfirmationDialog
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
            this.bConfirm = new System.Windows.Forms.Button();
            this.b_OK = new System.Windows.Forms.TextBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bConfirm
            // 
            this.bConfirm.Location = new System.Drawing.Point(12, 75);
            this.bConfirm.Name = "bConfirm";
            this.bConfirm.Size = new System.Drawing.Size(170, 48);
            this.bConfirm.TabIndex = 0;
            this.bConfirm.Text = "Transform";
            this.bConfirm.UseVisualStyleBackColor = true;
            this.bConfirm.Click += new System.EventHandler(this.bConfirm_Click);
            // 
            // b_OK
            // 
            this.b_OK.Location = new System.Drawing.Point(12, 12);
            this.b_OK.Name = "b_OK";
            this.b_OK.ReadOnly = true;
            this.b_OK.Size = new System.Drawing.Size(346, 35);
            this.b_OK.TabIndex = 1;
            this.b_OK.Text = "Are you sure?";
            this.b_OK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.b_OK.TextChanged += new System.EventHandler(this.b_OK_TextChanged);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(188, 75);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(170, 48);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // ConfirmationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 136);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.b_OK);
            this.Controls.Add(this.bConfirm);
            this.Name = "ConfirmationDialog";
            this.Text = "ConfirmationDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConfirm;
        private System.Windows.Forms.TextBox b_OK;
        private System.Windows.Forms.Button bCancel;
    }
}