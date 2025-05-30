using System.Data.Entity;
using Novus_Catalog.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Novus_Catalog.DAL
{
    public class NovusContext : DbContext
    {
        public NovusContext() : base("NovusContext")
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Students> Students { get; set; }

        public DbSet<Students_Deleted> Students_Deleted { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}