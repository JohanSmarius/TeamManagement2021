using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portal.Models;
using System.Diagnostics;
using System.Linq;
using Core.Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GameRepository _gameRepository;
        private readonly CoachRepository _coachRepository;
        private readonly PlayerRepository _playerRepository;

        public HomeController(ILogger<HomeController> logger, 
            GameRepository gameRepository, CoachRepository coachRepository, 
            PlayerRepository playerRepository)
        {
            _logger = logger;
            _gameRepository = gameRepository;
            _coachRepository = coachRepository;
            _playerRepository = playerRepository;
        }

        public IActionResult Index()
        {
            return View(_gameRepository.Games.ToViewModel());
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

        [HttpGet]
        public IActionResult NewGame()
        {
            var model = new NewGameViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewGame(NewGameViewModel newGame)
        {
            if (ModelState.IsValid)
            {
                var gameToCreate = new Game(newGame.PlayTime, newGame.IsHomeGame);
                gameToCreate.Opponent = new Opponent() {Name = newGame.Opponent};

                _gameRepository.Games.Add(gameToCreate);

                return RedirectToAction("Index");
            }
            return View(newGame);

        }
    }
}
