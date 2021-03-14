using EFCoreLibraryDatabaseHomework.Data;
using System;
using System.Linq;

namespace EFCoreLibraryDatabaseHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new LibraryDatabaseContext())
            {
                Console.WriteLine("1) Выведите список должников.");
                var debtors = (from reader in context.Readers
                               join lendingBook in context.LendingBooks on reader.Id equals lendingBook.ReaderId
                               join book in context.Books on lendingBook.BookId equals book.Id
                               select reader).ToList();
                foreach (var reader in debtors)
                {
                    Console.WriteLine($"\t{reader.Id}. {reader.FullName}");
                }



                Console.WriteLine("\n2) Выведите список авторов книги №3 (по порядку из таблицы ‘Book’)."); 
                var authorOfBook = (from authors in context.Authors
                                   join bookAuthor in context.BooksAuthors on authors.Id equals bookAuthor.AuthorId
                                   join books in context.Books on bookAuthor.BookId equals books.Id  
                                   where books.Id == 3
                                   select authors).ToList();
                foreach (var author in authorOfBook)
                {
                    Console.WriteLine($"\t{author.Id}. {author.FullName}");
                }


                Console.WriteLine("\n3) Выведите список книг, которые доступны в данный момент.");
                var freeBooks = (from book in context.Books
                                     where !context.LendingBooks.Any(lendingBook => (lendingBook.BookId == book.Id))
                                     select book).ToList();

                foreach (var book in freeBooks)
                {
                    Console.WriteLine($"\t{book.Id}. {book.Name}");
                }



                Console.WriteLine("\n4) Вывести список книг, которые на руках у пользователя №2.");
                var userBooks = (from reader in context.Readers
                                join lendingBook in context.LendingBooks on reader.Id equals lendingBook.ReaderId
                                join books in context.Books on lendingBook.BookId equals books.Id
                                where reader.Id == 2
                                select books).ToList();

                foreach(var book in userBooks)
                {
                    Console.WriteLine($"\t{book.Id}. {book.Name}");
                }


                // 5) Обнулите задолженности всех должников.
                /*var lendingBooks = context.LendingBooks.ToList(); 
                foreach(var lendingBook in lendingBooks)
                {
                    context.LendingBooks.Remove(lendingBook);
                }
                context.SaveChanges();*/

            }
        }
    }
}
