using System.ComponentModel.DataAnnotations;

namespace GenericInventorySystem.Models.Location
{
    public class LocationRoom
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Room Name/Number")]
        public string RoomName { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "Room Short Code")]
        public string RoomShortCode { get; set; }
    }
}
