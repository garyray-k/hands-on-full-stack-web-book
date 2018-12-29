﻿// <auto-generated />
using System;
using GiveNTake.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GiveNTake.Migrations
{
    [DbContext(typeof(GiveNTakeContext))]
    partial class GiveNTakeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GiveNTake.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("ParentCategoryCategoryId");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GiveNTake.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("GiveNTake.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("MessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("GiveNTake.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .IsRequired();

                    b.Property<int?>("CityId");

                    b.Property<string>("Description");

                    b.Property<int?>("OwnerUserId");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("Title");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CityId");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GiveNTake.Models.ProductMedia", b =>
                {
                    b.Property<int>("ProductMediaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId");

                    b.HasKey("ProductMediaId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductMedia");
                });

            modelBuilder.Entity("GiveNTake.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GiveNTake.Models.Category", b =>
                {
                    b.HasOne("GiveNTake.Models.Category", "ParentCategory")
                        .WithMany("Subcategories")
                        .HasForeignKey("ParentCategoryCategoryId");
                });

            modelBuilder.Entity("GiveNTake.Models.Product", b =>
                {
                    b.HasOne("GiveNTake.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GiveNTake.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("GiveNTake.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerUserId");
                });

            modelBuilder.Entity("GiveNTake.Models.ProductMedia", b =>
                {
                    b.HasOne("GiveNTake.Models.Product")
                        .WithMany("Media")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
