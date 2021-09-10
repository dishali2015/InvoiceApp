using MyBill.DAL;
using MyBill.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyBill
{
    public partial class frmTaxMaster : Form
    {
        public frmTaxMaster()
        {
            InitializeComponent();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation() == false)
            {
                return;
            }
            try
            {
                MaTax tax = new MaTax()
                {
                    TaxName = txtTaxName.Text,
                    CGSTCaption = txtCGSTCaption.Text,
                    CGSTTaxRate = Convert.ToDecimal(txtCGSTRate.Text),
                    IGSTCaption = txtIGSTCaption.Text,
                    IGSTTaxRate = Convert.ToDecimal(txtIGSTRate.Text),
                    SGSTCaption = txtSGSTCaption.Text,
                    SGSTTaxRate = Convert.ToDecimal(txtSGSTRate.Text),
                    UGSTCaption = txtUGSTCaption.Text,
                    UGSTTaxRate = Convert.ToDecimal(txtUGSTRate.Text)
                };

                bool result = Tax.SaveTaxMaxter(tax);
                if (result == false)
                {
                    MessageBox.Show("Tax Details not saved");
                    return;
                }
                else
                {
                    MessageBox.Show("Tax Details saved");
                    this.Close();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }


        }
        private bool Validation()
        {
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
