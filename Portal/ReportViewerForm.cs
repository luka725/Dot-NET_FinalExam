using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using Portal.Classes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portal
{
    public partial class ReportViewerForm : Form
    {
        public ReportViewerForm()
        {
            InitializeComponent();
        }

        private void ReportViewerForm_Load(object sender, EventArgs e)
        {
            List<SubjectAverage> subjectAverages = DatabaseHelper.Instance.GetSubjectAverages();
            ReportDataSource reportDataSource = new ReportDataSource("SubjectAverageDataSet", subjectAverages);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.RefreshReport();

            List<SubjectUserGradesSummary> summaryData = DatabaseHelper.Instance.GetSubjectUserGradeSummary();
            ReportDataSource reportDataSource2 = new ReportDataSource("SubjectUserGradeSummary", summaryData);
            reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            reportViewer2.RefreshReport();
        }
    }
}
