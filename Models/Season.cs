using Microsoft.Build.Framework;

namespace csharp_boolflix.Models
{
    public class Season
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }

        [Required]
        public Series Series { get; set; }
        public List<Media> Episodies { get; set; }


    }
}
