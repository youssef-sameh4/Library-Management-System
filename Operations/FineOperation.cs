using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Operations
{
    class FineOperation
    {
        private static AppDbContext context = new AppDbContext();

        public static void CreatedFine(int borrowTransactionId)
        {
            var existingBorrowTransaction = BorrowTransactionOperations.SearchBorrowTransaction(borrowTransactionId);
            var lateDays = (DateTime.Now - existingBorrowTransaction.DueDate).Days;
            if (lateDays > 0)
            {
                decimal fine = lateDays * 5;

                Fine Fine = new Fine();
                Fine.BorrowTransactionId = borrowTransactionId;
                Fine.Amount = fine;
                Fine.IssuedDate = DateTime.Now;
                Fine.IsPaid = false;
                context.Fines.Add(Fine);
                context.SaveChanges();
            }
        }
    }
}
