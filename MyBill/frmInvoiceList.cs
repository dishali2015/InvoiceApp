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
    public partial class frmInvoiceList : Form
    {
        public frmInvoiceList()
        {
            InitializeComponent();
        }

        private void frmInvoiceList_Load(object sender, EventArgs e)
        {
            this.dtpFrom.MaxDate = System.DateTime.Now.Date ;

            this.dtpTo.MaxDate = System.DateTime.Now.Date;


            this.dtpFrom.Value = System.DateTime.Now.Date.AddDays(-2);
            this.dtpTo.Value = System.DateTime.Now.Date;
            InvoiceMainList();
        }

        private void InvoiceMainList()
        {
         
            DataTable dt = new DataTable();
            dt = Invoice.getInvoiceMainList(DateTime.Parse(this.dtpFrom.Text), DateTime.Parse(this.dtpTo.Text));
            this.lstMain.Items.Clear();
            if (dt.Rows.Count == 0)
                return;
            int i;
            ListViewItem node;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                node = new ListViewItem();
                node.Text = dt.Rows[i]["InvoiceNo"].ToString();
                node.SubItems.Add(Convert.ToDateTime(dt.Rows[i]["InvoiceDate"].ToString()).ToString("dd-MMM-yyyy"));
                node.SubItems.Add(dt.Rows[i]["InvoiceNetAmount"].ToString());             
                
                node.SubItems.Add(dt.Rows[i]["PaName"].ToString());              
             
                node.SubItems.Add(dt.Rows[i]["InvoiceId"].ToString());
                if (dt.Rows[i]["InvoiceStatus"].ToString() == "0")
                    node.BackColor = Color.Gray;

                this.lstMain.Items.Add(node);
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            InvoiceMainList();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            InvoiceMainList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmInvoice f = new frmInvoice();
            f.Tag = "Add";
            f.ShowDialog();
            InvoiceMainList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstMain.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please the invoice...");
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to delete the invoice.","Invoice Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;
            
            string InvId;
            InvId = this.lstMain.SelectedItems[0].SubItems[4].Text;
            bool a = Invoice.DeleteInvoice(InvId);
            if (a)
                MessageBox.Show("Invoice Deleted...");
            else
                MessageBox.Show("Invoice deletion failed...");
            InvoiceMainList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lstMain.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the invoice...");
                return;
            }         
         
            string InvId;
            InvId = this.lstMain.SelectedItems[0].SubItems[4].Text;

            frmReportShow f = new frmReportShow();
            f.Tag = InvId;
            f.ShowDialog();

           

        }

      

        private void btnPrintA4_Click(object sender, EventArgs e)
        {
            if (lstMain.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the invoice...");
                return;
            }
            DataTable dt = new DataTable();
            string InvId;
            InvId = this.lstMain.SelectedItems[0].SubItems[6].Text;
            dt = Invoice.InvoicePrint(InvId);
            //frmReportShow f = new frmReportShow();

            //InvoicePrePrint rpt = new InvoicePrePrint();

            //rpt.SetDataSource(dt);
            
            //f.CRV.ReportSource = rpt;
          ////  f.Text = "Invoice Print";
          //  f.ShowDialog();
        }

        private void btnDotMatrix_Click(object sender, EventArgs e)
        {
            if (lstMain.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the invoice...");
                return;
            }
            DataTable dt = new DataTable();
            string InvId;
            InvId = this.lstMain.SelectedItems[0].SubItems[6].Text;
            dt = Invoice.InvoicePrint(InvId);
            //frmReportShow f = new frmReportShow();

            //InvoicePrePrint rpt = new InvoicePrePrint();

            //rpt.SetDataSource(dt);
          //  rpt.PrintToPrinter(1, false, 1, 100);
            
        }
    }
}
