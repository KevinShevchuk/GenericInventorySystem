using System.ComponentModel.DataAnnotations;

namespace GenericInventorySystem.Models.Location
{
    public class InventoryLocation
    {
        public int Id { get; set; }

        [StringLength(15)]
        public string LocationShortCode { get; set; }

        public int AddressID { get; set; }
        public int BuildingID { get; set; }
        public int RoomID { get; set; }
        public int ZoneID { get; set; }
        public int SectionID { get; set; }
    }
}
