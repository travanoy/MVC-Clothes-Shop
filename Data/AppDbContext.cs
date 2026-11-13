using WorkerHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WorkerHub.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<WearSize> WearSizes { get; set; }
        public DbSet<WearColor> WearColors { get; set; }
        public DbSet<ProductWearStock> ProductWearStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");

                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(p => p.ProductWearStocks)
                    .WithOne(pws => pws.Product)
                    .HasForeignKey(pws => pws.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Category>(entity =>
            {
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(o => o.OrderItems)
                    .WithOne(oi => oi.Order)
                    .HasForeignKey(oi => oi.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(oi => oi.Price).HasColumnType("decimal(18,2)");

                entity.HasOne(oi => oi.Product)
                    .WithMany()
                    .HasForeignKey(oi => oi.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(oi => oi.WearSize)
                    .WithMany()
                    .HasForeignKey(oi => oi.WearSizeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(oi => oi.WearColor)
                    .WithMany()
                    .HasForeignKey(oi => oi.WearColorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductWearStock>(entity =>
            {
                entity.HasIndex(pws => new { pws.ProductId, pws.WearSizeId, pws.WearColorId }).IsUnique();

                entity.HasOne(pws => pws.WearSize)
                    .WithMany()
                    .HasForeignKey(pws => pws.WearSizeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pws => pws.WearColor)
                    .WithMany()
                    .HasForeignKey(pws => pws.WearColorId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasIndex(f => new { f.UserId, f.ProductId }).IsUnique();

                entity.HasOne(f => f.User)
                    .WithMany(u => u.Favorites)
                    .HasForeignKey(f => f.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(f => f.Product)
                    .WithMany()
                    .HasForeignKey(f => f.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "T-Shirts",
                    Description = "Everyday cotton tees for men and women.",
                    ImageUrl = "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab?w=600",
                    Field = "Tops"
                },
                new Category
                {
                    Id = 2,
                    Name = "Jeans",
                    Description = "Classic denim in every fit and wash.",
                    ImageUrl = "https://images.unsplash.com/photo-1542272604-787c3835535d?w=600",
                    Field = "Bottoms"
                },
                new Category
                {
                    Id = 3,
                    Name = "Jackets",
                    Description = "Stylish outerwear for every season.",
                    ImageUrl = "https://images.unsplash.com/photo-1551028719-00167b16eac5?w=600",
                    Field = "Outerwear"
                }
            );

            modelBuilder.Entity<WearSize>().HasData(
                new WearSize { Id = 1, Name = "S" },
                new WearSize { Id = 2, Name = "M" },
                new WearSize { Id = 3, Name = "L" },
                new WearSize { Id = 4, Name = "XL" },
                new WearSize { Id = 5, Name = "30" },
                new WearSize { Id = 6, Name = "32" },
                new WearSize { Id = 7, Name = "34" },
                new WearSize { Id = 8, Name = "36" }
            );

            modelBuilder.Entity<WearColor>().HasData(
                new WearColor { Id = 1, Name = "Black", HexCode = "#000000" },
                new WearColor { Id = 2, Name = "White", HexCode = "#FFFFFF" },
                new WearColor { Id = 3, Name = "Gray", HexCode = "#808080" },
                new WearColor { Id = 4, Name = "Navy", HexCode = "#000080" },
                new WearColor { Id = 5, Name = "Dark Blue", HexCode = "#1E3A5F" },
                new WearColor { Id = 6, Name = "Olive", HexCode = "#708238" },
                new WearColor { Id = 7, Name = "Red", HexCode = "#DC143C" },
                new WearColor { Id = 8, Name = "Beige", HexCode = "#F5F5DC" }
            );

            modelBuilder.Entity<ProductWearStock>().HasData(
                new ProductWearStock { Id = -1, ProductId = 1, WearSizeId = 1, WearColorId = 2, Quantity = 10 },
                new ProductWearStock { Id = -2, ProductId = 1, WearSizeId = 1, WearColorId = 4, Quantity = 10 },
                new ProductWearStock { Id = -3, ProductId = 1, WearSizeId = 1, WearColorId = 5, Quantity = 10 },
                new ProductWearStock { Id = -4, ProductId = 1, WearSizeId = 2, WearColorId = 2, Quantity = 10 },
                new ProductWearStock { Id = -5, ProductId = 1, WearSizeId = 2, WearColorId = 4, Quantity = 10 },
                new ProductWearStock { Id = -6, ProductId = 1, WearSizeId = 2, WearColorId = 5, Quantity = 10 },
                new ProductWearStock { Id = -7, ProductId = 1, WearSizeId = 3, WearColorId = 2, Quantity = 10 },
                new ProductWearStock { Id = -8, ProductId = 1, WearSizeId = 3, WearColorId = 4, Quantity = 10 },
                new ProductWearStock { Id = -9, ProductId = 1, WearSizeId = 3, WearColorId = 5, Quantity = 10 },
                new ProductWearStock { Id = -10, ProductId = 1, WearSizeId = 4, WearColorId = 2, Quantity = 10 },
                new ProductWearStock { Id = -11, ProductId = 1, WearSizeId = 4, WearColorId = 4, Quantity = 10 },
                new ProductWearStock { Id = -12, ProductId = 1, WearSizeId = 4, WearColorId = 5, Quantity = 10 },
                new ProductWearStock { Id = -13, ProductId = 2, WearSizeId = 1, WearColorId = 1, Quantity = 10 },
                new ProductWearStock { Id = -14, ProductId = 2, WearSizeId = 1, WearColorId = 2, Quantity = 10 },
                new ProductWearStock { Id = -15, ProductId = 2, WearSizeId = 1, WearColorId = 4, Quantity = 10 },
                new ProductWearStock { Id = -16, ProductId = 2, WearSizeId = 2, WearColorId = 1, Quantity = 10 },
                new ProductWearStock { Id = -17, ProductId = 2, WearSizeId = 2, WearColorId = 2, Quantity = 10 },
                new ProductWearStock { Id = -18, ProductId = 2, WearSizeId = 2, WearColorId = 4, Quantity = 10 },
                new ProductWearStock { Id = -19, ProductId = 2, WearSizeId = 3, WearColorId = 1, Quantity = 10 },
                new ProductWearStock { Id = -20, ProductId = 2, WearSizeId = 3, WearColorId = 2, Quantity = 10 },
                new ProductWearStock { Id = -21, ProductId = 2, WearSizeId = 3, WearColorId = 4, Quantity = 10 },
                new ProductWearStock { Id = -22, ProductId = 2, WearSizeId = 4, WearColorId = 1, Quantity = 10 },
                new ProductWearStock { Id = -23, ProductId = 2, WearSizeId = 4, WearColorId = 2, Quantity = 10 },
                new ProductWearStock { Id = -24, ProductId = 2, WearSizeId = 4, WearColorId = 4, Quantity = 10 },
                new ProductWearStock { Id = -25, ProductId = 3, WearSizeId = 5, WearColorId = 1, Quantity = 2 },
                new ProductWearStock { Id = -26, ProductId = 3, WearSizeId = 5, WearColorId = 5, Quantity = 5 },
                new ProductWearStock { Id = -27, ProductId = 3, WearSizeId = 6, WearColorId = 1, Quantity = 5 },
                new ProductWearStock { Id = -28, ProductId = 3, WearSizeId = 6, WearColorId = 5, Quantity = 5 },
                new ProductWearStock { Id = -29, ProductId = 3, WearSizeId = 7, WearColorId = 1, Quantity = 5 },
                new ProductWearStock { Id = -30, ProductId = 3, WearSizeId = 7, WearColorId = 5, Quantity = 5 },
                new ProductWearStock { Id = -31, ProductId = 4, WearSizeId = 6, WearColorId = 5, Quantity = 8 },
                new ProductWearStock { Id = -32, ProductId = 4, WearSizeId = 6, WearColorId = 6, Quantity = 8 },
                new ProductWearStock { Id = -33, ProductId = 4, WearSizeId = 7, WearColorId = 5, Quantity = 8 },
                new ProductWearStock { Id = -34, ProductId = 4, WearSizeId = 7, WearColorId = 6, Quantity = 8 },
                new ProductWearStock { Id = -35, ProductId = 4, WearSizeId = 8, WearColorId = 5, Quantity = 8 },
                new ProductWearStock { Id = -36, ProductId = 4, WearSizeId = 8, WearColorId = 6, Quantity = 8 },
                new ProductWearStock { Id = -37, ProductId = 5, WearSizeId = 2, WearColorId = 1, Quantity = 2 },
                new ProductWearStock { Id = -38, ProductId = 5, WearSizeId = 2, WearColorId = 6, Quantity = 4 },
                new ProductWearStock { Id = -39, ProductId = 5, WearSizeId = 3, WearColorId = 1, Quantity = 4 },
                new ProductWearStock { Id = -40, ProductId = 5, WearSizeId = 3, WearColorId = 6, Quantity = 3 },
                new ProductWearStock { Id = -41, ProductId = 6, WearSizeId = 1, WearColorId = 1, Quantity = 10 },
                new ProductWearStock { Id = -42, ProductId = 6, WearSizeId = 2, WearColorId = 1, Quantity = 10 },
                new ProductWearStock { Id = -43, ProductId = 6, WearSizeId = 3, WearColorId = 1, Quantity = 10 },
                new ProductWearStock { Id = -44, ProductId = 7, WearSizeId = 5, WearColorId = 5, Quantity = 10 },
                new ProductWearStock { Id = -45, ProductId = 7, WearSizeId = 6, WearColorId = 5, Quantity = 10 },
                new ProductWearStock { Id = -46, ProductId = 7, WearSizeId = 7, WearColorId = 5, Quantity = 10 },
                new ProductWearStock { Id = -47, ProductId = 8, WearSizeId = 2, WearColorId = 5, Quantity = 10 },
                new ProductWearStock { Id = -48, ProductId = 8, WearSizeId = 3, WearColorId = 5, Quantity = 10 },
                new ProductWearStock { Id = -49, ProductId = 8, WearSizeId = 4, WearColorId = 5, Quantity = 10 },
                new ProductWearStock { Id = -50, ProductId = 9, WearSizeId = 2, WearColorId = 2, Quantity = 10 },
                new ProductWearStock { Id = -51, ProductId = 9, WearSizeId = 2, WearColorId = 3, Quantity = 10 },
                new ProductWearStock { Id = -52, ProductId = 9, WearSizeId = 3, WearColorId = 2, Quantity = 10 },
                new ProductWearStock { Id = -53, ProductId = 9, WearSizeId = 3, WearColorId = 3, Quantity = 10 },
                new ProductWearStock { Id = -54, ProductId = 9, WearSizeId = 4, WearColorId = 2, Quantity = 10 },
                new ProductWearStock { Id = -55, ProductId = 9, WearSizeId = 4, WearColorId = 3, Quantity = 10 },
                new ProductWearStock { Id = -56, ProductId = 10, WearSizeId = 6, WearColorId = 1, Quantity = 10 },
                new ProductWearStock { Id = -57, ProductId = 10, WearSizeId = 6, WearColorId = 4, Quantity = 10 },
                new ProductWearStock { Id = -58, ProductId = 10, WearSizeId = 7, WearColorId = 1, Quantity = 10 },
                new ProductWearStock { Id = -59, ProductId = 10, WearSizeId = 7, WearColorId = 4, Quantity = 10 },
                new ProductWearStock { Id = -60, ProductId = 10, WearSizeId = 8, WearColorId = 1, Quantity = 10 },
                new ProductWearStock { Id = -61, ProductId = 10, WearSizeId = 8, WearColorId = 4, Quantity = 10 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Classic Cotton T-Shirt",
                    Description = "Soft, breathable cotton tee with a relaxed fit.",
                    Price = 20.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1548036328-c9fa89d128fa?w=600",
                    StockQuantity = 50,
                    IsAvailable = true,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Graphic Print Tee",
                    Description = "Bold graphic print on premium quality cotton.",
                    Price = 25.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1562157873-818bc0726f68?w=600",
                    StockQuantity = 40,
                    IsAvailable = true,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Slim Fit Jeans",
                    Description = "Stretch denim slim fit jeans in a dark wash.",
                    Price = 50.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1611312449408-fcece27cdbb7?w=600",
                    StockQuantity = 30,
                    IsAvailable = true,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "Relaxed Straight Jeans",
                    Description = "Comfortable straight-leg jeans for everyday wear.",
                    Price = 55.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1544441893-675973e31985?w=600",
                    StockQuantity = 25,
                    IsAvailable = true,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 5,
                    Name = "Quilted Bomber Jacket",
                    Description = "Lightweight quilted bomber with a modern profile.",
                    Price = 70.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1598033129183-c4f50c736f10?w=600",
                    StockQuantity = 20,
                    IsAvailable = true,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 6,
                    Name = "Essential Black Tee",
                    Description = "Minimalist black tee with a clean, tailored fit.",
                    Price = 22.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1583864697784-a0efc8379f70?w=600",
                    StockQuantity = 45,
                    IsAvailable = true,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 7,
                    Name = "Tapered Dark Jeans",
                    Description = "Modern tapered denim with a deep dark wash.",
                    Price = 60.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1620121692029-d088224ddc74?w=600",
                    StockQuantity = 28,
                    IsAvailable = true,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 8,
                    Name = "Minimal Denim Jacket",
                    Description = "Timeless denim trucker jacket for any season.",
                    Price = 75.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=600",
                    StockQuantity = 18,
                    IsAvailable = true,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 9,
                    Name = "Classic White Tee",
                    Description = "Crisp white cotton tee, soft and long-lasting.",
                    Price = 19.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1593079831268-3381b0db4a77?w=600",
                    StockQuantity = 55,
                    IsAvailable = true,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 10,
                    Name = "Slim Black Jeans",
                    Description = "Slim-fit black jeans with a subtle fade.",
                    Price = 58.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1542125387-c71274d94f0a?w=600",
                    StockQuantity = 22,
                    IsAvailable = true,
                    CategoryId = 2
                }
            );
        }
    }
}
