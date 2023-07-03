using Example.Service.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Example.Service.Core.Data
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options)
           : base(options)
        { }

        public virtual DbSet<PersonEntity> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema($"{nameof(ExampleDbContext)}");
        }

    }
}
