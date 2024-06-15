using HouseRentingSystem.Services.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using static HouseRentingSystem.Services.Data.Constants;

namespace HouseRentingSystem.Services.Data
{
    public class HouseRentingDbContext : IdentityDbContext<User>
    {
        private bool seedDb;

        private User AdminUser { get; set; }
        private Agent AdminAgent { get; set; }
        private User AgentUser { get; set; }
        private User GuestUser { get; set; }
        private Agent Agent { get; set; }
        private Category CottageCategory { get; set; }
        private Category SingleCategory { get; set; }
        private Category DuplexCategory { get; set; }
        private House FirstHouse { get; set; }
        private House SecondHouse { get; set; }
        private House ThirdHouse { get; set; }

        public HouseRentingDbContext
            (DbContextOptions<HouseRentingDbContext> options, bool seed = true )
            : base(options)
        {
            if (this.Database.IsRelational())
            {
                this.Database.Migrate();
            }
            else
            {
                this.Database.EnsureCreated();
            }

            this.seedDb = seed;
        }

        public DbSet<House> Houses { get; init; }
        public DbSet<Category> Categories { get; init; }
        public DbSet<Agent> Agents { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder
                .Entity<House>()
                .HasOne(h => h.Category)
                .WithMany(c => c.Houses)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<House>()
               .HasOne(h => h.Agent)
               .WithMany()
               .HasForeignKey(h => h.AgentId)
               .OnDelete(DeleteBehavior.Restrict);

            if (this.seedDb)
            {
                SeedUsers();
                builder.Entity<User>()
                        .HasData(this.AgentUser,
                        this.GuestUser,
                        this.AdminUser);

                SeedAgent();
                builder.Entity<Agent>()
                        .HasData(this.Agent,
                        this.AdminAgent);

                SeedCategories();
                builder.Entity<Category>()
                    .HasData(this.CottageCategory,
                            this.SingleCategory,
                            this.DuplexCategory);

                SeedHouses();
                builder.Entity<House>()
                    .HasData(this.FirstHouse,
                            this.SecondHouse,
                            this.ThirdHouse);
            }
            
            base.OnModelCreating(builder);
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<User>();

            this.AgentUser = new User()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com",
                FirstName = "Linda",
                LastName = "Michaels"
            };

            this.AgentUser.PasswordHash =
                hasher.HashPassword(this.AgentUser, "agent123");

            this.GuestUser = new User()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Teodor",
                LastName = "Lesly"
            };

            this.GuestUser.PasswordHash =
                hasher.HashPassword(this.AgentUser, "guest123");

            this.AdminUser = new User()
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                Email = AdminEmail,
                NormalizedEmail = AdminEmail,
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail,
                FirstName = "Great",
                LastName = "Admin"
            };

            this.AdminUser.PasswordHash =
                hasher.HashPassword(this.AgentUser, "admin123");
        }

        private void SeedAgent()
        {
            this.Agent = new Agent()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = this.AgentUser.Id
            };

            this.AdminAgent = new Agent()
            {
                Id = 6,
                PhoneNumber = "+359123456789",
                UserId = this.AdminUser.Id
            };
        }

        private void SeedCategories()
        {
            this.CottageCategory = new Category()
            {
                Id = 1,
                Name = "Cottage"
            };

            this.SingleCategory = new Category()
            {
                Id = 2,
                Name = "Single-Family"
            };

            this.DuplexCategory = new Category()
            {
                Id = 3,
                Name = "Duplex"
            };
        }

        private void SeedHouses()
        {
            this.FirstHouse = new House()
            {
                Id = 1,
                Title = "Big House Marina",
                Address = "North London, UK (near the border)",
                Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
                ImageUrl = "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
                PricePerMonth = 2100.00M,
                CategoryId = this.DuplexCategory.Id,
                AgentId = this.Agent.Id,
                RenterId = this.GuestUser.Id
            };

            this.SecondHouse = new House()
            {
                Id = 2,
                Title = "Family House Comfort",
                Address = "Near the Sea Garden in Burgas, Bulgaria",
                Description = "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.",
                ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg" +
                "?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1",
                PricePerMonth = 1200.00M,
                CategoryId = this.SingleCategory.Id,
                AgentId = this.Agent.Id
            };

            this.ThirdHouse = new House()
            {
                Id = 3,
                Title = "Grand House",
                Address = "Boyana Neighbourhood, Sofia, Bulgaria",
                Description = "This luxurious house is everything you will need. It is just excellent.",
                ImageUrl = "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
                PricePerMonth = 2000.00M,
                CategoryId = this.SingleCategory.Id,
                AgentId = this.Agent.Id
            };
        }
    }
}


