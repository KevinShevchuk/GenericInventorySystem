using System.ComponentModel.DataAnnotations;

namespace GenericInventorySystem.Models.Location
{
    public class LocationSection
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Section Name/Number")]
        public string SectionName { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "Section Short Code")]
        public string SectionShortCode { get; set; }
    }
}
