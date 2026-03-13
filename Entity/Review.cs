using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entity
{
    class Review
    {
        public int Id { get; private set; }
        public int Rating {  get; set; }
        public string Comment {  get; set; }
        private DateTime _reviewDate;
        public DateTime ReviewDate { get { return _reviewDate; } set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Issued date cannot be in the future");
                _reviewDate = value;
            } }


        public int BookId { get; set; }
        public Book Book { get; set; }

        public int MemberId { get; set; }

        public Member Member { set; get; }

    }
}
