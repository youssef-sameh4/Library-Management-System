using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entity
{
    class Publisher
    {
        private string _publisherName;
        private string _country;
        private DateTime _establishedYear;
        public int Id { get; private set; }
        public string PublisherName
        {
            get { return _publisherName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Publisher name cannot be empty");

                _publisherName = value;
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Country cannot be empty");

                _country = value;
            }
        }

        public DateTime EstablishedYear
        {
            get { return _establishedYear; } set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Established year cannot be in the future");

                _establishedYear = value;
            }
        }
        public string ? Website {  get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
