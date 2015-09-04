using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Services.Domain.Case;
using Services.Domain.Leads;

namespace Services.Database
{
    public class JarbooContext:DbContext
    {
        public JarbooContext():base("JarbooContext")
        {
            
        }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<Case> Cases { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}