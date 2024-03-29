using Microsoft.EntityFrameworkCore;
using PasaPhone.Models;

namespace PasaPhone.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Specification> Specifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().HasData(
                new Phone
                {
                    Id = 1,
                    Brand = "Samsung",
                    Model = "Galaxy S20",
                    Condition = "New",
                    Price = 45000.00,
                    Description = "Brand new phone, never used.",
                    Issues = "None",
                    Location = "Quezon City, NCR",
                    MeetupPreference = "Door Pickup",
                    DateModified = DateTime.Now
                },
                new Phone
                {
                    Id = 2,
                    Brand = "Apple",
                    Model = "iPhone 12 Pro",
                    Condition = "Used - Like new",
                    Price = 55000.00,
                    Description = "Slightly used, looks like new.",
                    Issues = "No scratches or dents.",
                    Location = "Makati City, NCR",
                    MeetupPreference = "Public Meetup",
                    DateModified = DateTime.Now
                },
                new Phone
                {
                    Id = 3,
                    Brand = "OnePlus",
                    Model = "8T",
                    Condition = "Used - Fair",
                    Price = 28000.00,
                    Description = "Fairly used phone, with minor scratches.",
                    Issues = "Small scratch on the screen.",
                    Location = "Cebu City, Cebu",
                    MeetupPreference = "Door Dropoff",
                    DateModified = DateTime.Now
                }
            );

            modelBuilder.Entity<Specification>().HasData(
                new Specification
                {
                    SpecificationId = 1, // Assuming PhoneId corresponds to Samsung Galaxy S20
                    Chipset = "Exynos 990 (Global) / Qualcomm Snapdragon 865 (USA)",
                    Camera = "Triple - 12 MP wide, 64 MP telephoto, 12 MP ultrawide",
                    Os = "Android",
                    DisplayType = "Dynamic AMOLED 2X",
                    DisplayResolution = "Quad HD+",
                    Memory = 12, // GB RAM
                    Storage = 128, // GB
                    BatteryCapacity = 4000, // mAh
                    ChargingSpeed = "Fast charging 25W, USB Power Delivery 3.0, Fast Qi/PMA wireless charging 15W, Reverse wireless charging 4.5W",
                    OtherSpecs = "IP68 dust/water resistant (up to 1.5m for 30 mins), HDR10+, 120Hz refresh rate"
                },
                new Specification
                {
                    SpecificationId = 2, // Assuming PhoneId corresponds to Apple iPhone 12 Pro
                    Chipset = "Apple A14 Bionic",
                    Camera = "Triple - 12 MP wide, 12 MP telephoto, 12 MP ultrawide",
                    Os = "iOS",
                    DisplayType = "Super Retina XDR OLED",
                    DisplayResolution = "Full HD+",
                    Memory = 6, // GB RAM
                    Storage = 128, // GB
                    BatteryCapacity = 2815, // mAh
                    ChargingSpeed = "Fast charging 20W, 50% in 30 min (advertised), USB Power Delivery 2.0, MagSafe wireless charging 15W",
                    OtherSpecs = "IP68 dust/water resistant (up to 6m for 30 mins), Ceramic Shield front, HDR10, Dolby Vision"
                },
                new Specification
                {
                    SpecificationId = 3, // Assuming PhoneId corresponds to OnePlus 8T
                    Chipset = "Qualcomm Snapdragon 865",
                    Camera = "Quad - 48 MP wide, 16 MP ultrawide, 5 MP macro, 2 MP depth",
                    Os = "Android",
                    DisplayType = "Fluid AMOLED",
                    DisplayResolution = "Full HD+",
                    Memory = 8, // GB RAM
                    Storage = 128, // GB
                    BatteryCapacity = 4500, // mAh
                    ChargingSpeed = "Fast charging 65W, 100% in 39 min (advertised), Reverse charging 3W",
                    OtherSpecs = "HDR10+, 120Hz refresh rate, Corning Gorilla Glass 5"
                }
            );
        }
    }
}
