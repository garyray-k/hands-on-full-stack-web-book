using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GiveNTake.Models {
    public class GiveNTakeContext : DbContext {
        public DbSet<Product> Products { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }

        public GiveNTakeContext(DbContextOptions<GiveNTakeContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>()
                .HasOne(sub => sub.ParentCategory)
                .WithMany(c => c.Subcategories)
                .IsRequired(false);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .IsRequired();
        }

        public void SeedData() {
            if (!Categories.Any()) {
                var appliances = new Category() {
                    Name = "Appliances",
                    Subcategories = new List<Category>() {
                        new Category(){Name = "Microwaves"}
                    }
                };
                Categories.Add(appliances);

                SaveChanges();
            }

            if (!Cities.Any()) {
                Cities.AddRange(
                    new City { Name = "New York" },
                    new City { Name = "Seattle" },
                    new City { Name = "San Francisco" });
                SaveChanges();
            }
        }
    }
}
