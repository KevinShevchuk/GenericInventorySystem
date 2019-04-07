using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericInventorySystem.Models
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext (DbContextOptions<ItemDbContext> options)
            : base(options)
        {
        }

        public DbSet<GenericInventorySystem.Models.Item> Item { get; set; }
    }
}
