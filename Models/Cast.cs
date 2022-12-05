namespace csharp_boolflix.Models
{
    public class Cast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public List<Media> Medias { get; set; }
        public List<Film> Films { get; set; }
    }
}
