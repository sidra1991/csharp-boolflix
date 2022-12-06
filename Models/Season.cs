using Microsoft.Build.Framework;

namespace csharp_boolflix.Models
{
    public class Season
    {
        public int Id { get; set; }
        public int Number { get; set; }
        [Required]
        public string Title { get; set; }

        public int SeriesId { get; set; }
        public Series? Series { get; set; }
        public List<Media>? Episodies { get; set; }


    }
}
