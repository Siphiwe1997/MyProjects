using System.ComponentModel.DataAnnotations;

namespace BookList.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a year.")]
        [Range(2010, 2023, ErrorMessage = "Year must be between 2010 and now.")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter a author.")]
        public string Author { get; set; }


        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int? Rating { get; set; }

        [Required(ErrorMessage = "Please enter a booktype id.")]
        public int? BookTypeId { get; set; }

        public string Slug =>
        Name?.Replace(' ', '-').ToLower()+'-'+Author?.Replace(' ','-') + '-' + Year?.ToString();

        public BookType BookType { get; set; }

    }
}
