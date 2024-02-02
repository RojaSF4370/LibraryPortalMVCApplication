using System;
using System.Collections.Generic;

namespace LibraryApplication.Models
{
    public partial class BookCategory
    {
        public BookCategory()
        {
            Books = new HashSet<Book>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
