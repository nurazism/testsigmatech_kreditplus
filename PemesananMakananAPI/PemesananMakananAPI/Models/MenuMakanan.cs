using System.ComponentModel.DataAnnotations;

namespace PemesananMakananAPI.Models
{
    public class MenuMakanan
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
        public double Harga { get; set; }
        public int Stok { get; set; }

    }    
}
