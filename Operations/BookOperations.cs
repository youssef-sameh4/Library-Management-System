

using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entity;

namespace LibraryManagementSystem.Operations
{
    class BookOperations
    {
        private static AppDbContext context = new AppDbContext();
        public static Book SearchBook(int bookId)
        {
            var existingBook = context.Books.FirstOrDefault(x => x.Id == bookId);
            if (existingBook == null)
            {
                throw new ArgumentException($"Book does not exist.");
            }
            return existingBook;
        }
        public static void AddBook(Book book)
        {

            context.Books.Add(book);
            context.SaveChanges();
        }
        public static void UpdateBook(Book book, int bookId)
        {
            var existingBook = SearchBook(bookId);
           
            existingBook.Title = book.Title;
            existingBook.Description = book.Description;
            existingBook.ISBN = book.ISBN;
            existingBook.Language = book.Language;
            existingBook.TotalCopies = book.TotalCopies;
            existingBook.AvailableCopies = book.AvailableCopies;
            context.SaveChanges();
        }
        public static bool DeleteBook(int  bookId)
        {
            var existingBook = SearchBook(bookId);
            context.Books.Remove(existingBook);
            context.SaveChanges();
            return true;
        }
        public static List< Book> ReadAllBooks()
        {
            return context.Books.ToList();
        }
    }
}
