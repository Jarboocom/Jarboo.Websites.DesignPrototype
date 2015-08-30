using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Website.Domain.Leads;

namespace Website.Database
{
    public class JarbooContext:DbContext
    {
        public JarbooContext():base("JarbooContext")
        {
            
        }

        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}