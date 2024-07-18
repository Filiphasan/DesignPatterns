using Microsoft.EntityFrameworkCore;
using ObserverDp.Common.Entities;

namespace ObserverDp.Data;

public class NewsletterDbContext(DbContextOptions<NewsletterDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryUser> CategoryUsers { get; set; }
    public DbSet<Newsletter> Newsletters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(user =>
        {
            user.HasKey(x => x.Id);
            user.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            user.HasMany(x => x.CategoryUsers)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            user.HasData(new User
            {
                Id = 1,
                Name = "User 1",
                Email = "p3Jt0@example.com"
            });
        });

        modelBuilder.Entity<Category>(category =>
        {
            category.HasKey(x => x.Id);
            category.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            category.HasMany(x => x.CategoryUsers)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            category.HasMany(x => x.Newsletters)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            category.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Category 1",
                }
            );
        });

        modelBuilder.Entity<CategoryUser>(categoryUser =>
        {
            categoryUser.HasKey(x => x.Id);
            categoryUser.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            categoryUser.HasOne(x => x.User)
                .WithMany(x => x.CategoryUsers)
                .HasForeignKey(x => x.UserId);

            categoryUser.HasOne(x => x.Category)
                .WithMany(x => x.CategoryUsers)
                .HasForeignKey(x => x.CategoryId);

            categoryUser.HasData(
                new CategoryUser()
                {
                    Id = 1,
                    UserId = 1,
                    CategoryId = 1
                }
            );
        });

        modelBuilder.Entity<Newsletter>(newsletter =>
        {
            newsletter.HasKey(x => x.Id);
            newsletter.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            newsletter.HasOne(x => x.Category)
                .WithMany(x => x.Newsletters)
                .HasForeignKey(x => x.CategoryId);
        });
    }
}