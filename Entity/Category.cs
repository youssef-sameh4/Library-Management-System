using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entity
{
    class Category
    {
        private string _name;
        public int Id { get; private set; }
        public string CategoryName
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Author name cannot be empty");

                _name = value;

            }
        }

        public string? Description { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
