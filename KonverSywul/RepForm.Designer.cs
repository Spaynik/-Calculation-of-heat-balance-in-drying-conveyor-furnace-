﻿namespace KonverSywul
{
    partial class RepForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.cReportInputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cParamOutputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cReportInputBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cParamOutputBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cReportInputBindingSource
            // 
            this.cReportInputBindingSource.DataSource = typeof(KonverSywul.Class.cReportInput);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Input";
            reportDataSource1.Value = this.cReportInputBindingSource;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.cParamOutputBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "KonverSywul.Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // cParamOutputBindingSource
            // 
            this.cParamOutputBindingSource.DataSource = typeof(KonverSywul.Class.cParamOutput);
            // 
            // RepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RepForm";
            this.Text = "RepForm";
            this.Load += new System.EventHandler(this.RepForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cReportInputBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cParamOutputBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource cReportInputBindingSource;
        public System.Windows.Forms.BindingSource cParamOutputBindingSource;
    }
}