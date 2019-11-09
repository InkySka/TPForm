namespace TPMeshEditor
{
    partial class TransformDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransformDialog));
            this.XMove = new System.Windows.Forms.NumericUpDown();
            this.ZMove = new System.Windows.Forms.NumericUpDown();
            this.YMove = new System.Windows.Forms.NumericUpDown();
            this.F_X = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.GB_Move = new System.Windows.Forms.GroupBox();
            this.GB_Rotate = new System.Windows.Forms.GroupBox();
            this.ZRot = new System.Windows.Forms.NumericUpDown();
            this.F_Z2 = new System.Windows.Forms.TextBox();
            this.XRot = new System.Windows.Forms.NumericUpDown();
            this.F_Y2 = new System.Windows.Forms.TextBox();
            this.YRot = new System.Windows.Forms.NumericUpDown();
            this.F_X2 = new System.Windows.Forms.TextBox();
            this.GB_Scale = new System.Windows.Forms.GroupBox();
            this.ZScale = new System.Windows.Forms.NumericUpDown();
            this.F_Z3 = new System.Windows.Forms.TextBox();
            this.XScale = new System.Windows.Forms.NumericUpDown();
            this.F_Y3 = new System.Windows.Forms.TextBox();
            this.YScale = new System.Windows.Forms.NumericUpDown();
            this.F_X3 = new System.Windows.Forms.TextBox();
            this.FilesInFolder = new System.Windows.Forms.TextBox();
            this.LoadedMeshesList = new System.Windows.Forms.ListView();
            this.buttonApplyTransformations = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.XMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMove)).BeginInit();
            this.GB_Move.SuspendLayout();
            this.GB_Rotate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZRot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XRot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YRot)).BeginInit();
            this.GB_Scale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YScale)).BeginInit();
            this.SuspendLayout();
            // 
            // XMove
            // 
            this.XMove.AllowDrop = true;
            this.XMove.DecimalPlaces = 10;
            resources.ApplyResources(this.XMove, "XMove");
            this.XMove.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.XMove.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.XMove.Name = "XMove";
            this.XMove.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // ZMove
            // 
            this.ZMove.AllowDrop = true;
            this.ZMove.DecimalPlaces = 10;
            resources.ApplyResources(this.ZMove, "ZMove");
            this.ZMove.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.ZMove.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.ZMove.Name = "ZMove";
            // 
            // YMove
            // 
            this.YMove.AllowDrop = true;
            this.YMove.DecimalPlaces = 10;
            resources.ApplyResources(this.YMove, "YMove");
            this.YMove.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.YMove.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.YMove.Name = "YMove";
            // 
            // F_X
            // 
            resources.ApplyResources(this.F_X, "F_X");
            this.F_X.Name = "F_X";
            this.F_X.ReadOnly = true;
            this.F_X.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            // 
            // GB_Move
            // 
            this.GB_Move.Controls.Add(this.ZMove);
            this.GB_Move.Controls.Add(this.textBox2);
            this.GB_Move.Controls.Add(this.XMove);
            this.GB_Move.Controls.Add(this.textBox1);
            this.GB_Move.Controls.Add(this.YMove);
            this.GB_Move.Controls.Add(this.F_X);
            resources.ApplyResources(this.GB_Move, "GB_Move");
            this.GB_Move.Name = "GB_Move";
            this.GB_Move.TabStop = false;
            // 
            // GB_Rotate
            // 
            this.GB_Rotate.Controls.Add(this.ZRot);
            this.GB_Rotate.Controls.Add(this.F_Z2);
            this.GB_Rotate.Controls.Add(this.XRot);
            this.GB_Rotate.Controls.Add(this.F_Y2);
            this.GB_Rotate.Controls.Add(this.YRot);
            this.GB_Rotate.Controls.Add(this.F_X2);
            resources.ApplyResources(this.GB_Rotate, "GB_Rotate");
            this.GB_Rotate.Name = "GB_Rotate";
            this.GB_Rotate.TabStop = false;
            // 
            // ZRot
            // 
            this.ZRot.AllowDrop = true;
            this.ZRot.DecimalPlaces = 10;
            resources.ApplyResources(this.ZRot, "ZRot");
            this.ZRot.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.ZRot.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.ZRot.Name = "ZRot";
            // 
            // F_Z2
            // 
            resources.ApplyResources(this.F_Z2, "F_Z2");
            this.F_Z2.Name = "F_Z2";
            this.F_Z2.ReadOnly = true;
            // 
            // XRot
            // 
            this.XRot.AllowDrop = true;
            this.XRot.DecimalPlaces = 10;
            resources.ApplyResources(this.XRot, "XRot");
            this.XRot.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.XRot.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.XRot.Name = "XRot";
            // 
            // F_Y2
            // 
            resources.ApplyResources(this.F_Y2, "F_Y2");
            this.F_Y2.Name = "F_Y2";
            this.F_Y2.ReadOnly = true;
            // 
            // YRot
            // 
            this.YRot.AllowDrop = true;
            this.YRot.DecimalPlaces = 10;
            resources.ApplyResources(this.YRot, "YRot");
            this.YRot.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.YRot.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.YRot.Name = "YRot";
            // 
            // F_X2
            // 
            resources.ApplyResources(this.F_X2, "F_X2");
            this.F_X2.Name = "F_X2";
            this.F_X2.ReadOnly = true;
            // 
            // GB_Scale
            // 
            this.GB_Scale.Controls.Add(this.ZScale);
            this.GB_Scale.Controls.Add(this.F_Z3);
            this.GB_Scale.Controls.Add(this.XScale);
            this.GB_Scale.Controls.Add(this.F_Y3);
            this.GB_Scale.Controls.Add(this.YScale);
            this.GB_Scale.Controls.Add(this.F_X3);
            resources.ApplyResources(this.GB_Scale, "GB_Scale");
            this.GB_Scale.Name = "GB_Scale";
            this.GB_Scale.TabStop = false;
            // 
            // ZScale
            // 
            this.ZScale.AllowDrop = true;
            this.ZScale.DecimalPlaces = 10;
            resources.ApplyResources(this.ZScale, "ZScale");
            this.ZScale.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.ZScale.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.ZScale.Name = "ZScale";
            this.ZScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // F_Z3
            // 
            resources.ApplyResources(this.F_Z3, "F_Z3");
            this.F_Z3.Name = "F_Z3";
            this.F_Z3.ReadOnly = true;
            // 
            // XScale
            // 
            this.XScale.AllowDrop = true;
            this.XScale.DecimalPlaces = 10;
            resources.ApplyResources(this.XScale, "XScale");
            this.XScale.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.XScale.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.XScale.Name = "XScale";
            this.XScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // F_Y3
            // 
            resources.ApplyResources(this.F_Y3, "F_Y3");
            this.F_Y3.Name = "F_Y3";
            this.F_Y3.ReadOnly = true;
            // 
            // YScale
            // 
            this.YScale.AllowDrop = true;
            this.YScale.DecimalPlaces = 10;
            resources.ApplyResources(this.YScale, "YScale");
            this.YScale.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.YScale.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.YScale.Name = "YScale";
            this.YScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // F_X3
            // 
            resources.ApplyResources(this.F_X3, "F_X3");
            this.F_X3.Name = "F_X3";
            this.F_X3.ReadOnly = true;
            // 
            // FilesInFolder
            // 
            resources.ApplyResources(this.FilesInFolder, "FilesInFolder");
            this.FilesInFolder.Name = "FilesInFolder";
            this.FilesInFolder.ReadOnly = true;
            this.FilesInFolder.TextChanged += new System.EventHandler(this.FilesInFolder_TextChanged);
            // 
            // LoadedMeshesList
            // 
            this.LoadedMeshesList.CheckBoxes = true;
            this.LoadedMeshesList.HideSelection = false;
            resources.ApplyResources(this.LoadedMeshesList, "LoadedMeshesList");
            this.LoadedMeshesList.Name = "LoadedMeshesList";
            this.LoadedMeshesList.UseCompatibleStateImageBehavior = false;
            this.LoadedMeshesList.View = System.Windows.Forms.View.List;
            // 
            // buttonApplyTransformations
            // 
            resources.ApplyResources(this.buttonApplyTransformations, "buttonApplyTransformations");
            this.buttonApplyTransformations.Name = "buttonApplyTransformations";
            this.buttonApplyTransformations.UseVisualStyleBackColor = true;
            this.buttonApplyTransformations.Click += new System.EventHandler(this.ButtonApplyTransformations_Click);
            // 
            // TransformDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonApplyTransformations);
            this.Controls.Add(this.LoadedMeshesList);
            this.Controls.Add(this.FilesInFolder);
            this.Controls.Add(this.GB_Scale);
            this.Controls.Add(this.GB_Rotate);
            this.Controls.Add(this.GB_Move);
            this.Name = "TransformDialog";
            ((System.ComponentModel.ISupportInitialize)(this.XMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMove)).EndInit();
            this.GB_Move.ResumeLayout(false);
            this.GB_Move.PerformLayout();
            this.GB_Rotate.ResumeLayout(false);
            this.GB_Rotate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZRot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XRot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YRot)).EndInit();
            this.GB_Scale.ResumeLayout(false);
            this.GB_Scale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown XMove;
        private System.Windows.Forms.NumericUpDown ZMove;
        private System.Windows.Forms.NumericUpDown YMove;
        private System.Windows.Forms.TextBox F_X;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox GB_Move;
        private System.Windows.Forms.GroupBox GB_Rotate;
        private System.Windows.Forms.NumericUpDown ZRot;
        private System.Windows.Forms.TextBox F_Z2;
        private System.Windows.Forms.NumericUpDown XRot;
        private System.Windows.Forms.TextBox F_Y2;
        private System.Windows.Forms.NumericUpDown YRot;
        private System.Windows.Forms.TextBox F_X2;
        private System.Windows.Forms.GroupBox GB_Scale;
        private System.Windows.Forms.NumericUpDown ZScale;
        private System.Windows.Forms.TextBox F_Z3;
        private System.Windows.Forms.NumericUpDown XScale;
        private System.Windows.Forms.TextBox F_Y3;
        private System.Windows.Forms.NumericUpDown YScale;
        private System.Windows.Forms.TextBox F_X3;
        private System.Windows.Forms.TextBox FilesInFolder;
        private System.Windows.Forms.ListView LoadedMeshesList;
        private System.Windows.Forms.Button buttonApplyTransformations;
    }
}