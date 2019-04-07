using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericInventorySystem.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Product Name")]
        public string ItemName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Manufacturer Name")]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        [Display(Name = "Manufacturer Product Code")]
        public string ManufacturerProductCode { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Price Per Unit")]
        public decimal PricePerUnit { get; set; }
    }

    public class ItemManufacturerViewModel
    {
        public List<Item> Items;
        public SelectList Manufacturers;
        public string ItemManufacturer { get; set; }
        public string SearchString { get; set; }
    }
}
