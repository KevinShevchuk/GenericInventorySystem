using System.ComponentModel.DataAnnotations;

namespace GenericInventorySystem.Models
{
    public class LocationBuilding
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Building Name/Number")]
        public string BuildingName { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "Building Short Code")]
        public string BuildingShortCode { get; set; }
    }
}
