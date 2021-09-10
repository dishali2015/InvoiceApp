using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBill.Model
{
   
    public class MaTax
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaxId { set; get; }
        public string TaxName { set; get; }

        public string CGSTCaption { set; get; }
        public decimal CGSTTaxRate { set; get; }

        public string SGSTCaption { set; get; }
        public decimal SGSTTaxRate { set; get; }

        public string IGSTCaption { set; get; }
        public decimal IGSTTaxRate { set; get; }

        public string UGSTCaption { set; get; }
        public decimal UGSTTaxRate { set; get; }
              
    }
}

