using Canducci.ZipCodePostmon;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppCore.Models;
namespace WebAppCore.Controllers
{
    public class FindZipController : Controller
    {
        public ZipCodeResult ZipCodeResult { get; }

        public FindZipController(ZipCodeResult zipCodeResult)
        {
            ZipCodeResult = zipCodeResult;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([ModelBinder(typeof(ZipCodeNumberBinder))] ZipCodeNumber number)
        {
            if (ModelState.IsValid)
            {
                ZipCode model = await ZipCodeResult.FindAsync(number);
                return View(model);
            }
            return View();
        }
    }
}
