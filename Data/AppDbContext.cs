using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
 
namespace MyWebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
 
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
 
            // Configure relationships
            modelBuilder.Entity<Comment>()
                .HasOne<User>()
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);
 
            modelBuilder.Entity<Comment>()
                .HasOne<Product>()
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProductId);
 
            modelBuilder.Entity<CartItem>()
                .HasOne<User>()
                .WithMany(u => u.CartItems)
                .HasForeignKey(ci => ci.UserId);
 
            modelBuilder.Entity<CartItem>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);
 
            modelBuilder.Entity<Order>()
        .HasOne<User>() // Instead of referencing `o.User`
        .WithMany(u => u.Orders)
        .HasForeignKey(o => o.UserId);
        }
    }
}