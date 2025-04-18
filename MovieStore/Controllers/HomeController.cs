
using MovieStore.Models;

using Microsoft.AspNetCore.Mvc;
using MovieStore;
using System.Diagnostics;
using MovieStore.Models.DTOs;

namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string sterm = "", int genreId = 0)
        {
            IEnumerable<Book> books = await _homeRepository.GetBooks(sterm, genreId);
            IEnumerable<Genre> genres = await _homeRepository.Genres();
            BookDisplayModel bookModel = new BookDisplayModel
            {
                Books = books,
                Genres = genres,
                STerm = sterm,
                GenreId = genreId
            };
            return View(bookModel);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PromotionDetails()
        {
            // Example promotion details
            var promotionDetails = "Get 20% off on all Mystery Books. Limited time offer!";

            // Pass promotion details to the view
            ViewBag.PromotionDetails = promotionDetails;

            return View();
        }
        public IActionResult MovieDetails()
        {
            // Example movie details data (replace with actual movie details)
            var movieDetails = new
            {
                name = "Sample Movie",
                image = "/images/cotton candy.jpg",
                price = 25.99,
                discount = 20
            };

            return Json(movieDetails);
        }
    }

}

