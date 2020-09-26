using Microsoft.EntityFrameworkCore;
using PaninApi.Core.Models;

namespace PaninApi.Infrastructure
{
    public class PaninApiDbContext : DbContext
    {
        public PaninApiDbContext(DbContextOptions<PaninApiDbContext> options) : base(options)
        {
        }

        public virtual DbSet<BaseUser> BaseUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Barman> Barmen { get; set; }
        public virtual DbSet<CoffeeShop> CoffeeShops { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Primary keys

            modelBuilder.Entity<BaseUser>().HasKey(_ => _.Id);
            modelBuilder.Entity<CoffeeShop>().HasKey(_ => _.Id);
            modelBuilder.Entity<Order>().HasKey(_ => _.Id);
            modelBuilder.Entity<Item>().HasKey(_ => _.Id);
            modelBuilder.Entity<OrderItem>().HasKey(_ => new {_.ItemId, _.OrderId});

            #endregion

            #region Default values

            modelBuilder.Entity<BaseUser>().Property(_ => _.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CoffeeShop>().Property(_ => _.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>().Property(_ => _.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Item>().Property(_ => _.Id).ValueGeneratedOnAdd();

            #endregion

            #region Required

            modelBuilder.Entity<BaseUser>().Property(_ => _.FamilyName).IsRequired();
            modelBuilder.Entity<BaseUser>().Property(_ => _.GivenName).IsRequired();
            modelBuilder.Entity<BaseUser>().Property(_ => _.Email).IsRequired();

            modelBuilder.Entity<Barman>().Property(_ => _.CoffeShopId).IsRequired();

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

            modelBuilder.Entity<StudentClass>().Property(_ => _.Class).IsRequired();
            modelBuilder.Entity<StudentClass>().Property(_ => _.Section).IsRequired();

            #endregion

            #region Charset

            modelBuilder.Entity<BaseUser>().Property(_ => _.FamilyName).IsUnicode();
            modelBuilder.Entity<BaseUser>().Property(_ => _.GivenName).IsUnicode();

            modelBuilder.Entity<CoffeeShop>().Property(_ => _.Name).IsUnicode();

            modelBuilder.Entity<Item>().Property(_ => _.Name).IsUnicode();
            modelBuilder.Entity<Item>().Property(_ => _.Description).IsUnicode();

            modelBuilder.Entity<Order>().Property(_ => _.Notes).IsUnicode();

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

            #endregion

            #region 1-n relationships

            modelBuilder.Entity<CoffeeShop>().HasMany(_ => _.Barmen).WithOne(_ => _.CoffeeShop)
                .HasForeignKey(_ => _.CoffeShopId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CoffeeShop>().HasMany(_ => _.Items).WithOne(_ => _.CoffeeShop)
                .HasForeignKey(_ => _.CoffeeShopId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CoffeeShop>().HasMany(_ => _.Orders).WithOne(_ => _.CoffeeShop)
                .HasForeignKey(_ => _.CoffeeShopId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasMany(_ => _.Orders).WithOne(_ => _.User).HasForeignKey(_ => _.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region n-n relationships

            modelBuilder.Entity<Order>().HasMany(_ => _.Items).WithOne(_ => _.Order).HasForeignKey(_ => _.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Item>().HasMany(_ => _.Orders).WithOne(_ => _.Item).HasForeignKey(_ => _.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}