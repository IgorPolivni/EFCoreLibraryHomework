using System;


namespace EFCoreLibraryDatabaseHomework.Models
{
    public class LendingBooks : Entity
    {
        public int ReaderId { get; set; }
        public int BookId { get; set; }
    }
}
