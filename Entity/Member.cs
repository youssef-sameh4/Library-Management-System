
namespace LibraryManagementSystem.Entity
{
    class Member
    {
        public int Id { get; private set; }
        private string _name;
        private string _email;
        private string _phone;
        private string _address;
        private DateTime _joinDate;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Member name cannot be empty");
                _name = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email cannot be empty");
                if (!value.Contains("@"))
                    throw new ArgumentException("Email must be valid");
                _email = value;
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Phone cannot be empty");
                if (value.Length < 7 || value.Length > 15)
                    throw new ArgumentException("Phone number must be between 7 and 15 digits");
                _phone = value;
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Address cannot be empty");
                _address = value;
            }
        }

        public DateTime JoinDate
        {
            get { return _joinDate; } set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Join date cannot be in the future");
                _joinDate = value;
            }
        }
        public bool MembershipStatus { get; set; }

        public ICollection<BorrowTransaction> BorrowTransactions { get; set; }
        public ICollection<Reservation>  Reservations { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
