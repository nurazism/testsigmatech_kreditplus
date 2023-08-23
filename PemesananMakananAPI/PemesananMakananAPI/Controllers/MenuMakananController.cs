using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PemesananMakananAPI.Models;

namespace PemesananMakananAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuMakananController : ControllerBase
    {
        private readonly PemesananMakananContext MenuMakananContext;

        public MenuMakananController(PemesananMakananContext MenuMakananContext)
        {
            this.MenuMakananContext = MenuMakananContext;
        }

        [HttpGet]
        [Route("GetMenuMakananList")]
        public List<MenuMakanan> GetMenuMakananList()
        {
            return MenuMakananContext.MenuMakanan.ToList();
        }

        [HttpGet]
        [Route("GetMenuMakanan")]
        public MenuMakanan GetMenuMakanan(int id)
        {
            try
            {
                return MenuMakananContext.MenuMakanan.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        [HttpPost]
        [Route("AddMenuMakanan")]
        public string AddMenuMakanan(MenuMakanan MenuMakanan)
        {
            try
            {
                //string response = string.Empty;
                MenuMakananContext.MenuMakanan.Add(MenuMakanan);
                MenuMakananContext.SaveChanges();
                return "MenuMakanan Added";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        [HttpPut]
        [Route("UpdateMenuMakanan")]
        public string UpdateMenuMakanan(MenuMakanan MenuMakanan)
        {
            try
            {
                MenuMakananContext.Entry(MenuMakanan).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                MenuMakananContext.SaveChanges();
                return "MenuMakanan Updated";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        [HttpDelete]
        [Route("DeleteMenuMakanan")]
        public string DeleteMenuMakanan(MenuMakanan MenuMakanan)
        {
            try
            {
                MenuMakananContext.Remove(MenuMakanan);
                MenuMakananContext.SaveChanges();
                return "MenuMakanan Deleted";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        private readonly ILogger<MenuMakananController> _logger;
        public MenuMakananController(ILogger<MenuMakananController> logger)
        {
            _logger = logger;
        }
    }
}
