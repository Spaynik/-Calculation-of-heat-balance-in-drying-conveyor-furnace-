namespace KonverSywul
{
    partial class frmDiagramma
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.f = new ZedGraph.ZedGraphControl();
            this.btn_Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.f);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Exit);
            this.splitContainer1.Size = new System.Drawing.Size(831, 636);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 0;
            // 
            // f
            // 
            this.f.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.f.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.f.Location = new System.Drawing.Point(0, 0);
            this.f.Name = "f";
            this.f.ScrollGrace = 0D;
            this.f.ScrollMaxX = 0D;
            this.f.ScrollMaxY = 0D;
            this.f.ScrollMaxY2 = 0D;
            this.f.ScrollMinX = 0D;
            this.f.ScrollMinY = 0D;
            this.f.ScrollMinY2 = 0D;
            this.f.Size = new System.Drawing.Size(831, 482);
            this.f.TabIndex = 1;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.Location = new System.Drawing.Point(668, 38);
            this.btn_Exit.MaximumSize = new System.Drawing.Size(121, 31);
            this.btn_Exit.MinimumSize = new System.Drawing.Size(121, 31);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(121, 31);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.Text = "Закрыть ";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // frmDiagramma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(831, 636);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(839, 670);
            this.Name = "frmDiagramma";
            this.Text = "Диаграмма результатов расчета теплового баланса конвейерной печи";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_Exit;
        private ZedGraph.ZedGraphControl f;
    }
}