using csharp_boolflix.Models.repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class BoolfixController : Controller
    {
        _Repository repo;
        public BoolfixController(_Repository _repository) : base()
        {
            repo = _repository;
        }
        public IActionResult Home()
        {
            return View(repo.SeriesAndFilms());

        }

        public IActionResult Film()
        {

            return View(repo.GetAllFilm());
        }

        public IActionResult SerieTv()
        {

            return View(repo.GetAllSeries());
        }

        public IActionResult NuoviEPopolari()
        {
            //attualmente fake verra implementata domani
            return View(repo.SeriesAndFilms());
        }

        public IActionResult Lista()
        {
            //da implementare mi serve l'interazione con gli user
            return View(repo.SeriesAndFilms());
        }

        public IActionResult PerLingua()
        {
            //da implementare insieme al DB
            return View(repo.SeriesAndFilms());
        }
    }
}
