using Microsoft.Build.Framework;

namespace csharp_boolflix.Models
{
    public class Series
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string immage { get; set; }
        public int? NumberEpisodes { get; set; }
        public List<Season> Seasons { get; set; }
    }
}
