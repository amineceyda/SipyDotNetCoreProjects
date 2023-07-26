using System.ComponentModel.DataAnnotations.Schema;

namespace QuoteApi.Entities
{
    public class Quote
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? Text { get; set; }
    }
}
