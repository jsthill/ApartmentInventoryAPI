using ApartmentInventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartmentInventoryAPI.Data
{
    public class ApartmentContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public ApartmentContext(DbContextOptions<ApartmentContext> opt) : base(opt)
        {

        }
    }
}