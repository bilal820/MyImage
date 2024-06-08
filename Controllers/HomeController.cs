using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyImage.Models;
using System.Diagnostics;

namespace MyImage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _AppDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ApplicationDbContext AppDb, IWebHostEnvironment whe)
        {
            this._AppDbContext = AppDb;
            this._webHostEnvironment = whe;
        }

        public IActionResult Index()
        {
            var data = _AppDbContext.SizeDetails.ToList();
            return View(data);

        }
        public IActionResult singleProduct(int id)
        {
            //var Detaildata = _applicationDbContext.Employees.Find(id);
            var Detaildata = _AppDbContext.SizeDetails.Find(id);
            return View(Detaildata);
        }
        public IActionResult AddToCart()
        {
            return View();
        }
        public IActionResult Contact()
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
    }
}