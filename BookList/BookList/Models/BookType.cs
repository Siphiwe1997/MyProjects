using System.ComponentModel.DataAnnotations;

namespace BookList.Models
{
    public class BookType
    {
        public int BookTypeId { get; set; }

        [Required]
        public string BookTypeName { get; set; }

        //Navigation property
        public List<Book> Books { get; set; }
    }
}
