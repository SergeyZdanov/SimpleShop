using Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Database
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .IsRequired();

                entity.Property(e => e.Code)
                      .IsRequired()
                      .HasMaxLength(9)
                      .HasAnnotation("RegularExpression", @"^\d{4}-\d{4}$");

                entity.HasMany(e => e.Orders)
                      .WithOne(o => o.Customer)
                      .HasForeignKey(o => o.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.OrderDate).IsRequired();
                entity.Property(e => e.Status).IsRequired()
                .HasConversion<string>();

                entity.HasMany(e => e.ItemOrders)
                      .WithOne(oi => oi.Order)
                      .HasForeignKey(oi => oi.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItems");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.ItemsCount).IsRequired();
                entity.Property(e => e.ItemPrice).IsRequired();

                entity.HasOne(oi => oi.Item)
                      .WithMany(i => i.ItemOrders)
                      .HasForeignKey(oi => oi.ItemId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Items");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Code).IsRequired()
                .HasAnnotation("RegularExpression", @"^\d{4}-\d{4}$");
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Category)
                      .HasMaxLength(30);
                entity.Property(e => e.Price)
                .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ApplicationUser>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(u => u.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*string connectionString = "Host=localhost;Port=5432;Database=OpenSpaceDB;Username=postgres;Password=111";*/
            string connectionString = "Host=localhost;Port=5050;Database=OpenSpaceDB;Username=postgres;Password=pg_pass";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
