
namespace LibraryManagementSystem.Entity
{
    class Author
    {
        private string _name;
        private string _nationality;
        private DateTime _birthDate;
        public int Id { get; private set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Author name cannot be empty");

                _name = value;
            }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; } set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Birth date cannot be in the future");

                _birthDate = value;
            }
        }

        public string Nationality
        {
            get { return _nationality; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nationality cannot be empty");

                _nationality = value;
            }
        }

        public string Biography {  get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
