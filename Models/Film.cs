using System.ComponentModel.DataAnnotations;

namespace csharp_boolflix.Models
{
    public class Film
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

        [Required]
        public string VideUrl { get; set; }

        public List<Cast>? Casts { get; set; }


    }
}
