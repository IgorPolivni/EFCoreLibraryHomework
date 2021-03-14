using System;

namespace EFCoreLibraryDatabaseHomework.Models
{
    public class BooksAuthors : Entity
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }
}
