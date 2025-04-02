using Microsoft.AspNetCore.Mvc;
using AS_Kol_1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AS_Kol_1.Controllers
{
	public class AuthorController : Controller
	{
		private readonly MyDbContext _dbcontext;

		public AuthorController(MyDbContext myDbContext)
		{
			_dbcontext = myDbContext;
		}
		public IActionResult Index()
		{
			ViewBag.Title = "Author";
			return View();
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Author author)
		{
			_dbcontext.Authors.Add(author);
			_dbcontext.SaveChanges();
			return View("Added", author);
		}
	}
}
