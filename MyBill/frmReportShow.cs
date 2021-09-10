using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyBill
{
    public partial class frmReportShow : Form
    {
        public frmReportShow()
        {
            InitializeComponent();
        }

        private void frmReportShow_Load(object sender, EventArgs e)
        {
            if (this.Tag.ToString() == "")
                return;

            DataTable dt = new DataTable();
            string InvId = this.Tag.ToString();
            dt = Invoice.InvoicePrint(InvId);
            this.reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
             string Reportpath = System.Configuration.ConfigurationManager.AppSettings["Reportpath"] + @"InvoiceTemplate.rdlc";
            // string Reportpath = System.Configuration.ConfigurationManager.AppSettings["Reportpath"] + @"Invoice.rdlc";
            if (!System.IO.File.Exists(Reportpath))
            {
                MessageBox.Show("File not found " + Reportpath);
                return;
            }
            this.reportViewer1.LocalReport.ReportPath = Reportpath;

            Console.WriteLine(this.reportViewer1.LocalReport.ReportPath);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            // ReportDataSource rds = new ReportDataSource("DataSetabc", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
