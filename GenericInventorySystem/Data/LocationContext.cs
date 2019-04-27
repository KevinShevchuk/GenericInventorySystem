using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GenericInventorySystem.Models;
using GenericInventorySystem.Models.Location;

namespace GenericInventorySystem.Models
{
    public class LocationContext : DbContext
    {
        public LocationContext (DbContextOptions<LocationContext> options)
            : base(options)
        {
        }

        public DbSet<GenericInventorySystem.Models.LocationAddress> LocationAddress { get; set; }

        public DbSet<GenericInventorySystem.Models.LocationBuilding> LocationBuilding { get; set; }

        public DbSet<GenericInventorySystem.Models.Location.LocationRoom> LocationRoom { get; set; }

        public DbSet<GenericInventorySystem.Models.Location.LocationZone> LocationZone { get; set; }

        public DbSet<GenericInventorySystem.Models.Location.LocationSection> LocationSection { get; set; }
    }
}
