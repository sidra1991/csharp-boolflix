using Microsoft.Build.Framework;

namespace csharp_boolflix.Models
{
    public class Media
    {
        public int Id { get; set; }
        [Required]
        public string VideroUrl { get; set; }

        public int? IdSeries { get; set; }
        public Series Series { get ; set ; }
}
}
