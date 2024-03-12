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
                },
                new Phone
                {
                    Id = 4,
                    Brand = "Xiaomi",
                    Model = "Redmi Note 10",
                    Condition = "New",
                    Price = 12000.00,
                    Description = "Fresh out of the box, never been used.",
                    Issues = "None",
                    Location = "Davao City, Davao",
                    MeetupPreference = "Public Meetup",
                    DateModified = DateTime.Now
                },
                new Phone
                {
                    Id = 5,
                    Brand = "Realme",
                    Model = "X7 Max",
                    Condition = "Used - Good",
                    Price = 20000.00,
                    Description = "Good condition, used for a few months.",
                    Issues = "Minor wear and tear on the back.",
                    Location = "Manila City, NCR",
                    MeetupPreference = "Door Pickup",
                    DateModified = DateTime.Now
                }
            );
        }
    }
}
