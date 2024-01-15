using Microsoft.EntityFrameworkCore;

namespace Test.Application
{
    public class TestDbContext:DbContext
    {

        public DbSet<TestEntity> TestEntities { get; set; }
        public TestDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TestEntity>().ToTable("TestEntities");

            modelBuilder.Entity<TestEntity>().Property(c => c.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<TestEntity>().Property(c => c.CreatedDate).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<TestEntity>().Property(c => c.CreatedUser).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
        }
    }
}
