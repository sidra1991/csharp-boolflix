namespace csharp_boolflix.Models.ClassForm
{
    public class FormMedia
    {
        public List<Series>? series { get; set; }
        public int SeasonId { get; set; }
        public Media? Media { get; set; }
        public Season? season { get; set; }
    }
}
