﻿using Canducci.ZipCodePostmon;
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
            if (ZipCodeNumber.TryParse(value, out ZipCodeNumber number))
            {
                ZipCode model = await ZipCodeResult.FindAsync(number);
                return View(model);
            }
            return View();
        }
    }
}
