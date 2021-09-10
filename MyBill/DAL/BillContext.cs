using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using MyBill.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyBill.DAL
{
  public  class BillContext : DbContext
    {
        public BillContext():base("name=mydbname")
        {
            this.Configuration.AutoDetectChangesEnabled = false;

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<MaTax> MaTax { get; set; }
        public DbSet<MaHSN> MaHSN { get; set; }
        public DbSet<MaParty> MaParty { get; set; }
        public DbSet<MaState> MaState { get; set; }
        public DbSet<MaUnit> MaUnit { get; set; }

    }
}
