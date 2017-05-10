using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models.Context
{
    public class NSDbContext : DbContext
    {
        public NSDbContext() : base("NSDbContext")
        {
        }

        public DbSet<GroupModel> Groups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}