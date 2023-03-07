using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameLibrary.Data;
using VideoGameLibrary.Interface;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
	public class HomeController : Controller
	{
        IDataAccessLayer dal;

        public HomeController(IDataAccessLayer indal)
        {
            dal = indal;
        }

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
        public IActionResult GameView()
        {
            return View("GameView", dal.getGames());
        }

        [HttpPost]
        public IActionResult GameView(string name, string title)
        {
            //dal.loanGame(name, title);

            return View("GameView", dal.getGames());
        }

        public IActionResult Delete(int? id)
        {
            if (dal.getGame(id) == null)
            {
                ModelState.AddModelError("Title", "Game not found for delete");
            }

            if (ModelState.IsValid)
            {
                dal.removeGame(id);
                TempData["Success"] = "Game Deleted";
            }
            return RedirectToAction("GameView", "Home");
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

        [HttpPost]
        public IActionResult Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return View("GameView", dal.getGames());
            }
            return View("GameView", dal.getGames().Where(c => c.Title.ToLower().Contains(key.ToLower())));
        }

        [HttpGet] //Edit form loads
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Games foundGame = dal.getGame(id);

            if (foundGame == null)
                return NotFound();

            return View(foundGame);
        }

        [HttpPost] //save
        public IActionResult Edit(Games m)
        {
            dal.editGame(m);
            return RedirectToAction("GameView", "Home");
        }

        [HttpGet] //Create form loads
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //Create form saves
        public IActionResult Create(Games m)
        {
            if (ModelState.IsValid)
            {
                dal.addGame(m);
                TempData["success"] = "Game added";
                return RedirectToAction("GameView", "Home");
            }

            return View();
        }

        public IActionResult Filter(string? Genre, string? ESRB, string? Platform)
        {
            return View("GameView", dal.FilterGames(Genre, ESRB, Platform));
        }
    }


}