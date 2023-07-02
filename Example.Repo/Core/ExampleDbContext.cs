using Example.Repo.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Example.Repo.Core
{
    public class ExampleDbContext: DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options)
            : base(options)
        { }

        public virtual DbSet<PersonEntity> Persons { get; set; }
        public virtual DbSet<OrganizationEntity> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema($"{nameof(ExampleDbContext)}");
        }

    }
}
