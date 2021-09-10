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
    public partial class MDIParent : Form
    {
        

        public MDIParent()
        {
            InitializeComponent();
        }

        private void mnuProductMaster_Click(object sender, EventArgs e)
        {
            //frmProductMaster f = new frmProductMaster();
            frmProductList f = new frmProductList();
            f.ShowDialog();
        }

        private void mnuInvoice_Click(object sender, EventArgs e)
        {
            frmInvoiceList f = new frmInvoiceList();
          
            f.ShowDialog();
        }

        private void taxMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaxMaster f = new frmTaxMaster();

            f.ShowDialog();
        }

        private void toolStripMnuCustomer_Click(object sender, EventArgs e)
        {
            frmMaParty f = new frmMaParty();

            f.ShowDialog();
        }
    }
}
