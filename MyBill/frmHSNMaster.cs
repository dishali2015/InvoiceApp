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
    public partial class frmHSNMaster : Form
    {
        public Int32 HSNId;
        public frmHSNMaster()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validataion() == false)
            { 
                return;
            }
            int i = 0;
            using (BillContext context = new BillContext())
            {
                MaHSN HSN = new MaHSN();
                HSN = context.MaHSN.Where(p => p.HSNId == this.HSNId).FirstOrDefault();
                if (HSN != null)
                {
                    HSN.HSNCode = txtHSNCode.Text.ToUpper().Trim();
                    HSN.HSNDescription = txtHSNDescription.Text.ToUpper().Trim();
                    
                    context.Entry(HSN).State = System.Data.Entity.EntityState.Modified;
                    i = context.SaveChanges();
                }
                else
                {
                    HSN = new MaHSN();
                    HSN.HSNCode = txtHSNCode.Text.ToUpper().Trim();
                    HSN.HSNDescription = txtHSNDescription.Text.ToUpper().Trim();
                 
                    context.MaHSN.Add(HSN);
                    i = context.SaveChanges();
                }
                
            }
            if (i > 0)
                MessageBox.Show("HSN details saved successfully...");
            else
                MessageBox.Show("HSN details not saved...");
            ClearText();
            txtHSNCode.Focus();
        }
        private void ClearText()
        {
            txtHSNCode.Text = "";
            txtHSNDescription.Text = "";

        }
        private bool Validataion()
        {
            if(string.IsNullOrEmpty(this.txtHSNCode.Text) || 
                string.IsNullOrWhiteSpace(this.txtHSNCode.Text))
            {
                MessageBox.Show("Please enter the HSN Code");
                txtHSNCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtHSNDescription.Text) ||
                string.IsNullOrWhiteSpace(this.txtHSNDescription.Text))
            {
                MessageBox.Show("Please enter the HSN description");
                txtHSNDescription.Focus();
                return false;
            }
            return true;

        }

        private void frmHSNMaster_Load(object sender, EventArgs e)
        {
            if(this.Tag.ToString()=="Edit")
            {
                LoadHSNData();
            }
        }
        private void LoadHSNData()
        {
            using (BillContext billcontext = new BillContext())
            {
                MaHSN _mahsn = new MaHSN();
                _mahsn = billcontext.MaHSN.Find(this.HSNId);
                if(_mahsn!=null)
                {
                    txtHSNCode.Text = _mahsn.HSNCode;
                    txtHSNDescription.Text = _mahsn.HSNDescription;
                }

            }
        }
    }
}
