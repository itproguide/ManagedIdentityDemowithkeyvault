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
        [HttpPost("postvalue")]
        public IActionResult postvalue(profile _profile)
        {
            _db.profile.Add(_profile);
            _db.SaveChanges();
            return Ok(_profile);
        }
        [HttpGet("service")]
        public IActionResult service()
        {

            return Ok("service");
        }

    }
}
