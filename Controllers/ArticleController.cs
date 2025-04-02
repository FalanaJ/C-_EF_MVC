using AS_Kol_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AS_Kol_1.Controllers
{
    public class ArticleController : Controller
    {
		private readonly MyDbContext _dbContext;
		
		public ArticleController(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index()
        {
			ViewBag.Title = "Article";
			var articles = _dbContext.Articles
			.OrderByDescending(a => a.Id)
			.Include(a => a.Author)
			.ToList();
			return View(articles);
		}

		public IActionResult Add()
		{
			//Żeby na liście rozwijanej było widac imiona autorów
			var authors = _dbContext.Authors.ToList();
			var authorsList = new List<SelectListItem>();
			foreach (var a in authors)
			{
				string text = a.FirstName + " " + a.LastName;
				string id = a.Id.ToString();
				authorsList.Add(new SelectListItem(text, id));
			}
			ViewBag.authorsList = authorsList;
			return View();
		}

		[HttpPost]
		public IActionResult Add(Article article)
		{
			if(ModelState.IsValid)
			{
				article.CreationDate = DateTime.Now;

				var author = _dbContext.Authors.FirstOrDefault(x => x.Id == article.AuthorId);
				article.Author = author;

				_dbContext.Articles.Add(article);
				_dbContext.SaveChanges();
				return View("Added", article);
			}
			return View("Error");
		}
	}
}
