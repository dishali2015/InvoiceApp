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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmMaPartyList f = new frmMaPartyList();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmTaxMaster f = new frmTaxMaster();

            f.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProductList f = new frmProductList();

            f.ShowDialog();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
             frmInvoiceList f = new frmInvoiceList();
          
            f.ShowDialog();
        }

        private void btnHSN_Click(object sender, EventArgs e)
        {
            frmHSNList f = new frmHSNList();

            f.ShowDialog();
        }
    }
}
