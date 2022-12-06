namespace csharp_boolflix.Models.repository
{
    public interface _Repository
    {

        public List<Media> GetAllMedia();
        public List<Film> GetAllFilm();
        public List<Series> GetAllSeries();
        public List<SeriesAndFilms> SeriesAndFilms();
        public Film GetAfilm(int id);
        public Series GetAseries(int id);
    }
}
