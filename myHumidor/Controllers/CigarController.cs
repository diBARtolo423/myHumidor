using Microsoft.AspNetCore.Mvc;
using myHumidor.Models;

namespace myHumidor.Controllers
{
    public class CigarController : Controller
    {
        private readonly ICigarRepo repo;

        public CigarController(ICigarRepo cigarRepo)
        {
            this.repo = cigarRepo;
        }

        public IActionResult Index()
        {
            var cigar = new Cigar();
            cigar = repo.GetCigarList();
            return View(cigar);
        }

        public IActionResult Search(string searchString)
        {
            var searchResults = repo.SearchCigars(searchString);
            return View(searchResults);
        }

        public IActionResult Favorites(Cigar cigar)
        {
            return View(Cigar.Favorites);
        }

        public IActionResult UpdateFavoriteToIndex(IEnumerable<int> favorites)
        {
            repo.AddFavorites(favorites);
            return RedirectToAction("Favorites");
        }
    }
}

