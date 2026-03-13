using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Operations
{
     class LibrarianOperations
    {
        private static AppDbContext context = new AppDbContext();
        public static Librarian SearchLibrarian(int librarianId)
        {
            var existingLibrarian = context.Librarians.Find(librarianId);
            if (existingLibrarian == null)
            {
                throw new ArgumentException($" Librarian does not exist.");
            }
            return existingLibrarian;
        }
        public static void AddLibrarian(Librarian librarian)
        {
            context.Librarians.Add(librarian);
            context.SaveChanges();
        }

        public static void UpdateLibrarian(Librarian librarian,int Id)
        {
            var existingLibrarian = SearchLibrarian(Id);
            existingLibrarian.Name = librarian.Name;
            existingLibrarian.Email = librarian.Email;
            existingLibrarian.Phone = librarian.Phone;
            existingLibrarian.Role = librarian.Role;


            context.SaveChanges();

        }
        public static bool DeleteLibrarian(int librarianId)
        {

            var existingLibrarian = SearchLibrarian(librarianId);
            context.Librarians.Remove(existingLibrarian);
            context.SaveChanges();
            return true;

        }
        public static List<Librarian> ReadAllLibrarians()
        {
            return context.Librarians.ToList();
        }
        public static List<BorrowTransaction> ReadBorrowTransaction(int librarianId)
        {
            return context.BorrowTransactions.Where(x=>x.LibrarianId == librarianId).ToList();
        }
        public static List<Reservation> GetReservations(int librarianId)
{
    return context.Reservations
                  .Where(x => x.LibrarianId == librarianId)
                  .ToList();
}
    }
}
