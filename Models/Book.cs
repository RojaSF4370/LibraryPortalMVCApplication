using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryApplication.Models
{
    public partial class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Book name is required.")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Book name must contain alphabetic characters only.")]
        public string BookName { get; set; } = null!;
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Author name must contain alphabetic characters only.")]

        public string? AuthorName { get; set; }
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Published year must be a 4-digit number.")]
        [Range(1000, int.MaxValue, ErrorMessage = "Published year must be greater than 1000.")]
        public int? PublishedYear { get; set; }
        public decimal? Price { get; set; }


        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public int BookCategoryId { get; set; } 

        public virtual BookCategory? BookCategory { get; set; }
    }
}
