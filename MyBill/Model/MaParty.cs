using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyBill.Model
{
    public class MaParty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaID { set; get; }
        public string PaName { set; get; }
        public string PaAddress1 { set; get; }
        public string PaAddress2 { set; get; }
        public string PaAddress3 { set; get; }
        public string PaPINCode { set; get; }
        public string PaGSTN { set; get; }
        public string PaPAN { set; get; }
        public string PaMobileNo { set; get; }
        public string PaMailId { set; get; }
        public Int32 PaStateID { set; get; }
        public Int32 PaTypeID { set; get; }        
    }
}
