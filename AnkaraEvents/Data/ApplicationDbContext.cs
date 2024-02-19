using AnkaraEvents.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AnkaraEvents.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
