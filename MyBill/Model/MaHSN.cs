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
    public class MaHSN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HSNId { set; get; }
        public string HSNCode { set; get; }
        public string HSNDescription { set; get; }
       
    }
}
