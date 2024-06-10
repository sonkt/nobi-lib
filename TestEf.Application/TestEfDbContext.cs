using Microsoft.EntityFrameworkCore;

namespace TestEf.Application
{
    public class TestEfDbContext : DbContext
    {
        public DbSet<TestEfEntity> TestEfEntities { get; set; }

        public TestEfDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TestEfEntity>().ToTable("TestEfEntities");

            modelBuilder.Entity<TestEfEntity>().Property(c => c.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<TestEfEntity>().Property(p=>p.RowVersion).IsConcurrencyToken();
            modelBuilder.Entity<TestEfEntity>().Property(c => c.CreatedDate).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<TestEfEntity>().Property(c => c.CreatedUser).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
        }
    }
}