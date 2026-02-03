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
            Repository.AddTier(tier);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(Repository.Tiere.First(tier => tier.ID == id));
        }
        [HttpPost]
        public IActionResult Edit(Tier tier)
        {
            Repository.UpdateTier(tier);
            return RedirectToAction("Index");
        }
    }
}
