using Microsoft.AspNetCore.Mvc;
using System.Threading.RateLimiting;
using ZooHandlung.Models;

namespace ZooHandlung.Controllers
{
    public class TierController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.Tiere);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tier tier)
        {
            return View();
        }
    }
}
