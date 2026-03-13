using LibraryManagementSystem.Data;


namespace LibraryManagementSystem.Operations
{
     class ReturnBook
    {
        public static void CreatedReturnBook(int borrowTransactionId)
        {
            using (var context = new AppDbContext())
            {
                var existingBorrowTransaction = context.BorrowTransactions
                    .FirstOrDefault(bt => bt.Id == borrowTransactionId);

                if (existingBorrowTransaction == null)
                {
                    throw new ArgumentException($"BorrowTransaction with Id {borrowTransactionId} does not exist.");
                }

                if (existingBorrowTransaction.Status != "Borrowed")
                {
                    throw new InvalidOperationException("This book has not been borrowed or has already been returned.");
                }

                existingBorrowTransaction.Status = "Returned";

                var book = context.Books.FirstOrDefault(b => b.Id == existingBorrowTransaction.BookId);
                if (book != null)
                {
                    book.AvailableCopies++;
                    existingBorrowTransaction.ReturnDate = DateTime.Now;
                    context.SaveChanges();
                }
                FineOperation.CreatedFine(existingBorrowTransaction.Id);
                var pendingReservation = context.Reservations
                    .Where(r => r.BookId == existingBorrowTransaction.BookId && r.Status == "Pending")
                    .OrderBy(r => r.ReservationDate) // الأقدم له أولوية
                    .FirstOrDefault();

                if (pendingReservation != null)
                {
                    pendingReservation.Status = "Completed";
                    // ممكن هنا تبعت إشعار للعضو عن الحجز
                }

                context.SaveChanges();
            }
        }
    }
}
