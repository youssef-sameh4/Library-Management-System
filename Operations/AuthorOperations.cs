

using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entity;

namespace LibraryManagementSystem.Operations
{
     class AuthorOperations
    {
        private static AppDbContext context = new AppDbContext();
        public static Author SearchAuthor(int authorId )
        {
            var existingAuthor = context.Authors.FirstOrDefault(x => x.Id == authorId);
            if (existingAuthor == null)
            {
                throw new ArgumentException($"Author does not exist.");
            }
            return existingAuthor;
        }
        public static void AddAuthor(Author author)
        {

            context.Authors.Add(author);
            context.SaveChanges();
        }
        public static void UpdateAuthor(Author author, int authorId)
        {
            var existingAuthor = SearchAuthor(authorId);

            existingAuthor.Name = author.Name;
            existingAuthor.BirthDate = author.BirthDate;
            existingAuthor.Biography=author.Biography;
            existingAuthor.Nationality= author.Nationality;
           
            context.SaveChanges();
        }
        public static bool DeleteAuthor(int authorId)
        {
            var existingAuthor = SearchAuthor(authorId);
            context.Authors.Remove(existingAuthor);
            context.SaveChanges();
            return true;
        }
        public static List<Author> ReadAllAuthors()
        {
            return context.Authors.ToList();
        }
        public static List<Book> GetAuthorBooks(int authorId)
        {
            var author = SearchAuthor(authorId);

            return context.Books
                          .Where(x => x.Id == authorId)
                          .ToList();
        }

    }

}
