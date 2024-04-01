using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasaPhone.Models
{

    public class Specification
    {
        public int SpecificationId { get; set; }
        [ForeignKey("SpecificationId")]
        [ValidateNever]
        public Phone? Phone { get; set; }

        public string? Chipset { get; set; }
        [Display(Name = "Camera Specifications")]
        public string? Camera { get; set; }
        [Display(Name = "Operating System")]
        public string? Os { get; set; } // Android, iOS, Other
        [Display(Name = "Display Type")]
        public string? DisplayType { get; set; } // IPS-LCD, OLED, AMOLED, Retina, Others
        [Display(Name = "Display Resolution")]
        public string? DisplayResolution { get; set; } // 720p, 1080p, 2k, 4k, others
        [Display(Name = "Memory Size (GB)")]
        public string? Memory { get; set; }
        [Display(Name = "Storage Size (GB)")]
        public string? Storage { get; set; }
        [Display(Name = "Battery Capacity (mAh)")]
        public int? BatteryCapacity { get; set; }
        [Display(Name = "Charging Speed (W)")]
        public string? ChargingSpeed { get; set; }
        [Display(Name = "Other Specifications")]
        public string? OtherSpecs { get; set; }
    }
}
