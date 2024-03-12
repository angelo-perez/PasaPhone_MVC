using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasaPhone.Models
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

    //public class PhoneSpecs
    //{
    //    public int Id { get; set; }
    //    [ForeignKey("Phone")]
    //    public int PhoneId { get; set; }
    //    public string Chipset { get; set; }
    //    public string Camera { get; set; }
    //    public string Os { get; set; } // Android, iOS, Other
    //    public string DisplayType { get; set; } // IPS-LCD, OLED, AMOLED, Retina, Others
    //    public string DisplayResolution { get; set; }
    //    public int Memory { get; set; }
    //    public int Storage { get; set; }
    //    public string Battery { get; set; }
    //    public string Charging { get; set; }
    //    public string OtherSpecs { get; set; }
    //}
}
