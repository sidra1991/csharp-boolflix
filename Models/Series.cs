using Microsoft.Build.Framework;

namespace csharp_boolflix.Models
{
    public class Series
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public int? NumberEpisodes { get; set; }
        public List<Media> Episodies { get; set; }

        
    }
}
