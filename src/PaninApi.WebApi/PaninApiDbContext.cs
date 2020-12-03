using Microsoft.EntityFrameworkCore;
using PaninApi.Abstractions.Models;

namespace PaninApi.WebApi
{
    public class PaninApiDbContext : DbContext
    {
        public PaninApiDbContext(DbContextOptions<PaninApiDbContext> options) : base(options)
        {
        }

        public virtual DbSet<BaseUser> BaseUsers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Barman> Barmen { get; set; }
        public virtual DbSet<CoffeeShop> CoffeeShops { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<BarmanCoffeeShop> BarmanCoffeeShops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Keys

            modelBuilder.Entity<BaseUser>().HasKey(_ => _.Id);
            modelBuilder.Entity<CoffeeShop>().HasKey(_ => _.Id);
            modelBuilder.Entity<Order>().HasKey(_ => _.Id);
            modelBuilder.Entity<Item>().HasKey(_ => _.Id);
            modelBuilder.Entity<OrderItem>().HasKey(_ => new {_.ItemId, _.OrderId});
            modelBuilder.Entity<School>().HasKey(_ => _.Id);
            modelBuilder.Entity<BarmanCoffeeShop>().HasKey(_ => new {_.BarmanId, _.CoffeeShopId});

            #endregion

            #region Default values

            modelBuilder.Entity<BaseUser>().Property(_ => _.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CoffeeShop>().Property(_ => _.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>().Property(_ => _.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Item>().Property(_ => _.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<School>().Property(_ => _.Id).ValueGeneratedOnAdd();

            #endregion

            #region Required

            modelBuilder.Entity<CoffeeShop>().Property(_ => _.Name).IsRequired();

            modelBuilder.Entity<Item>().Property(_ => _.Name).IsRequired();
            modelBuilder.Entity<Item>().Property(_ => _.Price).IsRequired();
            modelBuilder.Entity<Item>().Property(_ => _.Availability).IsRequired();
            modelBuilder.Entity<Item>().Property(_ => _.Category).IsRequired();
            modelBuilder.Entity<Item>().Property(_ => _.Description).IsRequired(false);

            modelBuilder.Entity<Order>().Property(_ => _.CoffeeShopId).IsRequired();
            modelBuilder.Entity<Order>().Property(_ => _.Status).IsRequired();
            modelBuilder.Entity<Order>().Property(_ => _.CreationDate).IsRequired();
            modelBuilder.Entity<Order>().Property(_ => _.UserId).IsRequired();
            modelBuilder.Entity<Order>().Property(_ => _.Notes).IsRequired(false);

            modelBuilder.Entity<OrderItem>().Property(_ => _.ItemId).IsRequired();
            modelBuilder.Entity<OrderItem>().Property(_ => _.OrderId).IsRequired();

            modelBuilder.Entity<BarmanCoffeeShop>().Property(_ => _.BarmanId).IsRequired();
            modelBuilder.Entity<BarmanCoffeeShop>().Property(_ => _.CoffeeShopId).IsRequired();

            modelBuilder.Entity<School>().Property(_ => _.Name).IsRequired();
            modelBuilder.Entity<School>().Property(_ => _.Tenant).IsRequired();

            modelBuilder.Entity<Student>().Property(_ => _.SchoolId).IsRequired();

            #endregion

            #region Charset

            modelBuilder.Entity<CoffeeShop>().Property(_ => _.Name).IsUnicode();

            modelBuilder.Entity<Item>().Property(_ => _.Name).IsUnicode();
            modelBuilder.Entity<Item>().Property(_ => _.Description).IsUnicode();

            modelBuilder.Entity<Order>().Property(_ => _.Notes).IsUnicode();

            modelBuilder.Entity<School>().Property(_ => _.Name).IsUnicode();
            modelBuilder.Entity<School>().Property(_ => _.Tenant).IsUnicode();

            #endregion

            #region Max length

            modelBuilder.Entity<CoffeeShop>().Property(_ => _.Name).HasMaxLength(30);

            modelBuilder.Entity<Item>().Property(_ => _.Name).HasMaxLength(30);
            
            #endregion

            #region Conversions

            modelBuilder.Entity<Item>().Property(_ => _.Modifiers).HasConversion<int>();

            #endregion

            #region Owns

            modelBuilder.Entity<Order>().OwnsOne(_ => _.Class);

            modelBuilder.Entity<Student>().OwnsOne(_ => _.StudentClass);

            #endregion

            #region 1-n relationships

            modelBuilder.Entity<CoffeeShop>().HasMany(_ => _.Items).WithOne(_ => _.CoffeeShop)
                .HasForeignKey(_ => _.CoffeeShopId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CoffeeShop>().HasMany(_ => _.Orders).WithOne(_ => _.CoffeeShop)
                .HasForeignKey(_ => _.CoffeeShopId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>().HasMany(_ => _.Orders).WithOne(_ => _.Student).HasForeignKey(_ => _.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<School>().HasMany(_ => _.Students).WithOne(_ => _.School)
                .HasForeignKey(_ => _.SchoolId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<School>().HasMany(_ => _.CoffeeShops).WithOne(_ => _.School)
                .HasForeignKey(_ => _.SchoolId).OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region n-n relationships

            modelBuilder.Entity<Order>().HasMany(_ => _.Items).WithOne(_ => _.Order).HasForeignKey(_ => _.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Item>().HasMany(_ => _.Orders).WithOne(_ => _.Item).HasForeignKey(_ => _.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CoffeeShop>().HasMany(_ => _.Barmen).WithOne(_ => _.CoffeeShop)
                .HasForeignKey(_ => _.CoffeeShopId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Barman>().HasMany(_ => _.CoffeeShops).WithOne(_ => _.Barman)
                .HasForeignKey(_ => _.BarmanId).OnDelete(DeleteBehavior.Cascade);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}