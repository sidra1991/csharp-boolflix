using csharp_boolflix.Data;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.Models.repository
{
    public class RepositoryMedia : _Repository
    {
        private BoolfixDbContext db;

        public RepositoryMedia(BoolfixDbContext _db)
        {
            db = _db;
        }

        public List<Film> GetAllFilm()
        {
            return db.Films.ToList();
        }
        public List<Media> GetAllMedia()
        {
            return db.Media.ToList();
        }
        public List<Series> GetAllSeries()
        {
            return db.Series.Include("Seasons").ToList();
        }

        public List<SeriesAndFilms> SeriesAndFilms()
        {

            List<SeriesAndFilms> seriesAndFilms = new List<SeriesAndFilms>();  
            foreach (Film item in GetAllFilm())
            {
                SeriesAndFilms seriesAndFilms1 = new();
                seriesAndFilms1.Name = item.Name;
                seriesAndFilms1.immage = item.Immage;
                seriesAndFilms1.OriginalId = item.Id;
                seriesAndFilms1.Video = item.VideUrl;
                seriesAndFilms1.Type = "Film";
                seriesAndFilms.Add(seriesAndFilms1);
            }
            foreach (Series item in GetAllSeries())
            {
                SeriesAndFilms seriesAndFilms1 = new();
                seriesAndFilms1.Name = item.Name;
                seriesAndFilms1.immage = item.immage;
                seriesAndFilms1.OriginalId = item.Id;
                seriesAndFilms1.Type = "Film";
                seriesAndFilms.Add(seriesAndFilms1);
            }

            return seriesAndFilms;
        }

        public Film GetAfilm(int id)
        {
            return db.Films.Where(fi => fi.Id == id).FirstOrDefault();
        }

        public Media GetAMedia(int id)
        {
            return db.Media.Where(fi => fi.Id == id).FirstOrDefault();
        }

        public Season GetAseason(int id)
        {

            Season season = db.Seasons.Where(se => se.Id == id).Include("Episodies").FirstOrDefault();

            foreach (Media item in season.Episodies)
            {
                GetAMedia(item.Id);
            }

            return season;
        }


        public Series GetAseries(int id)
        {
            Series series = db.Series.Where(se => se.Id == id).Include("Seasons").FirstOrDefault();

            foreach (Season item in series.Seasons)
            {
                GetAseason(item.Id);
            }

            return series;

        }

        public void AddFilm(Film film)
        {
            db.Films.Add(film);
            db.SaveChanges();
        }

        public void UpdateFilm(Film film)
        {
            db.Update(film);
            db.SaveChanges();
        }

        public void RemoveFilm(int Id)
        {
            db.Remove(GetAfilm(Id));
            db.SaveChanges();
        }


        /* function Series
         * 
         * -----------*/
        public void AddSeries(Series serie)
        {
            db.Series.Add(serie);
            db.SaveChanges();
        }
        public void AddSeason(Season season)
        {
            db.Seasons.Add(season);
            db.SaveChanges();
        }
        public Series GetSeries(int id)
        {
         return db.Series.Where(se => se.Id == id).Include("Seasons").FirstOrDefault();

        }

        public List<Season> GetAllSeason(int Id)
        {
            return GetAseries(Id).Seasons.ToList();
        }

        public void AddMedia(Media media)
        {
            db.Media.Add(media);
            db.SaveChanges();
        }
    }
}
