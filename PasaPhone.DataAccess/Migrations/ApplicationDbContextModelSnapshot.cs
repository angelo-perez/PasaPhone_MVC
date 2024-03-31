﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PasaPhone.DataAccess.Data;

#nullable disable

namespace PasaPhone.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PasaPhone.Models.Phone", b =>
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Issues")
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
                            DateModified = new DateTime(2024, 3, 31, 10, 55, 43, 373, DateTimeKind.Local).AddTicks(1893),
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
                            DateModified = new DateTime(2024, 3, 31, 10, 55, 43, 373, DateTimeKind.Local).AddTicks(1896),
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
                            DateModified = new DateTime(2024, 3, 31, 10, 55, 43, 373, DateTimeKind.Local).AddTicks(1948),
                            Description = "Fairly used phone, with minor scratches.",
                            Issues = "Small scratch on the screen.",
                            Location = "Cebu City, Cebu",
                            MeetupPreference = "Door Dropoff",
                            Model = "8T",
                            Price = 28000.0
                        });
                });

            modelBuilder.Entity("PasaPhone.Models.Specification", b =>
                {
                    b.Property<int>("SpecificationId")
                        .HasColumnType("int");

                    b.Property<int?>("BatteryCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Camera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChargingSpeed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Chipset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayResolution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Os")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherSpecs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecificationId");

                    b.ToTable("Specifications");

                    b.HasData(
                        new
                        {
                            SpecificationId = 1,
                            BatteryCapacity = 4000,
                            Camera = "Triple - 12 MP wide, 64 MP telephoto, 12 MP ultrawide",
                            ChargingSpeed = "Fast charging 25W, USB Power Delivery 3.0, Fast Qi/PMA wireless charging 15W, Reverse wireless charging 4.5W",
                            Chipset = "Exynos 990 (Global) / Qualcomm Snapdragon 865 (USA)",
                            DisplayResolution = "Quad HD+",
                            DisplayType = "Dynamic AMOLED 2X",
                            Memory = "12GB",
                            Os = "Android",
                            OtherSpecs = "IP68 dust/water resistant (up to 1.5m for 30 mins), HDR10+, 120Hz refresh rate",
                            Storage = "128GB"
                        },
                        new
                        {
                            SpecificationId = 2,
                            BatteryCapacity = 2815,
                            Camera = "Triple - 12 MP wide, 12 MP telephoto, 12 MP ultrawide",
                            ChargingSpeed = "Fast charging 20W, 50% in 30 min (advertised), USB Power Delivery 2.0, MagSafe wireless charging 15W",
                            Chipset = "Apple A14 Bionic",
                            DisplayResolution = "Full HD+",
                            DisplayType = "Super Retina XDR OLED",
                            Memory = "6GB",
                            Os = "iOS",
                            OtherSpecs = "IP68 dust/water resistant (up to 6m for 30 mins), Ceramic Shield front, HDR10, Dolby Vision",
                            Storage = "128GB"
                        },
                        new
                        {
                            SpecificationId = 3,
                            BatteryCapacity = 4500,
                            Camera = "Quad - 48 MP wide, 16 MP ultrawide, 5 MP macro, 2 MP depth",
                            ChargingSpeed = "Fast charging 65W, 100% in 39 min (advertised), Reverse charging 3W",
                            Chipset = "Qualcomm Snapdragon 865",
                            DisplayResolution = "Full HD+",
                            DisplayType = "Fluid AMOLED",
                            Memory = "8GB",
                            Os = "Android",
                            OtherSpecs = "HDR10+, 120Hz refresh rate, Corning Gorilla Glass 5",
                            Storage = "128GB"
                        });
                });

            modelBuilder.Entity("PasaPhone.Models.Specification", b =>
                {
                    b.HasOne("PasaPhone.Models.Phone", "Phone")
                        .WithMany()
                        .HasForeignKey("SpecificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phone");
                });
#pragma warning restore 612, 618
        }
    }
}
