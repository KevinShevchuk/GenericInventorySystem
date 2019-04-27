using System.ComponentModel.DataAnnotations;

namespace GenericInventorySystem.Models
{
    public class LocationAddress
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "State/Province")]
        public string State { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(3)]
        public string AddressShortCode { get; set; }
    }
}
