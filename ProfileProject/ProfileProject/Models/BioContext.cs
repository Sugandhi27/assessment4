using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileProject.Models
{
    public class BioContext : DbContext
    {
        public BioContext(DbContextOptions<BioContext> options) : base(options)
        { }
        public DbSet<Bio> Bios { get; set; }
    }
}
