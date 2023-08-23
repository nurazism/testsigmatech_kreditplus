using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PemesananMakananAPI.Models;
using System.Runtime.Loader;

namespace PemesananMakananAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PemesananController : ControllerBase
    {
        private readonly PemesananMakananContext pemesananMakananContext;

        public PemesananController(PemesananMakananContext pemesananMakananContext)
        {
            this.pemesananMakananContext = pemesananMakananContext;
        }

        [HttpGet]
        [Route("GetPemesananList")]
        public List<Pemesanan> GetPemesananList()
        {
            return pemesananMakananContext.Pemesanan.ToList();
        }

        [HttpGet]
        [Route("GetPemesanan")]
        public Pemesanan GetPemesanan(int id)
        {
            try
            {
                return pemesananMakananContext.Pemesanan.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        [HttpPost]
        [Route("AddPemesanan")]
        public string AddPemesanan(Pemesanan Pemesanan)
        {
            try
            {
                string response = string.Empty;
                var cekStok = pemesananMakananContext.MenuMakanan.FirstOrDefault(x => x.Id == Pemesanan.MenuMakananId).Stok;
                if (cekStok >= Pemesanan.QtyPemesanan)
                {
                    pemesananMakananContext.Pemesanan.Add(Pemesanan);
                    pemesananMakananContext.SaveChanges();
                    response = "Pesanan telah ditambahkan";
                }
                else
                {
                    response = "Stok Menu tidak cukup";
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        [HttpPut]
        [Route("UpdatePemesanan")]
        public string UpdatePemesanan(Pemesanan Pemesanan)
        {
            try
            {
                string response = string.Empty;
                var cekStok = pemesananMakananContext.MenuMakanan.FirstOrDefault(x => x.Id == Pemesanan.MenuMakananId).Stok;
                if (cekStok >= Pemesanan.QtyPemesanan)
                {
                    pemesananMakananContext.Entry(Pemesanan).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    pemesananMakananContext.SaveChanges();
                    response = "Pesanan telah diperbarui";
                }
                else
                {
                    response = "Pesanan tidak berhasil diperbarui, stok menu tidak mencukupi";
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        [HttpDelete]
        [Route("DeletePemesanan")]
        public string DeletePemesanan(Pemesanan Pemesanan)
        {
            try
            {
                pemesananMakananContext.Remove(Pemesanan);
                pemesananMakananContext.SaveChanges();
                return "Pemesanan Deleted";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        private readonly ILogger<PemesananController> _logger;
        public PemesananController(ILogger<PemesananController> logger)
        {
            _logger = logger;
        }
    }
}
