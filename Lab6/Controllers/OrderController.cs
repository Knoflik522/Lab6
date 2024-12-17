using Lab6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class OrderController : Controller
    {
        private static List<Product> Products = new List<Product>();
        private static int TotalProductCount = 0;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (user.Age < 16)
            {
                ViewBag.Message = "Вам має бути більше 16 років для замовлення!";
                return View();
            }

            return RedirectToAction("SetProductCount");
        }

        [HttpGet]
        public IActionResult SetProductCount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetProductCount(int count)
        {
            if (count <= 0)
            {
                ModelState.AddModelError("", "Кількість товарів має бути додатною!");
                return View();
            }

            TotalProductCount = count;
            return RedirectToAction("AddProducts");
        }

        [HttpGet]
        public IActionResult AddProducts()
        {
            ViewBag.Count = TotalProductCount;
            return View(new List<Product>(new Product[TotalProductCount]));
        }

        [HttpPost]
        public IActionResult AddProducts(List<Product> products)
        {
            if (!ModelState.IsValid)
            {
                return View(products);
            }

            Products = products;
            return RedirectToAction("Summary");
        }

        [HttpGet]
        public IActionResult Summary()
        {
            return View(Products);
        }
    }
}
