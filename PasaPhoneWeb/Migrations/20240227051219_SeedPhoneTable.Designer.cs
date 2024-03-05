﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PasaPhoneWeb.Data;

#nullable disable

namespace PasaPhoneWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240227051219_SeedPhoneTable")]
    partial class SeedPhoneTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PasaPhoneWeb.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Issues")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeetupPreference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Samsung",
                            Condition = "New",
                            DateModified = new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6381),
                            Description = "Brand new phone, never used.",
                            Issues = "None",
                            Location = "Quezon City, NCR",
                            MeetupPreference = "Door Pickup",
                            Model = "Galaxy S20",
                            Price = 45000.0
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Apple",
                            Condition = "Used - Like new",
                            DateModified = new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6383),
                            Description = "Slightly used, looks like new.",
                            Issues = "No scratches or dents.",
                            Location = "Makati City, NCR",
                            MeetupPreference = "Public Meetup",
                            Model = "iPhone 12 Pro",
                            Price = 55000.0
                        },
                        new
                        {
                            Id = 3,
                            Brand = "OnePlus",
                            Condition = "Used - Fair",
                            DateModified = new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6385),
                            Description = "Fairly used phone, with minor scratches.",
                            Issues = "Small scratch on the screen.",
                            Location = "Cebu City, Cebu",
                            MeetupPreference = "Door Dropoff",
                            Model = "8T",
                            Price = 28000.0
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Xiaomi",
                            Condition = "New",
                            DateModified = new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6387),
                            Description = "Fresh out of the box, never been used.",
                            Issues = "None",
                            Location = "Davao City, Davao",
                            MeetupPreference = "Public Meetup",
                            Model = "Redmi Note 10",
                            Price = 12000.0
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Realme",
                            Condition = "Used - Good",
                            DateModified = new DateTime(2024, 2, 27, 13, 12, 18, 622, DateTimeKind.Local).AddTicks(6389),
                            Description = "Good condition, used for a few months.",
                            Issues = "Minor wear and tear on the back.",
                            Location = "Manila City, NCR",
                            MeetupPreference = "Door Pickup",
                            Model = "X7 Max",
                            Price = 20000.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
