using AS_Kol_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AS_Kol_1.Controllers
{
	public class TeamController : Controller
	{
		private readonly MyDbContext _dbContext;

		public TeamController(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			ViewBag.Title = "Team";
			var teams = _dbContext.Teams
				.OrderByDescending(t => t.Id)
				.Include(t => t.League)
				.ToList();
			return View(teams);
		}

		public IActionResult Add()
		{
			//Żeby na liście rozwijanej było widac ligi
			var leagues = _dbContext.Leagues.ToList();
			var leaguesList = new List<SelectListItem>();
			foreach (var league in leagues)
			{
				string? text = league.Name;
				string id = league.Id.ToString();
				leaguesList.Add(new SelectListItem(text, id));
			}
			ViewBag.leagueList = leaguesList;
			return View();
		}

		[HttpPost]
		public IActionResult Add(Team team)
		{
			team.FoundingDate = DateTime.Now;

			var league = _dbContext.Leagues.FirstOrDefault(t => t.Id == team.Id);
			team.League = league;

			_dbContext.Teams.Add(team);
			_dbContext.SaveChanges();
			return View("Added", team);
		}
	}
}
