using MyBill.DAL;
using MyBill.Model;
using MyBill.ViewModel;
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
    public partial class frmInvoice : Form
    {
        public frmInvoice()
        {
            InitializeComponent();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            this.Tag = "Add";

            this.dtpInvDate.Value = System.DateTime.Now;

            this.dtpInvDate.MaxDate = System.DateTime.Now;


            if (this.Tag.ToString() == "Add")
            {
                DisplayInvoiceNo();
            }
            loadProducts();
            drpPrCode.Text = "";
            this.drpPrDesc.Text = "";
        }

        private void DisplayInvoiceNo()
        {
            DataTable dt = new DataTable();
            dt = Invoice.getInvoiceNo();
            if (dt.Rows.Count == 0)
                this.txtInvNo.Text = "1";
            else
                this.txtInvNo.Text = dt.Rows[0]["InvoiceNo"].ToString();
        }


        private void CalcAmount()
        {
            decimal Qty;
            decimal Rate;
            decimal Amount;

            decimal CGSTTaxRate = lblCGST.Text.Replace("*","").Trim().Length > 0 ? Convert.ToDecimal(lblCGST.Text) : 0;
            decimal SGSTTaxRate = lblSGST.Text.Replace("*", "").Trim().Length > 0 ? Convert.ToDecimal(lblSGST.Text) : 0;
            decimal IGSTTaxRate = lblIGST.Text.Replace("*", "").Trim().Length > 0 ? Convert.ToDecimal(lblIGST.Text) : 0;
            decimal UGSTTaxRate = lblUGST.Text.Replace("*", "").Trim().Length > 0 ? Convert.ToDecimal(lblUGST.Text) : 0;

            Qty = this.txtQty.Text.Trim().Length > 0 ? decimal.Parse(this.txtQty.Text.Trim()) : 0;

            Rate = this.txtRate.Text.Trim().Length > 0 ? decimal.Parse(this.txtRate.Text) : 0;

            // Tax = this.txtTax.Text.Trim().Length > 0 ? double.Parse(this.txtTax.Text.Trim()) : 0;

            Amount = Qty * Rate;

            Amount = Math.Floor(Amount * 100) / 100;

            txtGrossAmount.Text = Amount.ToString("0.00");

            decimal CGSTAmount = Amount * CGSTTaxRate / (decimal)100.00;
            decimal SGSTAmount = Amount * SGSTTaxRate / (decimal)100.00;
            decimal IGSTAmount = Amount * IGSTTaxRate / (decimal)100.00;
            decimal UGSTAmount = Amount * UGSTTaxRate / (decimal)100.00;

            CGSTAmount = Math.Floor(CGSTAmount * 100) / 100;
            SGSTAmount = Math.Floor(SGSTAmount * 100) / 100;
            IGSTAmount = Math.Floor(IGSTAmount * 100) / 100;
            UGSTAmount = Math.Floor(UGSTAmount * 100) / 100;

            // Math.Floor(123456.646 * 100) / 100

            txtCGST.Text = CGSTAmount.ToString("0.00");
            txtSGST.Text = SGSTAmount.ToString("0.00");
            txtIGST.Text = IGSTAmount.ToString("0.00");
            txtUGST.Text = UGSTAmount.ToString("0.00");

            decimal TotalTax = CGSTAmount + SGSTAmount + IGSTAmount + UGSTAmount;

            this.txtTaxAmount.Text = TotalTax.ToString("0.00");

            this.txtAmount.Text = (Amount + TotalTax).ToString("0.00");



        }
        private void loadProducts()
        {
            //Prid,PrCode,PrDesc,PrUnit
            DataTable dt = new DataTable();
            dt = Products.getProduct();

            foreach (DataRow dr in dt.Rows)
            {
                drpPrCode.Items.Add(new System.Web.UI.WebControls.ListItem(dr["PrCode"].ToString(), dr["Prid"].ToString()));
                drpPrDesc.Items.Add(new System.Web.UI.WebControls.ListItem(dr["PrDesc"].ToString(), dr["Prid"].ToString()));
            }


            using (BillContext context = new BillContext())
            {
                List<MaParty> party = context.MaParty.Where(a => a.PaTypeID == 1).ToList();

                cmbCustomer.Items.Add(new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                foreach (MaParty _party in party)
                {
                    cmbCustomer.Items.Add(new System.Web.UI.WebControls.ListItem(_party.PaName, _party.PaID.ToString()));
                }
                cmbCustomer.SelectedIndex = 0;
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            CalcAmount();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void CalcNetAmount()
        {
            decimal CGSTAmount = 0;
            decimal SGSTAmount = 0;
            decimal IGSTAmount = 0;
            decimal UGSTAmount = 0;
            decimal GrossAmt = 0;
            decimal NetAmt = 0;
            decimal TaxAmt = 0;

            foreach (ListViewItem lvItem in lstInvoice.Items)
            {
                GrossAmt += Convert.ToDecimal(lvItem.SubItems[5].Text);
                CGSTAmount += Convert.ToDecimal(lvItem.SubItems[7].Text);
                SGSTAmount += Convert.ToDecimal(lvItem.SubItems[9].Text);
                IGSTAmount += Convert.ToDecimal(lvItem.SubItems[11].Text);
                UGSTAmount += Convert.ToDecimal(lvItem.SubItems[13].Text);

                TaxAmt += Convert.ToDecimal(lvItem.SubItems[14].Text);
                NetAmt += Convert.ToDecimal(lvItem.SubItems[15].Text);

            }
            txtNetCGST.Text = CGSTAmount.ToString("0.00");
            txtNetSGST.Text = SGSTAmount.ToString("0.00");
            txtNetIGST.Text = IGSTAmount.ToString("0.00");
            txtNetUGST.Text = UGSTAmount.ToString("0.00");

            this.txtGrossTotal.Text = GrossAmt.ToString("0.00");
            this.txtTaxTotal.Text = TaxAmt.ToString("0.00");
            this.txtNetAmt.Text = NetAmt.ToString("0.00");

            decimal RoundOff = Math.Round(NetAmt, 0, MidpointRounding.AwayFromZero) - NetAmt;
            txtRoundOff.Text = RoundOff.ToString("0.00");
            txtInvoiceValue.Text = (NetAmt + RoundOff).ToString("0.00");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            System.Web.UI.WebControls.ListItem Product_selectedItem = new System.Web.UI.WebControls.ListItem();
            Product_selectedItem = (System.Web.UI.WebControls.ListItem)drpPrCode.SelectedItem;
            if(Product_selectedItem==null)
            {
                MessageBox.Show("Please select the product...");
                drpPrCode.Focus();
                return;
            }
            string Prid = Product_selectedItem.Value.ToString();
            string PrCode = this.drpPrCode.Text;
            string PrDesc = this.drpPrDesc.Text;
            double Qty = this.txtQty.Text.Trim().Length > 0 ? double.Parse(this.txtQty.Text.Trim()) : 0;
            double Rate = this.txtRate.Text.Trim().Length > 0 ? double.Parse(this.txtRate.Text) : 0;
            decimal GrossAmount = Convert.ToDecimal(txtGrossAmount.Text);
            decimal CGSTTaxRate = lblCGST.Text.Trim().Length > 0 ? Convert.ToDecimal(lblCGST.Text) : 0;
            decimal SGSTTaxRate = lblSGST.Text.Trim().Length > 0 ? Convert.ToDecimal(lblSGST.Text) : 0;
            decimal IGSTTaxRate = lblIGST.Text.Trim().Length > 0 ? Convert.ToDecimal(lblIGST.Text) : 0;
            decimal UGSTTaxRate = lblUGST.Text.Trim().Length > 0 ? Convert.ToDecimal(lblUGST.Text) : 0;

            decimal CGSTAmount = Convert.ToDecimal(txtCGST.Text);
            decimal SGSTAmount = Convert.ToDecimal(txtSGST.Text);
            decimal IGSTAmount = Convert.ToDecimal(txtIGST.Text);
            decimal UGSTAmount = Convert.ToDecimal(txtUGST.Text);

            decimal TaxAmt = Convert.ToDecimal(txtTaxAmount.Text);
            decimal NetAmount = Convert.ToDecimal(txtAmount.Text);



            int i;
            for (i = 0; i < lstInvoice.Items.Count; i++)
            {
                if (this.lstInvoice.Items[i].Text == Prid)
                {
                    MessageBox.Show("This product already selected...");
                    drpPrCode.Focus();
                    return;
                }
            }

            if (PrCode == "")
            {
                MessageBox.Show("Please enter the Product...");
                drpPrCode.Focus();
                return;
            }
            else if (Qty == 0)
            {
                MessageBox.Show("Please enter the Quantity...");
                txtQty.Focus();
                return;
            }
            else if (Rate == 0)
            {
                MessageBox.Show("Please enter the Rate...");
                txtRate.Focus();
                return;
            }
            //else if (Tax == 0)
            //{
            //    MessageBox.Show("Please enter the Quantity...");
            //    txtTax.Focus();
            //    return;
            //}

            ListViewItem node = new ListViewItem();
            node.Text = Prid;
            node.SubItems.Add(PrCode);
            node.SubItems.Add(PrDesc);
            node.SubItems.Add(Qty.ToString("0.00"));
            node.SubItems.Add(Rate.ToString("0.00"));
            node.SubItems.Add(GrossAmount.ToString("0.00"));

            node.SubItems.Add(CGSTTaxRate.ToString("0.00"));
            node.SubItems.Add(CGSTAmount.ToString("0.00"));

            node.SubItems.Add(SGSTTaxRate.ToString("0.00"));
            node.SubItems.Add(SGSTAmount.ToString("0.00"));

            node.SubItems.Add(IGSTTaxRate.ToString("0.00"));
            node.SubItems.Add(IGSTAmount.ToString("0.00"));

            node.SubItems.Add(UGSTTaxRate.ToString("0.00"));
            node.SubItems.Add(UGSTAmount.ToString("0.00"));

            node.SubItems.Add(TaxAmt.ToString("0.00"));
            node.SubItems.Add(NetAmount.ToString("0.00"));
            node.SubItems.Add(txtRate.Tag.ToString());

            this.lstInvoice.Items.Add(node);
            drpPrCode.Text = "";
            drpPrDesc.Text = "";

            txtQty.Text = "";
            txtRate.Text = "0.00";

            txtGrossAmount.Text = "0.00";

            lblCGST.Text = "0.00";
            lblSGST.Text = "0.00";
            lblIGST.Text = "0.00";
            lblUGST.Text = "0.00";

            txtCGST.Text = "0.00";
            txtSGST.Text = "0.00";
            txtIGST.Text = "0.00";
            txtUGST.Text = "0.00";

            txtTaxAmount.Text = "0.00";
            txtNetAmt.Text = "0.00";
            txtRate.Tag = "";
            drpPrCode.SelectedIndex = -1;
            drpPrDesc.SelectedIndex = -1;
            drpPrCode.Focus();
            CalcNetAmount();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvItem in lstInvoice.SelectedItems)
            {
                lstInvoice.Items.Remove(lvItem);
            }
            CalcNetAmount();
        }

        private void drpPrCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadProductRate_Tax(string Prid)
        {
            this.txtRate.Text = "";
            this.lblCGST.Text = "";
            this.lblSGST.Text = "";
            this.lblIGST.Text = "";
            this.lblUGST.Text = "";
            this.txtRate.Tag = "";
            using (BillContext context = new BillContext())
            {
                ProductDetail _product = new ProductDetail();

                _product = context.Database.SqlQuery<ProductDetail>("Exec [dbo].[getProductList] @Prid",
                    new System.Data.SqlClient.SqlParameter("@Prid", Prid)).ToList().SingleOrDefault();
                if (_product != null)
                {
                    this.txtRate.Text = _product.PrSalesRate.ToString();
                    this.txtRate.Tag = _product.Pr_TaxID.ToString();
                    this.lblCGST.Text = _product.CGSTTaxRate.ToString();
                    this.lblSGST.Text = _product.SGSTTaxRate.ToString();
                    this.lblIGST.Text = _product.IGSTTaxRate.ToString();
                    this.lblUGST.Text = _product.UGSTTaxRate.ToString();
                    txtQty.Focus();
                }
                else
                {

                }
            }

        }


        private void drpPrCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.drpPrDesc.SelectedIndex = this.drpPrCode.SelectedIndex;

            System.Web.UI.WebControls.ListItem ProductItem = new System.Web.UI.WebControls.ListItem();
            ProductItem = (System.Web.UI.WebControls.ListItem)drpPrCode.SelectedItem;
            LoadProductRate_Tax(ProductItem.Value);
        }

        private void drpPrDesc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.drpPrCode.SelectedIndex = this.drpPrDesc.SelectedIndex;
            System.Web.UI.WebControls.ListItem ProductItem = new System.Web.UI.WebControls.ListItem();
            ProductItem = (System.Web.UI.WebControls.ListItem)drpPrDesc.SelectedItem;
            LoadProductRate_Tax(ProductItem.Value);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Int32 InvoiceId;

            string InvoiceSaveRemarks = "";

            System.Web.UI.WebControls.ListItem customer_selectedItem = new System.Web.UI.WebControls.ListItem();
            customer_selectedItem = (System.Web.UI.WebControls.ListItem)cmbCustomer.SelectedItem;


            bool a = Invoice.InsertInvoiceMain(this.txtInvNo.Text, DateTime.Parse(this.dtpInvDate.Text),
                customer_selectedItem.Value.ToString(), this.txtGrossTotal.Text.Trim(),
                this.txtTaxTotal.Text.Trim(), this.txtRoundOff.Text.Trim().ToUpper(),
                this.txtInvoiceValue.Text.Trim(), out InvoiceId,out InvoiceSaveRemarks
                );

            if(a==false)
            {
                DialogResult result = MessageBox.Show("Invoice not saved. " + InvoiceSaveRemarks 
                    +"\nDo you want to generate new invoice number", "Invoice", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (this.Tag.ToString() == "Add")
                    {
                        DisplayInvoiceNo();
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            int i;
            string PrId;
            string PrQty;
            string PrRate;
            string PrTaxPer;
            string PrTaxId;
            string CGSTAmount;
            string SGSTAmount;
            string IGSTAmount;
            string UGSTAmount;


            for (i = 0; i < this.lstInvoice.Items.Count; i++)
            {
                PrId = this.lstInvoice.Items[i].Text;
                PrQty = this.lstInvoice.Items[i].SubItems[3].Text;
                PrRate = this.lstInvoice.Items[i].SubItems[4].Text;
                PrTaxPer = this.lstInvoice.Items[i].SubItems[5].Text;

                CGSTAmount = this.lstInvoice.Items[i].SubItems[7].Text;
                SGSTAmount = this.lstInvoice.Items[i].SubItems[9].Text;
                IGSTAmount = this.lstInvoice.Items[i].SubItems[11].Text;
                UGSTAmount = this.lstInvoice.Items[i].SubItems[13].Text;
                PrTaxId = this.lstInvoice.Items[i].SubItems[16].Text;

                a = Invoice.InsertInvoiceSub(InvoiceId, PrId, PrQty, PrRate, PrTaxId,
                   Convert.ToDecimal(CGSTAmount), Convert.ToDecimal(SGSTAmount),
                   Convert.ToDecimal(IGSTAmount),
                   Convert.ToDecimal(UGSTAmount)
                    );


            }
            this.Close();
            //this.txtAddress.Clear();
            //this.txtAmount.Clear();
            //this.txtCustomerId.Clear();
            //this.txtCustomerName.Clear();
            //this.txtInvNo.Clear();
            //this.txtQty.Clear();
            //this.txtRate.Clear();
            //this.txtTaxAmount.Clear();
            //this.txtTax.Clear();
            //lstInvoice.Items.Clear();
            //txtCustomerId.Focus();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCustomerId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void drpPrDesc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
