using Microsoft.EntityFrameworkCore;
using Mike.Models;

namespace Mike.Data
{
    public class MvcBreedingContext : DbContext
    {
        public MvcBreedingContext(DbContextOptions<MvcBreedingContext> options)
        : base(options)
        {
        }
        public DbSet<Breeding> Breeding { get; set; }
    }
}
