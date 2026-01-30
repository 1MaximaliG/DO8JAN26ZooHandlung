using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZooHandlung.Models;

namespace ZooHandlung.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult EuroZuTier()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TierZuEuro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EuroZuTier(decimal geld)
        {
            //View wird inhalte vom Dictionary zeigen
            return View(Umrechner.EuroZuTier(geld));
        }
        [HttpPost]
        public IActionResult TierZuEuro(List<EingabeViewModel> tierListe)
        {
            foreach(var item in tierListe)
            {
                Console.WriteLine(item.Tier.Name);
            }
            //View bekommt nur den Geldbetrag
            return View(Umrechner.TierZuEuro(tierListe));
        }
    }
}
