using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PemesananMakananCMS.Models
{
    public class PemesananModels
    {
        public int PemesananId { get; set; }
        public int MenuMakananId { get; set; }
        public int QtyPemesanan { get; set; }
        public double HargaTotal { get; set; }
    }
}