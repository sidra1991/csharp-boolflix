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




        /* create of films
        ------------------
        -----------------*/
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


        /* update of films
        ------------------
        -----------------*/

        public IActionResult UpdateFilm(int id)
        {
            Film updateFilm = repo.GetAfilm(id);

            if (updateFilm == null)
                return NotFound();

            return View("CreateFilm", updateFilm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateFilm(Film updateFilm)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateFilm", updateFilm);
            }


            if (updateFilm == null)
            {
                return NotFound();
            }

            repo.UpdateFilm(updateFilm);

            return View("../Home/index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFilm(int id)
        {
            if (repo.GetAfilm(id) == null)
            {
                return NotFound();
            }
            repo.RemoveFilm(id);


            return RedirectToAction(" Indice ");
        }
    }
}
