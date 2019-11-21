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
            this.bApplyTransformations = new System.Windows.Forms.Button();
            this.scaleEndGroup = new System.Windows.Forms.GroupBox();
            this.ZScaleEnd = new System.Windows.Forms.NumericUpDown();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.XScaleEnd = new System.Windows.Forms.NumericUpDown();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.YScaleEnd = new System.Windows.Forms.NumericUpDown();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.rotateEndGroup = new System.Windows.Forms.GroupBox();
            this.ZRotEnd = new System.Windows.Forms.NumericUpDown();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.XRotEnd = new System.Windows.Forms.NumericUpDown();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.YRotEnd = new System.Windows.Forms.NumericUpDown();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.moveEndGroup = new System.Windows.Forms.GroupBox();
            this.ZMoveEnd = new System.Windows.Forms.NumericUpDown();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.XMoveEnd = new System.Windows.Forms.NumericUpDown();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.YMoveEnd = new System.Windows.Forms.NumericUpDown();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.bInterpolate = new System.Windows.Forms.Button();
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
            this.scaleEndGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZScaleEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XScaleEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YScaleEnd)).BeginInit();
            this.rotateEndGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZRotEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XRotEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YRotEnd)).BeginInit();
            this.moveEndGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZMoveEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMoveEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMoveEnd)).BeginInit();
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
            180,
            0,
            0,
            0});
            this.ZRot.Minimum = new decimal(new int[] {
            180,
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
            180,
            0,
            0,
            0});
            this.XRot.Minimum = new decimal(new int[] {
            180,
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
            180,
            0,
            0,
            0});
            this.YRot.Minimum = new decimal(new int[] {
            180,
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
            this.LoadedMeshesList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LoadedMeshesList_ItemChecked);
            this.LoadedMeshesList.SelectedIndexChanged += new System.EventHandler(this.TransformDialog_Click);
            // 
            // bApplyTransformations
            // 
            resources.ApplyResources(this.bApplyTransformations, "bApplyTransformations");
            this.bApplyTransformations.Name = "bApplyTransformations";
            this.bApplyTransformations.UseVisualStyleBackColor = true;
            this.bApplyTransformations.Click += new System.EventHandler(this.BApplyTransformations_Click);
            // 
            // scaleEndGroup
            // 
            this.scaleEndGroup.Controls.Add(this.ZScaleEnd);
            this.scaleEndGroup.Controls.Add(this.textBox3);
            this.scaleEndGroup.Controls.Add(this.XScaleEnd);
            this.scaleEndGroup.Controls.Add(this.textBox4);
            this.scaleEndGroup.Controls.Add(this.YScaleEnd);
            this.scaleEndGroup.Controls.Add(this.textBox5);
            resources.ApplyResources(this.scaleEndGroup, "scaleEndGroup");
            this.scaleEndGroup.Name = "scaleEndGroup";
            this.scaleEndGroup.TabStop = false;
            // 
            // ZScaleEnd
            // 
            this.ZScaleEnd.AllowDrop = true;
            this.ZScaleEnd.DecimalPlaces = 10;
            resources.ApplyResources(this.ZScaleEnd, "ZScaleEnd");
            this.ZScaleEnd.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.ZScaleEnd.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.ZScaleEnd.Name = "ZScaleEnd";
            this.ZScaleEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            // 
            // XScaleEnd
            // 
            this.XScaleEnd.AllowDrop = true;
            this.XScaleEnd.DecimalPlaces = 10;
            resources.ApplyResources(this.XScaleEnd, "XScaleEnd");
            this.XScaleEnd.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.XScaleEnd.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.XScaleEnd.Name = "XScaleEnd";
            this.XScaleEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            // 
            // YScaleEnd
            // 
            this.YScaleEnd.AllowDrop = true;
            this.YScaleEnd.DecimalPlaces = 10;
            resources.ApplyResources(this.YScaleEnd, "YScaleEnd");
            this.YScaleEnd.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.YScaleEnd.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.YScaleEnd.Name = "YScaleEnd";
            this.YScaleEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            // 
            // rotateEndGroup
            // 
            this.rotateEndGroup.Controls.Add(this.ZRotEnd);
            this.rotateEndGroup.Controls.Add(this.textBox6);
            this.rotateEndGroup.Controls.Add(this.XRotEnd);
            this.rotateEndGroup.Controls.Add(this.textBox7);
            this.rotateEndGroup.Controls.Add(this.YRotEnd);
            this.rotateEndGroup.Controls.Add(this.textBox8);
            resources.ApplyResources(this.rotateEndGroup, "rotateEndGroup");
            this.rotateEndGroup.Name = "rotateEndGroup";
            this.rotateEndGroup.TabStop = false;
            // 
            // ZRotEnd
            // 
            this.ZRotEnd.AllowDrop = true;
            this.ZRotEnd.DecimalPlaces = 10;
            resources.ApplyResources(this.ZRotEnd, "ZRotEnd");
            this.ZRotEnd.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.ZRotEnd.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.ZRotEnd.Name = "ZRotEnd";
            // 
            // textBox6
            // 
            resources.ApplyResources(this.textBox6, "textBox6");
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            // 
            // XRotEnd
            // 
            this.XRotEnd.AllowDrop = true;
            this.XRotEnd.DecimalPlaces = 10;
            resources.ApplyResources(this.XRotEnd, "XRotEnd");
            this.XRotEnd.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.XRotEnd.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.XRotEnd.Name = "XRotEnd";
            // 
            // textBox7
            // 
            resources.ApplyResources(this.textBox7, "textBox7");
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            // 
            // YRotEnd
            // 
            this.YRotEnd.AllowDrop = true;
            this.YRotEnd.DecimalPlaces = 10;
            resources.ApplyResources(this.YRotEnd, "YRotEnd");
            this.YRotEnd.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.YRotEnd.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.YRotEnd.Name = "YRotEnd";
            // 
            // textBox8
            // 
            resources.ApplyResources(this.textBox8, "textBox8");
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            // 
            // moveEndGroup
            // 
            this.moveEndGroup.Controls.Add(this.ZMoveEnd);
            this.moveEndGroup.Controls.Add(this.textBox9);
            this.moveEndGroup.Controls.Add(this.XMoveEnd);
            this.moveEndGroup.Controls.Add(this.textBox10);
            this.moveEndGroup.Controls.Add(this.YMoveEnd);
            this.moveEndGroup.Controls.Add(this.textBox11);
            resources.ApplyResources(this.moveEndGroup, "moveEndGroup");
            this.moveEndGroup.Name = "moveEndGroup";
            this.moveEndGroup.TabStop = false;
            // 
            // ZMoveEnd
            // 
            this.ZMoveEnd.AllowDrop = true;
            this.ZMoveEnd.DecimalPlaces = 10;
            resources.ApplyResources(this.ZMoveEnd, "ZMoveEnd");
            this.ZMoveEnd.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.ZMoveEnd.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.ZMoveEnd.Name = "ZMoveEnd";
            // 
            // textBox9
            // 
            resources.ApplyResources(this.textBox9, "textBox9");
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            // 
            // XMoveEnd
            // 
            this.XMoveEnd.AllowDrop = true;
            this.XMoveEnd.DecimalPlaces = 10;
            resources.ApplyResources(this.XMoveEnd, "XMoveEnd");
            this.XMoveEnd.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.XMoveEnd.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.XMoveEnd.Name = "XMoveEnd";
            // 
            // textBox10
            // 
            resources.ApplyResources(this.textBox10, "textBox10");
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            // 
            // YMoveEnd
            // 
            this.YMoveEnd.AllowDrop = true;
            this.YMoveEnd.DecimalPlaces = 10;
            resources.ApplyResources(this.YMoveEnd, "YMoveEnd");
            this.YMoveEnd.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.YMoveEnd.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            -2147483648});
            this.YMoveEnd.Name = "YMoveEnd";
            // 
            // textBox11
            // 
            resources.ApplyResources(this.textBox11, "textBox11");
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            // 
            // bInterpolate
            // 
            resources.ApplyResources(this.bInterpolate, "bInterpolate");
            this.bInterpolate.Name = "bInterpolate";
            this.bInterpolate.UseVisualStyleBackColor = true;
            this.bInterpolate.Click += new System.EventHandler(this.BInterpolate_Click);
            // 
            // TransformDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bInterpolate);
            this.Controls.Add(this.scaleEndGroup);
            this.Controls.Add(this.bApplyTransformations);
            this.Controls.Add(this.rotateEndGroup);
            this.Controls.Add(this.LoadedMeshesList);
            this.Controls.Add(this.moveEndGroup);
            this.Controls.Add(this.FilesInFolder);
            this.Controls.Add(this.GB_Scale);
            this.Controls.Add(this.GB_Rotate);
            this.Controls.Add(this.GB_Move);
            this.Name = "TransformDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransformDialog_FormClosing);
            this.Click += new System.EventHandler(this.TransformDialog_Click);
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
            this.scaleEndGroup.ResumeLayout(false);
            this.scaleEndGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZScaleEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XScaleEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YScaleEnd)).EndInit();
            this.rotateEndGroup.ResumeLayout(false);
            this.rotateEndGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZRotEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XRotEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YRotEnd)).EndInit();
            this.moveEndGroup.ResumeLayout(false);
            this.moveEndGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZMoveEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMoveEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMoveEnd)).EndInit();
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
        private System.Windows.Forms.Button bApplyTransformations;
        private System.Windows.Forms.GroupBox scaleEndGroup;
        private System.Windows.Forms.NumericUpDown ZScaleEnd;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.NumericUpDown XScaleEnd;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.NumericUpDown YScaleEnd;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.GroupBox rotateEndGroup;
        private System.Windows.Forms.NumericUpDown ZRotEnd;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.NumericUpDown XRotEnd;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.NumericUpDown YRotEnd;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.GroupBox moveEndGroup;
        private System.Windows.Forms.NumericUpDown ZMoveEnd;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.NumericUpDown XMoveEnd;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.NumericUpDown YMoveEnd;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button bInterpolate;
    }
}