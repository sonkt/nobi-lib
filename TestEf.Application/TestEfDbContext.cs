using Microsoft.EntityFrameworkCore;

namespace TestEf.Application
{
    public class TestEfDbContext : DbContext
    {
        public DbSet<TestEfEntity> TestEfEntities { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }

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

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(p => p.Posts)
                .UsingEntity("PostsToTags",
                    l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("FK_TagId"),
                    r => r.HasOne(typeof(Post)).WithMany().HasForeignKey("FK_PostId"),
                    j => j.HasKey("FK_TagId", "FK_PostId")
                );
        }
    }
}