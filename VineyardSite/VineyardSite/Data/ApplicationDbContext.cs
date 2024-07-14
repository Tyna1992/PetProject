using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VineyardSite.Model;
using VineyardSite.Model.Address;

namespace VineyardSite.Data;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public DbSet<Wine> Wines { get; set; }
    public DbSet<InventoryItem> Inventory { get; set; }
    public DbSet<WineVariant>   WineVariants { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<PrimaryAddress> PrimaryAddress { get; set; }
    public DbSet<Address> Addresses { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wine>().HasIndex(w => w.Name).IsUnique();
        modelBuilder.Entity<Order>().HasIndex(o => o.Id).IsUnique();

        
        modelBuilder.Entity<User>()
        .HasOne(u => u.PrimaryAddress)
        .WithOne(a => a.User)
        .HasForeignKey<PrimaryAddress>(a => a.UserId)
        .IsRequired();
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.Addresses)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .IsRequired();
        
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
            .HasOne(wv => wv.Wine)
            .WithMany()
            .HasForeignKey(wv => wv.WineId);
        
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
        
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.WineVariant)
            .WithMany()
            .HasForeignKey(oi => oi.WineVariantId)
            .IsRequired();
        
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .IsRequired();
        
        base.OnModelCreating(modelBuilder);

    }
}