using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VineyardSite.Model;

namespace VineyardSite.Data;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public DbSet<Wine> Wines { get; set; }
    public DbSet<InventoryItem> Inventory { get; set; }
    public DbSet<WineVariant>   WineVariants { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wine>().HasIndex(w => w.Name).IsUnique();
        modelBuilder.Entity<Order>().HasIndex(o => o.Id).IsUnique();
        modelBuilder.Entity<User>()
            .HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<Cart>(c => c.UserId)
            .IsRequired();
        modelBuilder.Entity<InventoryItem>()
            .HasIndex(i =>  i.WineVariantId)
            .IsUnique(false);
        modelBuilder.Entity<WineVariant>()
            .HasKey(wv => wv.Id);

        modelBuilder.Entity<WineVariant>()
            .HasIndex(wv => new {wv.WineId, wv.Year, wv.Price, wv.AlcoholContent})
            .IsUnique();

        modelBuilder.Entity<Cart>()
            .HasMany(c => c.CartItems)
            .WithOne(ci => ci.Cart)
            .HasForeignKey(ci => ci.CartId);
        
        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.WineVersion)
            .WithMany()
            .HasForeignKey(ci => ci.WineVariantId)
            .IsRequired();
        modelBuilder.Entity<Order>()
            .HasOne(user => user.User)
            .WithMany()
            .HasForeignKey(user => user.UserId)
            .IsRequired();
        
        modelBuilder.Entity<Order>()
            .HasOne(wine => wine.WineVariant)
            .WithMany()
            .HasForeignKey(wine => wine.WineVariantId)
            .IsRequired();
        
        base.OnModelCreating(modelBuilder);

    }
}