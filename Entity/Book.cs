

namespace LibraryManagementSystem.Entity
{
     class Book
    {
        private int _totalCopies;
        private int _availableCopies;
        private string _iSBN;
        private string _title;
        private int _pagesCount;
        private string _language;
        private DateTime _publishedYear;
        public int Id { get; private set; }
        
        public string ISBN {  get { return _iSBN; } set {
                if (value == null)
                {
                    throw new ArgumentNullException("ISBN Can Not Be Null");
                }
                _iSBN = value;
            
            
            } }

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Title cannot be empty");

                _title = value;
            }
        }

        public DateTime PublishedYear
        {
            get { return _publishedYear; } set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Published year cannot be in the future");

                _publishedYear = value;
            }
        }

        public int PagesCount
        {
            get { return _pagesCount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Pages count must be greater than zero");

                _pagesCount = value;
            }
        }

        public string Language
        {
            get { return _language; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Language cannot be empty");

                _language = value;
            }
        }

        public string Description { get; set; }
        public int TotalCopies {
            get { return _totalCopies; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Total copies cannot be negative");
                }
                if (value < AvailableCopies)
                {
                    throw new Exception("Total copies cannot be less than available copies");
                }
                _totalCopies = value;
            } }

        public int AvailableCopies { get { return _availableCopies; } set{
                if (value < 0)
                {
                    throw new Exception("Total copies cannot be negative");
                }
                if (value > TotalCopies)
                {
                    throw new Exception("Available Copies cannot be Large than Total copies");
                }
                _availableCopies= value;
            }
        }
        public int CategoryId {  get; set; }
       public Category Category { get; set; }

        public int PublisherId {  get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<Author> Authors { get; set; }

        public ICollection<BorrowTransaction> BorrowTransactions { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

        public ICollection<Review> Reviews { get; set; }


    }
}
