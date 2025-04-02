using AS_Kol_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AS_Kol_1.Controllers
{
	public class PlayerController : Controller
	{
		private readonly MyDbContext _dbContext;

		public PlayerController(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index()
		{
			ViewBag.Title = "Player";
			var players = _dbContext.Players
			.OrderByDescending(a => a.Id)
			.Include(a => a.Positions)
			.Include(a => a.Team)
			.ToList();
			return View(players);
		}

		public IActionResult Add()
		{
			var teams = _dbContext.Teams.ToList();
			var teamsList = new List<SelectListItem>();
			foreach (var a in teams)
			{
				string text = a.Name + " " + a.Country + " " + a.City;
				string id = a.Id.ToString();
				teamsList.Add(new SelectListItem(text, id));
			}
			ViewBag.teamsList = teamsList;

			ViewBag.Positions = _dbContext.Positions.Select(a => new SelectListItem
			{
				Value = a.Id.ToString(),
				Text = a.Name
			})
				.ToList();


			return View();
		}

		[HttpPost]
		public IActionResult Add(Player player, List<int> posi)
		{
			if (ModelState.IsValid)
			{
				player.BirthDate = DateTime.Now;


				var team = _dbContext.Teams.FirstOrDefault(a => a.Id == player.TeamId);
				if (team == null) //można wykonać takie sprawdzenie, w razie braku - błąd na etapie "SaveChanges"
				{
					return View("Error");

				}
				player.Team = team; //jeśli nie przypiszemy, dane zostaną poprawnie zapisianie w bazie, ale nie będzie pobrany Autor do tej encji

				var positions = posi != null ? _dbContext.Positions.Where(t => posi.Contains(t.Id)).ToList() : new List<Position>();

				player.Positions = positions;

				_dbContext.Players.Add(player);
				_dbContext.SaveChanges();
				return View("Added", player);
			}
			return View(player);
		}
	}
}
