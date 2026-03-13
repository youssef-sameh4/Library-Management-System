using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entity
{
    class Reservation
    {
        public int Id { get; private set; }
        private DateTime _reservationDate;
        private string _status;
        public DateTime ReservationDate
        {
            get { return _reservationDate; } set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Reservation date cannot be in the future");
                _reservationDate = value;
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Status cannot be empty");

                var validStatuses = new[] { "Pending", "Completed", "Cancelled" };
                if (!validStatuses.Contains(value))
                    throw new ArgumentException("Status must be 'Pending', 'Completed' or 'Cancelled'");

                _status = value;
            }
        }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int MemberId { get; set; }
        public Member Member { set; get; }

        public int LibrarianId { get; set; }
        public Librarian Librarian { get; set; }    


    }
}
