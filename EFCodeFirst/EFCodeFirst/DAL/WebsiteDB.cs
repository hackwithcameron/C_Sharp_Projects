using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace EFCodeFirst.DAL
{
    public class WebsiteDB : DbContext
    {

        public WebsiteDB() : base("WebsiteDB")
        {

        }

        public DbSet<NewAccount> NewAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
