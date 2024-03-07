using System.ComponentModel.DataAnnotations;

namespace PasaPhoneWebRazor_Temp.Models
{
    public class Phone
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Condition { get; set; } // New, Used - Like new, Used - Good, Used - Fair

        [Required]
        [DisplayFormat(DataFormatString = "₱{0:N}")]
        [Display(Name = "Price (₱)")]
        public double Price { get; set; } // in Philippine Peso

        public string? Description { get; set; }

        [Display(Name = "Issue(s)")]
        public string? Issues { get; set; }

        [Required]
        public string Location { get; set; } // City or Province

        [Required]
        [Display(Name = "Meetup Preference(s)")]
        public string MeetupPreference { get; set; } // Public Meetup, Door Pickup, or Door Dropoff

        //[Required]
        //public int SellerId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; } = DateTime.Now; // Date Listed / Edited

        // Filters (w/ Sort):
        // Price (Min-Max)
        // Location (checkbox)
        // Date Listed
        // Condition
        // Brand
        // Chipset
        // OS
        // Memory
        // Storage
        // Display
        // Battery

    }
}
