

using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entity;

namespace LibraryManagementSystem.Operations
{
   
     class BorrowTransactionOperations
    {
        private static AppDbContext context = new AppDbContext();
        public static BorrowTransaction SearchBorrowTransaction(int BorrowTransactionId)
        {
            var existingBorrowTransaction = context.BorrowTransactions.FirstOrDefault(x => x.Id == BorrowTransactionId);
            if (existingBorrowTransaction == null)
            {
                throw new ArgumentException($"Borrow Transactions does not exist.");
            }
            return existingBorrowTransaction;
        }
        public static void AddBorrowTransactionOperation(int bookId,int memberId, int librarianId)
        {
           var existingBook= BookOperations.SearchBook(bookId);
            var existingMember= MemberOperations.SearchMember(memberId);
           

            if (!existingMember.MembershipStatus)
                throw new InvalidOperationException("Member's membership is not active.");

            if (existingBook.AvailableCopies<0)
                throw new InvalidOperationException("Numbers of Available Copies is Less than Zero.");



            BorrowTransaction borrowTransaction = new BorrowTransaction();
                borrowTransaction.BookId = bookId;
                borrowTransaction.MemberId = memberId;
                borrowTransaction.LibrarianId = librarianId;
                borrowTransaction.BorrowDate = DateTime.Now;
                borrowTransaction.DueDate = DateTime.Now.AddDays(14)  ;
               
                borrowTransaction.Status = "Borrowed";

            existingBook.AvailableCopies--; 
                                            
                                            

            context.Books.Update(existingBook);

            context.BorrowTransactions.Add(borrowTransaction);
               context.SaveChanges();


        }
    }
}
