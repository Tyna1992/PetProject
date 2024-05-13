using Microsoft.EntityFrameworkCore;
using VineyardSite.Model;

namespace VineyardSite.Data;

public class DataContext : DbContext
{
    public DbSet<Wine> Wines { get; set; }
    public DbSet<InventoryItem> Inventory { get; set; }
    public DbSet<WineVariant>   WineVariants { get; set; }
    
    public DbSet<Snack> Snacks  { get; set; }
    
    public DbSet<WineTastingPackage> WineTastingPackages { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<Appointment> Appointments { get; set; }
    
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wine>().HasIndex(w => w.Name).IsUnique();
        modelBuilder.Entity<Snack>().HasIndex(s => s.Name).IsUnique();
        modelBuilder.Entity<WineTastingPackage>().HasIndex(wtp => wtp.Name).IsUnique();
        modelBuilder.Entity<Order>().HasIndex(o => o.Id).IsUnique();
        modelBuilder.Entity<Appointment>().HasIndex(a => a.Id).IsUnique();
        modelBuilder.Entity<InventoryItem>()
            .HasIndex(i =>  i.WineVariantId)
            .IsUnique(false);
        modelBuilder.Entity<WineVariant>()
            .HasKey(wv => wv.Id);
        
        modelBuilder.Entity<WineTastingPackage>()
            .HasOne(wtp => wtp.Wine1)
            .WithMany()
            .HasForeignKey(wtp => wtp.Wine1Id)
            .IsRequired();
        
        modelBuilder.Entity<WineTastingPackage>()
            .HasOne(wtp => wtp.Wine2)
            .WithMany()
            .HasForeignKey(wtp => wtp.Wine2Id);
        
        modelBuilder.Entity<WineTastingPackage>()
            .HasOne(wtp => wtp.Wine3)
            .WithMany()
            .HasForeignKey(wtp => wtp.Wine3Id);
        
        modelBuilder.Entity<WineTastingPackage>()
            .HasOne(wtp => wtp.Wine4)
            .WithMany()
            .HasForeignKey(wtp => wtp.Wine4Id);
        
        modelBuilder.Entity<WineTastingPackage>()
            .HasOne(wtp => wtp.Snack)
            .WithMany()
            .HasForeignKey(wtp => wtp.SnackId);
        
        modelBuilder.Entity<Appointment>()
            .HasOne(user => user.User)
            .WithMany()
            .HasForeignKey(user => user.UserId)
            .IsRequired();
        
        modelBuilder.Entity<Appointment>()
            .HasOne(package => package.Package)
            .WithMany()
            .HasForeignKey(package => package.PackageId)
            .IsRequired();
        
        modelBuilder.Entity<Order>()
            .HasOne(user => user.User)
            .WithMany()
            .HasForeignKey(user => user.UserId)
            .IsRequired();
        
        modelBuilder.Entity<Order>()
            .HasOne(wine => wine.Wine)
            .WithMany()
            .HasForeignKey(wine => wine.WineId)
            .IsRequired();
        
        
        
        base.OnModelCreating(modelBuilder);
    }
}