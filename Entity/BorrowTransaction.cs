using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entity
{
    class BorrowTransaction
    {
        private DateTime _borrowDate;
        private DateTime _dueDate;
        private string _status;
        public int Id { get; private set; }
        
        public DateTime BorrowDate {
            get { return _borrowDate; } set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Borrow date cannot be in the future");
                _borrowDate = value;
            }
        }
        public DateTime DueDate { get { return _dueDate; } set {

                if (value < BorrowDate)
                    throw new ArgumentException("Due date cannot be before borrow date");
                _dueDate = value;

            } }
        public DateTime? ReturnDate {  get; set; }
        public string Status { get { return _status; } set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Status cannot be empty");

                var validStatuses = new[] { "Borrowed", "Returned", "Late" };
                if (!validStatuses.Contains(value))
                    throw new ArgumentException("Status must be 'Borrowed', 'Returned' or 'Late'");

                _status = value;

            } }

        public int BookId { set; get; }
        public Book Book { set; get; }

        public int MemberId { get; set; }
        public Member Member { set; get; } 

        public int LibrarianId {  set; get; }
        public Librarian Librarian { set; get; }
        public Fine Fine {  set; get; }
    
}
}
