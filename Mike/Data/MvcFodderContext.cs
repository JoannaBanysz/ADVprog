using Microsoft.EntityFrameworkCore;
using Mike.Models;
namespace Mike.Data
{
    public class MvcFodderContext : DbContext
    {
        public MvcFodderContext(DbContextOptions<MvcFodderContext> options)
        : base(options)
        {
        }
        public DbSet<Fodder> Fodder { get; set; }
  
    }
}
