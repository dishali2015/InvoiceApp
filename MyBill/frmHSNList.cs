using MyBill.DAL;
using MyBill.Model;
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
    public partial class frmHSNList : Form
    {
        public frmHSNList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHSNMaster f = new frmHSNMaster();
            f.Tag = "Add";
            f.ShowDialog();
            LoadHSNData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHSNList_Load(object sender, EventArgs e)
        {
            LoadHSNData();
        }
        private void LoadHSNData()
        {
            listHSN.Items.Clear();
            using (BillContext context = new BillContext())
            {
                ListViewItem node;
                foreach (MaHSN _hsn in context.MaHSN.OrderBy(a=>a.HSNCode).ToList())
                {
                    node = new ListViewItem();
                    node.Text = _hsn.HSNCode;
                    node.SubItems.Add(_hsn.HSNDescription);
                    node.SubItems.Add(_hsn.HSNId.ToString());                    
                    this.listHSN.Items.Add(node);
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (this.listHSN.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the HSN...");
                return;
            }
            string HSNID = listHSN.SelectedItems[0].SubItems[2].Text.ToString();

            frmHSNMaster f = new frmHSNMaster();
            f.Tag = "Edit";
            f.HSNId = Convert.ToInt32(HSNID);
            f.ShowDialog();
            LoadHSNData();
        }
    }
}
