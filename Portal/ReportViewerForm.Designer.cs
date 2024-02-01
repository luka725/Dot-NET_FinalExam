namespace Portal
{
    partial class ReportViewerForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dataTable1BindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.subjectAverageDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subjectAverageDataSet = new Portal.SubjectAverageDataSet();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subjectAverageDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataTable1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.subjectAverageDataSetBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectAverageDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectAverageDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectAverageDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectAverageDataSetBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTable1BindingSource2
            // 
            this.dataTable1BindingSource2.DataMember = "DataTable1";
            this.dataTable1BindingSource2.DataSource = this.subjectAverageDataSetBindingSource;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.subjectAverageDataSetBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Portal.SubjectAverageReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 41);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(244, 410);
            this.reportViewer1.TabIndex = 1;
            // 
            // subjectAverageDataSetBindingSource
            // 
            this.subjectAverageDataSetBindingSource.DataSource = this.subjectAverageDataSet;
            this.subjectAverageDataSetBindingSource.Position = 0;
            // 
            // subjectAverageDataSet
            // 
            this.subjectAverageDataSet.DataSetName = "SubjectAverageDataSet";
            this.subjectAverageDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.subjectAverageDataSet;
            // 
            // subjectAverageDataSetBindingSource1
            // 
            this.subjectAverageDataSetBindingSource1.DataSource = this.subjectAverageDataSet;
            this.subjectAverageDataSetBindingSource1.Position = 0;
            // 
            // dataTable1BindingSource1
            // 
            this.dataTable1BindingSource1.DataMember = "DataTable1";
            this.dataTable1BindingSource1.DataSource = this.subjectAverageDataSet;
            // 
            // subjectAverageDataSetBindingSource2
            // 
            this.subjectAverageDataSetBindingSource2.DataSource = this.subjectAverageDataSet;
            this.subjectAverageDataSetBindingSource2.Position = 0;
            // 
            // reportViewer2
            // 
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Portal.SubjectUserGradeSummary.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(276, 41);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(347, 410);
            this.reportViewer2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Each Subject and Average Grades";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sum of grades for each Studen on Enrolled Subject";
            // 
            // ReportViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportViewerForm";
            this.Text = "ReportViewerForm";
            this.Load += new System.EventHandler(this.ReportViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectAverageDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectAverageDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectAverageDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectAverageDataSetBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource subjectAverageDataSetBindingSource;
        private SubjectAverageDataSet subjectAverageDataSet;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private System.Windows.Forms.BindingSource subjectAverageDataSetBindingSource1;
        private System.Windows.Forms.BindingSource dataTable1BindingSource1;
        private System.Windows.Forms.BindingSource subjectAverageDataSetBindingSource2;
        private System.Windows.Forms.BindingSource dataTable1BindingSource2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}