using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Canducci.ZipCodePostmon;
using Canducci.ZipCodePostmon.Web;
using Microsoft.AspNetCore.Mvc;
using WebAppCore.Models;

namespace WebAppCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
        public ActionResult ZipCode()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ZipCode([ModelBinder(typeof(ZipCodeNumberBinder))]ZipCodeNumber zipCodeNumber)
        {
            if (ModelState.IsValid)
            {
                ZipCodeResult result = new ZipCodeResult();
                ZipCode zipCode = await result.FindAsync(zipCodeNumber);
                ViewData["ZipCodeRequestValue"] = zipCodeNumber.Value;
                return View(zipCode);
            }
            return View();
        }
    }
}
