using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PemesananMakananAPI.Models;
using System.IO;

namespace PemesananMakananAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PemesananMakananContext PemesananMakananContext;

        public UsersController(PemesananMakananContext PemesananMakananContext)
        {
            this.PemesananMakananContext = PemesananMakananContext;
        }

        [HttpGet]
        [Route("GetUsers")]
        public List<Users> GetUsers()
        {
            return PemesananMakananContext.Users.ToList();
        }

        [HttpGet]
        [Route("GetUser")]
        public Users GetUser(string id)
        {
            try
            {
                return PemesananMakananContext.Users.FirstOrDefault(x => x.UserId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public string AddUser(Users users)
        {
            try
            {
                //string response = string.Empty;
                PemesananMakananContext.Users.Add(users);
                PemesananMakananContext.SaveChanges();
                return "User Added";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public string UpdateUser(Users users)
        {
            try
            {
                PemesananMakananContext.Entry(users).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                PemesananMakananContext.SaveChanges();
                return "User Updated";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public string DeleteUser(Users users)
        {
            try
            {
                PemesananMakananContext.Remove(users);
                PemesananMakananContext.SaveChanges();
                return "User Deleted";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

    }
}
