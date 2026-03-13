using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entity
{
    class Fine
    {
        public int Id { get; private set; }
        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Amount), "Fine amount cannot be negative");

                _amount = value;
            }
        }
        private DateTime _issuedDate;
        public DateTime IssuedDate { get { return _issuedDate; } set {
                if (value > DateTime.Now)
                    throw new ArgumentException("Issued date cannot be in the future");
                _issuedDate = value;
            } }
        public bool IsPaid { get; set; }

        public int BorrowTransactionId { get; set; }
        public BorrowTransaction BorrowTransaction { get; set; }

    }
}
