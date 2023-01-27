using ManagedIdentityDemowithkeyvault.Data;
using Microsoft.AspNetCore.Mvc;

namespace ManagedIdentityDemowithkeyvault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        public readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet("getfullvalue")]
        public IActionResult getfullvalue()
        {
            var obj = _db.profile.ToList();

            return Ok(obj);
        }
        [HttpGet("service")]
        public IActionResult service()
        {

            return Ok("service");
        }

    }
}
