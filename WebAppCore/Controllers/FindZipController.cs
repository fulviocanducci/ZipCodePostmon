using Canducci.ZipCodePostmon;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index(string value)
        {
            ZipCodeNumber number = (ZipCodeNumber)value;
            ZipCode model = await ZipCodeResult.FindAsync(number);
            return View(model);
        }
    }
}
