namespace csharp_boolflix.Models.repository
{
    public interface _Repository
    {

        public List<Media> GetAllMedia();
        public List<Film> GetAllFilm();
      
        public List<SeriesAndFilms> SeriesAndFilms();
       
        public Series GetAseries(int id);

        /* function for films 
         * ----------------
         * ---------------*/
        public Film GetAfilm(int id);

        public void AddFilm(Film film); 

        public void UpdateFilm(Film Film);
        void RemoveFilm(int Id);

        /* function series
         * --------------
         * --------------*/

        public void AddSeries(Series serie);
        public void AddSeason(Season season); 
        public List<Series> GetAllSeries();
        public Series GetSeries(int id);
        List<Season> GetAllSeason(int Id);
        void AddMedia(Media media);
        Season GetAseason(int id);
        Media GetAMedia(int id);
    }
}
