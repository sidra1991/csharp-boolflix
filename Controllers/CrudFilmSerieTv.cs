using csharp_boolflix.Models;
using csharp_boolflix.Models.ClassForm;
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


        /* delete Film
         * -----------
         * ---------*/
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


        /* create for series
         * ----------------
         * --------------*/
        public IActionResult CreateSeries()
        {
            Series NewSeries = new();

            return View(NewSeries);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSeries(Series NewSeries)
        {

            if (!ModelState.IsValid)
            {
                return View(NewSeries);
            }

            repo.AddSeries(NewSeries);

            return View("../Home/Index");
        }


        /* create for Season
         * ----------------
         * --------------*/

        public IActionResult CreateSeason()
        {
            FormSeason form = new();
            form.series = new();
            form.series = repo.GetAllSeries();
            form.season = new();
            
            return View(form);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSeason(FormSeason form)
        {
            Season season = new Season();
            season.Title = form.season.Title;
            Series serie = repo.GetSeries(form.SerieId);
            season.Number = serie.Seasons.Count() + 1;
            
            season.SeriesId = form.SerieId;


            if (!ModelState.IsValid)
            {
                form.series = new();
                form.series = repo.GetAllSeries();
                form.season = new();
                return View(form);
            }
            


            repo.AddSeason(season);

            return View("../Home/Index");
        }

        /* create for Media
       * ----------------
       * --------------*/

        public IActionResult CreateMedia()
        {
            FormMedia form = new();
            form.Media = new();
            form.series = repo.GetAllSeries();
            return View(form);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMedia(FormMedia form)
        {
            Media media = new Media();
            media.Name = form.Media.Name;


            Season season = repo.GetAseason(form.SeasonId);
            media.Number = season.Episodies.Count() + 1;


            media.SeasonId = form.SeasonId;


            if (!ModelState.IsValid)
            {
                form.Media = new();
                form.series = repo.GetAllSeries();
                return View(form);
            }



            repo.AddMedia(media);

            return View("../Home/Index");
        }
    }
}
