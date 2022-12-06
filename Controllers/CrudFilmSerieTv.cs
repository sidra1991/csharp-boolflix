using csharp_boolflix.Models;
using csharp_boolflix.Models.repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class CrudFilmSerieTv : Controller
    {
        _Repository repo;
        public CrudFilmSerieTv(_Repository _repository) : base()
        {
            repo = _repository;
        }
        public IActionResult CreateFilm()
        {
            Film NewFilm = new();


            return View(NewFilm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFilm(Film NewFilm)
        {
            if (!ModelState.IsValid)
            {
                return View(NewFilm);
            }

            repo.AddFilm(NewFilm);
            return View("../Home/index");
        }

    }
}
