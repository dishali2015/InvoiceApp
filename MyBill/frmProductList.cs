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
    public partial class frmProductList : Form
    {
        public frmProductList()
        {
            InitializeComponent();
        }

        private void frmProductList_Load(object sender, EventArgs e)
        {
            DisplayProduct();
        }
        private void DisplayProduct()
        {
            this.lstProduct.Items.Clear();
            DataTable dt = new DataTable();
            dt = Products.getProduct();
            if (dt.Rows.Count == 0)
                return;
            int i;
            ListViewItem node;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                node = new ListViewItem();

                node.Text =(i+1).ToString();
                node.SubItems.Add(dt.Rows[i]["PrCode"].ToString());
                node.SubItems.Add(dt.Rows[i]["PrDesc"].ToString());
                node.SubItems.Add(dt.Rows[i]["Prid"].ToString());
                node.SubItems.Add(dt.Rows[i]["UnitDesc"].ToString());
               
                this.lstProduct.Items.Add(node);
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductMaster f = new frmProductMaster();
            f.Tag = "New";
            f.ShowDialog();
            DisplayProduct();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.lstProduct.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the product...");
                return;
            }
            string PId = lstProduct.SelectedItems[0].SubItems[3].Text.ToString();

            frmProductMaster f = new frmProductMaster();
            f.Tag = "Edit";
            f.ProductId = PId;
            f.ShowDialog();
            DisplayProduct();
            //ProductId
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lstProduct.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the product...");
                return;
            }
            string PId = lstProduct.SelectedItems[0].SubItems[3].Text.ToString();

            if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            bool a = Products.DeleteProduct(PId);
            if (a)
                MessageBox.Show("Products deleted successfully...");
            else
                MessageBox.Show("Products deletion failed...");
            DisplayProduct();

        }
    }
}
