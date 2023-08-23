using System.ComponentModel.DataAnnotations;

namespace PemesananMakananAPI.Models
{
    public class Pemesanan
    {
        [Key]
        public int Id { get; set; }
        public int MenuMakananId { get; set; }
        public int QtyPemesanan { get; set; }
        public double HargaTotal { get; set; }
    }
}
