using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Canducci.ZipCodePostmon;
using Canducci.ZipCodePostmon.Web;
namespace WebApp45.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult ZipCode()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ZipCode([ModelBinder(typeof(ZipCodeNumberBinder))]ZipCodeNumber? zipCodeNumber)
        {
            if (ModelState.IsValid)
            {
                ZipCodeResult result = new ZipCodeResult();
                ZipCode zipCode = await result.FindAsync(zipCodeNumber.Value);
                return View(zipCode);
            }
            return View();
        }
    }
}