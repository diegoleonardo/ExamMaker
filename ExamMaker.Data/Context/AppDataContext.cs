using ExamMaker.Core.Models;
using ExamMaker.Data.Map;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExamMaker.Data.Context {
    public class AppDataContext : DbContext{
        public AppDataContext() : base("ExamMakerConnString"){
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Appraiser> Appraisers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //Custom Configurations
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //Entity Mappers
            modelBuilder.Configurations.Add(new AppraiserMap());
        }
    }
}
