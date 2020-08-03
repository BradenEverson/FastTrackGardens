using Agronomous.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agronomous.Database
{
    public class PlantDbContext : DbContext
    {
        public DbSet<plant> plants { get; set; }
    }
}
