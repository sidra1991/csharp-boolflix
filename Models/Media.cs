using Microsoft.Build.Framework;

namespace csharp_boolflix.Models
{
    public class Media
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //[Required]
        //public DateTime Date { get; set; }
        //[Required]
        //public string Duration { get; set; }
        [Required]
        public string Immage { get; set; }

        public int Number { get; set; }

        [Required]
        public string VideUrl { get; set; }
        public int SeasonId { get; set; }
        public Season? Season { get ; set ; }

        public List<Cast> Casts { get; set; }

    }
}
