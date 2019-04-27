using System.ComponentModel.DataAnnotations;

namespace GenericInventorySystem.Models.Location
{
    public class LocationZone
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Zone Name/Number")]
        public string ZoneName { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "Zone Short Code")]
        public string ZoneShortCode { get; set; }
    }
}
