using MyBill.DAL;
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
    public partial class frmMaPartyList : Form
    {
        public frmMaPartyList()
        {
            InitializeComponent();
        }

        private void LoadCustomer()
        {
            using (BillContext InvoiceEntities = new BillContext())
            {
                List<getPartyList_Result> PartyList =
                    InvoiceEntities.Database.SqlQuery<getPartyList_Result>("getPartyList").ToList();
                listCustomer.Items.Clear();
                int i;
                ListViewItem node;

                foreach (getPartyList_Result _party in PartyList)
                {
                    node = new ListViewItem();

                    node.Text = _party.PaName;
                    node.SubItems.Add(_party.PaAddress1);
                    node.SubItems.Add(_party.PaAddress2);
                    node.SubItems.Add(_party.PaAddress3);
                    node.SubItems.Add(_party.PaPINCode);


                    node.SubItems.Add(_party.PaGSTN);
                    node.SubItems.Add(_party.PaPAN);
                    node.SubItems.Add(_party.PaMailId);
                    node.SubItems.Add(_party.PaMobileNo);
                    node.SubItems.Add(_party.StateName);
                    node.SubItems.Add(_party.PaID.ToString());

                    this.listCustomer.Items.Add(node);

                }

            }
        }

        private void frmMaPartyList_Load(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMaParty f = new frmMaParty();
            f.Tag = "Add";
            f.ShowDialog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (this.listCustomer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the customer...");
                return;
            }
            string Paid = listCustomer.SelectedItems[0].SubItems[10].Text.ToString();

            frmMaParty f = new frmMaParty();
            f.Tag = "Edit";
            f.PaId = Convert.ToInt32(Paid);
            f.ShowDialog();
            LoadCustomer();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }
    }
}
