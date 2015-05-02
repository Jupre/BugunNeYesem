using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using BugunNeYesem.Data.Entity;

namespace BugunNeYesem.Data
{
    public class BugunNeYesemDbContext : DbContext
    {

        public DbSet<Venue> Venue { get; set; }
        public DbSet<Recommendation> Recommendation { get; set; }
        public DbSet<RequestHistory> RequestHistory { get; set; }



        public BugunNeYesemDbContext()
        {
            Configuration.AutoDetectChangesEnabled = false;
        }
        static BugunNeYesemDbContext()
        {
            Database.SetInitializer(new NullDatabaseInitializer<BugunNeYesemDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //to let NumberPercentStrategy to save data with decimal places
            //EF was saving only 2 places before this edit
            //modelBuilder.Entity<FieldValue>().Property(e => e.ValueDecimal).HasColumnType("Decimal").HasPrecision(18, 6);
        }
       
    }
    public sealed class BugunNeYesemDbContextMigrationConfiguration : DbMigrationsConfiguration<BugunNeYesemDbContext>
    {
        public BugunNeYesemDbContextMigrationConfiguration()
        {
            AutomaticMigrationsEnabled =
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BugunNeYesemDbContext context)
        { }
    }

}
