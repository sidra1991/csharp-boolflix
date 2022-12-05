using csharp_boolflix.Data;

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
            return db.Series.ToList();
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


    }
}
