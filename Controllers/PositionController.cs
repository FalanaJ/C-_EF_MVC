using Microsoft.AspNetCore.Mvc;
using AS_Kol_1.Models;

namespace AS_Kol_1.Controllers
{
	public class PositionController : Controller
	{
		private readonly MyDbContext _dbContext;
		public PositionController(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			ViewBag.Title = "Position";
			var positions = _dbContext.Positions
				.OrderByDescending(p => p.Id)
				.ToList();
			return View(positions);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Position position)
		{
			_dbContext.Positions.Add(position);
			_dbContext.SaveChanges();
			return View("Added", position);
		}
	}
}
