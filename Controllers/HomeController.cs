using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AS_Kol_1.Models;

namespace AS_Kol_1.Controllers
{
    public class HomeController : Controller
    {

        private readonly MyDbContext _dbContext;

        public HomeController(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
    }
}
