using AS_Kol_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AS_Kol_1.Controllers
{
	public class LeagueController : Controller
	{
		private MyDbContext _dbContext;

		public LeagueController(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index()
		{
			ViewBag.Title = "League";
			return View();
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(League league)
		{
			_dbContext.Leagues.Add(league);
			_dbContext.SaveChanges();
			return View("Added", league);
		}
	}
}
