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
                return View("TierErgebnis",Umrechner.EuroZuTier(geld) );
        }
        [HttpPost]
        public IActionResult TierZuEuro(List<EingabeViewModel> tierListe)
        {
            //View bekommt nur den Geldbetrag
            //FEHLT NOCH DIE NEUE VIEW
            return View("ErgebnisView",Umrechner.TierZuEuro(tierListe));
        }
    }
}
