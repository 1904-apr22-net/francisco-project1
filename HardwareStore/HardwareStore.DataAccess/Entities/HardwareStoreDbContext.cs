using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HardwareStore.DataAccess.Entities
{
    public partial class HardwareStoreDbContext : DbContext
    {
        public HardwareStoreDbContext()
        {
        }

        public HardwareStoreDbContext(DbContextOptions<HardwareStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrder { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<StoreLocation> StoreLocation { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DefaultLocationId).HasColumnName("default_location_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(30);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phone_number")
                    .HasMaxLength(20);

                entity.HasOne(d => d.DefaultLocation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.DefaultLocationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_customer_default_location_id");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__customer__46596229C3408A5A");

                entity.ToTable("customer_order");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.OrderTime).HasColumnName("order_time");

                entity.Property(e => e.OrderTotal)
                    .HasColumnName("order_total")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_customer_order_customer_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.CustomerOrder)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_customer_order_location_id");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.LocationId, e.ProductId })
                    .HasName("PK__inventor__336816359EC9DEB3");

                entity.ToTable("inventory");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.AmountInStock).HasColumnName("amount_in_stock");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_inventory_location_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_inventory_product_id");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.OrderItemNumber })
                    .HasName("PK__order_it__2C81AB5688CAF7B3");

                entity.ToTable("order_item");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OrderItemNumber).HasColumnName("order_item_number");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.QuantityBought).HasColumnName("quantity_bought");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_order_item_order_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_order_item_product_id");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__products__47027DF51EB45914");

                entity.ToTable("products");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("product_description")
                    .HasMaxLength(150);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(20);

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("product_price")
                    .HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<StoreLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__store_lo__771831EAC8624139");

                entity.ToTable("store_location");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.LocationAddress)
                    .IsRequired()
                    .HasColumnName("location_address")
                    .HasMaxLength(60);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasColumnName("location_name")
                    .HasMaxLength(20);
            });
        }
    }
}
