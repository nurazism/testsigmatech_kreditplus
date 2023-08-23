using Microsoft.EntityFrameworkCore;

namespace PemesananMakananAPI.Models
{
    public class PemesananMakananContext : DbContext
    {
        public PemesananMakananContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<MenuMakanan> MenuMakanan { get; set; }
        public DbSet<Pemesanan> Pemesanan { get; set; }
    }
}
