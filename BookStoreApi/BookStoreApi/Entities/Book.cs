using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Entities
{
    public class Book
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Aouto id 
        public int Id { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; } // This property refers to the Author's Id
        public int GenreId { get; set; } // This property refers to the Genre's Id

        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
