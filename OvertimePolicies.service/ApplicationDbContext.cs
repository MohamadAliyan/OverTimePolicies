
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OvertimePolicies.Service.Maps;
using OvertimePolicies.Service.Models;




namespace OvertimePolicies.Service
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {

      
            builder.Entity<Employee>().HasQueryFilter(p => !p.IsDeleted);
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            HandleDelete();
            return base.SaveChanges();
        }
        private void HandleDelete()
        {
            var entities = ChangeTracker.Entries()
                                .Where(e => e.State == EntityState.Deleted);
            foreach (var entity in entities)
            {
                if (entity.Entity is BaseEntity)
                {
                    entity.State = EntityState.Modified;
                    var entityFound = entity.Entity as BaseEntity;
                    entityFound.IsDeleted = true;
                }
            }
        }


        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory().Replace("Service", "api"))
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                builder.UseSqlServer(connectionString);

                return new ApplicationDbContext(builder.Options);
            }

        }

    }
}
