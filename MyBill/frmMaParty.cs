using MyBill.DAL;
using MyBill.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MyBill
{
    public partial class frmMaParty : Form
    {
        public Int32 PaId;

        public frmMaParty()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validataion() == false)
                return;

            
           

            int i = 0;
            using (BillContext context = new BillContext())
            {
                MaParty Customer = new MaParty();
                Customer = context.MaParty.Where(p => p.PaID == this.PaId).FirstOrDefault();
                if(Customer != null)
                {
                    Customer.PaName = txtPaName.Text.ToUpper().Trim();
                    Customer.PaAddress1 = txtPaAddress1.Text.ToUpper().Trim();
                    Customer.PaAddress2 = txtPaAddress2.Text.ToUpper().Trim();
                    Customer.PaAddress3 = txtPaAddress3.Text.ToUpper().Trim();
                    Customer.PaPINCode = txtPaPincode.Text.Trim();
                    Customer.PaPAN = txtPaPAN.Text.ToUpper().Trim();
                    Customer.PaGSTN = txtPaGSTN.Text.ToUpper().Trim();
                    Customer.PaMailId = txtPaMailId.Text.Trim();
                    Customer.PaTypeID = 1;
                    Customer.PaMobileNo = txtMobileNo.Text.ToUpper().Trim();

                    ListItem state_selectedItem = new ListItem();
                    state_selectedItem = (ListItem)cmbState.SelectedItem;

                    Customer.PaStateID = Convert.ToInt32(state_selectedItem.Value);
                    context.Entry(Customer).State = System.Data.Entity.EntityState.Modified;
                    i = context.SaveChanges();
                }
                else
                {
                    Customer = new MaParty();
                    Customer.PaName = txtPaName.Text.ToUpper().Trim();
                    Customer.PaAddress1 = txtPaAddress1.Text.ToUpper().Trim();
                    Customer.PaAddress2 = txtPaAddress2.Text.ToUpper().Trim();
                    Customer.PaAddress3 = txtPaAddress3.Text.ToUpper().Trim();
                    Customer.PaPINCode = txtPaPincode.Text.Trim();
                    Customer.PaPAN = txtPaPAN.Text.ToUpper().Trim();
                    Customer.PaGSTN = txtPaGSTN.Text.ToUpper().Trim();
                    Customer.PaMailId = txtPaMailId.Text.Trim();
                    Customer.PaTypeID = 1;
                    Customer.PaMobileNo = txtMobileNo.Text.ToUpper().Trim();

                    ListItem state_selectedItem = new ListItem();
                    state_selectedItem = (ListItem)cmbState.SelectedItem;

                    Customer.PaStateID = Convert.ToInt32(state_selectedItem.Value);
                    context.MaParty.Add(Customer);
                    i = context.SaveChanges();
                }

                
               
               
            }
            if (i>0)
                MessageBox.Show("Customer details saved successfully...");
            else
                MessageBox.Show("Customer details not saved...");
            ClearText();
            txtPaName.Focus();

        }
        private bool Validataion()
        {
            if (string.IsNullOrWhiteSpace(this.txtPaName.Text))
            {
                MessageBox.Show("Please enter the Customer Name");
                txtPaName.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtPaAddress1.Text))
            {
                MessageBox.Show("Please enter the Address");
                txtPaAddress1.Focus();
                return false;
            }
            else if (this.cmbState.Text == string.Empty || this.cmbState.Text.ToUpper() == "--Select--".ToUpper())
            {
                MessageBox.Show("Please select the state");
                this.cmbState.Focus();
                return false;
            }
            return true;
        }
        private void LoadMasterData()
        {
            using (BillContext context = new BillContext())
            {
                List<MaState> state = context.MaState.ToList();
                cmbState.Items.Add(new ListItem("--Select--", "0"));
                foreach (MaState _state in state)
                {
                    cmbState.Items.Add(new ListItem(_state.StateName, _state.StateID.ToString()));
                }
                cmbState.SelectedIndex = 0;

            }
        }

        private void frmMaParty_Load(object sender, EventArgs e)
        {
            LoadMasterData();
            if(this.Tag.ToString()=="Edit")
            {
                LoadCustomerData();
            }
        }

        private void LoadCustomerData()
        {
            using (BillContext _billcontext = new BillContext())
            {
               MaParty Customer = _billcontext.MaParty.Find(this.PaId);
                if (Customer == null)
                    return;
                txtPaName.Tag = Customer.PaID;
                txtPaName.Text = Customer.PaName;
                txtPaAddress1.Text = Customer.PaAddress1;
                txtPaAddress2.Text = Customer.PaAddress2;
                txtPaAddress3.Text = Customer.PaAddress3;
                txtPaPincode.Text = Customer.PaPINCode;
                txtPaPAN.Text = Customer.PaPINCode;
                txtPaGSTN.Text = Customer.PaGSTN;
                txtPaMailId.Text = Customer.PaMailId;
                txtMobileNo.Text = Customer.PaMobileNo;
                cmbState.SelectItemByValue(Customer.PaStateID.ToString()); 
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearText()
        {
            txtPaName.Text = "";
            txtPaAddress1.Text = "";
            txtPaAddress2.Text = "";
            txtPaAddress3.Text = "";
            txtPaPincode.Text = "";
            txtPaPAN.Text = "";
            txtPaGSTN.Text = "";
            txtMobileNo.Text = "";
            txtPaMailId.Text = "";
            cmbState.SelectedIndex = 0;
        }
    }
}
