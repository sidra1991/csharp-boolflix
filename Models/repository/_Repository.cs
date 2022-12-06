namespace csharp_boolflix.Models.repository
{
    public interface _Repository
    {

        public List<Media> GetAllMedia();
        public List<Film> GetAllFilm();
        public List<Series> GetAllSeries();
        public List<SeriesAndFilms> SeriesAndFilms();
       
        public Series GetAseries(int id);

        /* function for films 
         * ----------------
         * ---------------*/
        public Film GetAfilm(int id);

        public void AddFilm(Film film); 

        public void UpdateFilm(Film Film);
        void RemoveFilm(int Id);
    }
}
