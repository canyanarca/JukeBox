using JukeBox.Models;
using JukeBox.Models.Context;
using JukeBox.Models.Entities;
using JukeBox.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using X.PagedList;

namespace JukeBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly JukeBoxContext _context;

        public HomeController(JukeBoxContext context)
        {
            this._context = context;
        }

        public IActionResult Contact()
        {
            return View();
        }

        [Route("Home/ContactUs")]
        public IActionResult LoggedInContact()
        {
            return View();
        }

        public IActionResult Index()
        {
            var gameCategoryViewModels = _context.Games
            .Include(game => game.GameCategories)
            .ThenInclude(gc => gc.Category)
            .Select(game => new GameCategoryViewModel
            {
                Game = game,
                Categories = game.GameCategories.Select(gc => gc.Category).ToList()
            })
            .ToList();

            return View(gameCategoryViewModels);
        }
        public IActionResult Shop(int? page)
        {
            int pageSize = 8; // Number of items per page
            int pageNumber = page ?? 1; // Default to page 1

            var gameCategoryViewModels = _context.Games
            .Include(game => game.GameCategories)
            .ThenInclude(gc => gc.Category)
            .Select(game => new GameCategoryViewModel
            {
                Game = game,
                Categories = game.GameCategories.Select(gc => gc.Category).ToList()
            })
            .ToList();
           
            var pagedGameCategoryViewModels = gameCategoryViewModels.ToPagedList(pageNumber, pageSize);


            return View(pagedGameCategoryViewModels); 
        }
        [Route("Home/ProductDetails/{urlName}")]
        public IActionResult ProductDetails(string urlName) 
        {
            var game = _context.Games
                .FirstOrDefault(g => g.UrlName == urlName);

            return View(game);
        }
        [Route("Home/Detail/{urlName}")]
        public IActionResult LoggedInProductDetails(string urlName)
        {
            var game = _context.Games
    .FirstOrDefault(g => g.UrlName == urlName);

            return View(game);
        }

        [HttpGet]
        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGame (GameViewModel gameModel) 
        {
            if (ModelState.IsValid)
            {
                var game = new Game
                {
                    Name = gameModel.Name,
                    Description = gameModel.Description,
                    Id = Guid.NewGuid(),
                    UserID = new Guid("bba825dc-7374-4005-87f4-a5f83c339791"),
                    UrlName = gameModel.Name.Replace(" ", "").ToLower(),
                    Image = "not-provided.jpg"
                    
                };
                    

                _context.Games.Add(game);
                _context.SaveChanges();
                string newGameUrlName = game.UrlName;

                return RedirectToAction("LoggedInProductDetails", new { urlName = newGameUrlName }); 
            }
            return View(gameModel); 
        }

        [Route("Home/Main")]
        public IActionResult LoggedInIndex() 
        {
            var gameCategoryViewModels = _context.Games
            .Include(game => game.GameCategories)
            .ThenInclude(gc => gc.Category)
            .Select(game => new GameCategoryViewModel
            {
                Game = game,
                Categories = game.GameCategories.Select(gc => gc.Category).ToList()
            })
            .ToList();

            return View(gameCategoryViewModels);
        }
        [Route("Home/Games")]
        public IActionResult LoggedInShop(int? page)
        {
            int pageSize = 8; // Number of items per page
            int pageNumber = page ?? 1; // Default to page 1

            var gameCategoryViewModels = _context.Games
            .Include(game => game.GameCategories)
            .ThenInclude(gc => gc.Category)
            .Select(game => new GameCategoryViewModel
            {
                Game = game,
                Categories = game.GameCategories.Select(gc => gc.Category).ToList()
            })
            .ToList();

            var pagedGameCategoryViewModels = gameCategoryViewModels.ToPagedList(pageNumber, pageSize);


            return View(pagedGameCategoryViewModels);
        }
        

    }
}
