using Microsoft.EntityFrameworkCore;
using PasaPhoneWebRazor_Temp.Models;

namespace PasaPhoneWebRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Phone> Phones { get; set; }

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
        }
    }
}
