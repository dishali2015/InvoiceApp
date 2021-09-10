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
    public partial class frmProductMaster : Form
    {
        public frmProductMaster()
        {
            InitializeComponent();
        }

        public string ProductId;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation() == false)
                return;

            ListItem hsn_selectedItem = new ListItem();
            hsn_selectedItem = (ListItem)cmbHSN.SelectedItem;

            ListItem tax_selectedItem = new ListItem();
            tax_selectedItem = (ListItem)cmbTax.SelectedItem;

            ListItem unit_selectedItem = new ListItem();
            unit_selectedItem = (ListItem)drpUnit.SelectedItem;



            bool a = false;
            if (this.Tag.ToString().ToUpper() == "New".ToUpper())
            {
                a = Products.InsertProduct(this.txtPrCode.Text.Trim().ToUpper(),
                    this.txtPrDesc.Text.Trim().ToUpper(), unit_selectedItem.Value,
                    hsn_selectedItem.Value, tax_selectedItem.Value, Convert.ToDecimal(txtOpenBalance.Text),
                    Convert.ToDecimal(txtPurchaseRate.Text),Convert.ToDecimal(txtSalesRate.Text)
                    );

                if (a)
                    MessageBox.Show("Product is saved successfully...");
                else
                    MessageBox.Show("Product is not saved...");

                txtPrCode.Clear();
                txtPrDesc.Clear();
                cmbHSN.SelectedIndex = 0;
                cmbTax.SelectedIndex = 0;
                drpUnit.SelectedIndex = 0;
                txtOpenBalance.Clear();
                txtPurchaseRate.Clear();
                txtSalesRate.Clear();
                txtPrCode.Focus();

            }
            else
            {
                a = Products.UpdateProduct(this.ProductId, this.txtPrCode.Text.Trim().ToUpper(),
                    this.txtPrDesc.Text.Trim().ToUpper(), unit_selectedItem.Value,
                    hsn_selectedItem.Value, tax_selectedItem.Value, Convert.ToDecimal(txtOpenBalance.Text),
                    Convert.ToDecimal(txtPurchaseRate.Text), Convert.ToDecimal(txtSalesRate.Text));
                if (a)
                    MessageBox.Show("Products updated successfully...");
                else
                    MessageBox.Show("Products updation failed...");
                this.Close();
            }


        }
        private bool Validation()
        {
            if (this.txtPrCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter the Product Code...");
                this.txtPrCode.Focus();
                return false;
            }
            else if (this.txtPrDesc.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter the Product description...");
                this.txtPrDesc.Focus();
                return false;
            }
            else if (this.drpUnit.Text == string.Empty)
            {
                MessageBox.Show("Please select the unit of product...");
                this.drpUnit.Focus();
                return false;
            }
            else if (this.cmbHSN.Text == string.Empty || this.cmbHSN.Text.ToUpper() == "--Select--".ToUpper())
            {
                MessageBox.Show("Please select the HSN code...");
                this.cmbHSN.Focus();
                return false;
            }
            else if (cmbTax.Text == string.Empty || this.cmbTax.Text.ToUpper() == "--Select--".ToUpper())
            {
                MessageBox.Show("Please select the tax details");
                this.cmbTax.Focus();
                return false;
            }
            else if (txtPurchaseRate.Text == string.Empty)
            {
                MessageBox.Show("Please enter the purchase rate");
                this.txtPurchaseRate.Focus();
                return false;
            }
            else if (txtSalesRate.Text == string.Empty)
            {
                MessageBox.Show("Please enter the sales rate");
                this.txtSalesRate.Focus();
                return false;
            }

            return true;

        }

        private void frmProductMaster_Load(object sender, EventArgs e)
        {
            LoadMasterData();

            if (this.Tag.ToString().ToUpper() != "Edit".ToUpper())
                return;

            DataTable dt = new DataTable();
            dt = Products.getProduct(this.ProductId);
            if (dt.Rows.Count == 0)
            {
                this.txtPrCode.Clear();
                this.txtPrDesc.Clear();
                this.drpUnit.Text = "";
            }
            else
            {
                //Prid,PrCode,PrDesc,PrUnit
                this.txtPrCode.Text = dt.Rows[0]["PrCode"].ToString();
                this.txtPrDesc.Text = dt.Rows[0]["PrDesc"].ToString();
                this.drpUnit.Text = dt.Rows[0]["UnitDesc"].ToString();
                this.txtOpenBalance.Text = dt.Rows[0]["PrOpenBalance"].ToString();
                this.txtPurchaseRate.Text = dt.Rows[0]["PrPurchaseRate"].ToString();
                this.txtSalesRate.Text = dt.Rows[0]["PrSalesRate"].ToString();

                foreach (ListItem item in cmbHSN.Items)
                {
                    if (item.Value == dt.Rows[0]["Pr_HSNId"].ToString())
                    {
                        cmbHSN.SelectedItem = item;
                        break;
                    }
                }
                foreach (ListItem item in cmbTax.Items)
                {
                    if (item.Value == dt.Rows[0]["Pr_TaxID"].ToString())
                    {
                        cmbTax.SelectedItem = item;
                        break;
                    }
                }
            }

        }

        private void LoadMasterData()
        {
            using (BillContext context = new BillContext())
            {
                List<MaTax> tax = context.MaTax.ToList();
                cmbTax.Items.Add(new ListItem("--Select--", "0"));
                foreach (MaTax _tax in tax)
                {
                    cmbTax.Items.Add(new ListItem(_tax.TaxName, _tax.TaxId.ToString()));
                }

                List<MaHSN> hsn = context.MaHSN.OrderBy(o => o.HSNCode).ToList();
                cmbHSN.Items.Add(new ListItem("--Select--", "0"));
                foreach (MaHSN _hsn in hsn)
                {
                    cmbHSN.Items.Add(new ListItem(_hsn.HSNCode + "-" + _hsn.HSNDescription, _hsn.HSNId.ToString()));
                }

                List<MaUnit> unit = context.MaUnit.OrderBy(o => o.UnitDesc).ToList();
                drpUnit.Items.Add(new ListItem("--Select--", "0"));
                foreach (MaUnit _unit in unit)
                {
                    drpUnit.Items.Add(new ListItem(_unit.UnitDesc , _unit.UnitId.ToString()));
                }

                cmbHSN.SelectedIndex = 0;
                cmbTax.SelectedIndex = 0;
                drpUnit.SelectedIndex = 0;
            }
        }

        private void txtPrCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtOpenBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtPurchaseRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
       && !char.IsDigit(e.KeyChar)
       && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtSalesRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
       && !char.IsDigit(e.KeyChar)
       && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
