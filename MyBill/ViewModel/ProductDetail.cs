using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBill.ViewModel
{
    public class ProductDetail
    {
        public Int32 PrId { get; set; }
        public Int32 Pr_TaxID { get; set; }
        public string PrCode { get; set; }
        public string PrDesc { get; set; }
        public decimal PrOpenBalance { get; set; }
        public decimal PrPurchaseRate { get; set; }
        public decimal PrSalesRate { get; set; }
        public decimal CGSTTaxRate { get; set; }
        public decimal SGSTTaxRate { get; set; }
        public decimal IGSTTaxRate { get; set; }
        public decimal UGSTTaxRate { get; set; }
    }
}
