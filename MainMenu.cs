

using LibraryManagementSystem.Entity;
using LibraryManagementSystem.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem
{

    class MainMenu
    {
        enum MainMenuOption
        {
            Books = 1,
            Authors,
            Members,
            Librarians,
            Categories,
            Publishers,
            BorrowBook,
            ReturnBook,
            Exit
        }

        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("🛋️ ====================================");
                Console.WriteLine("      📚 Library Management System 📚      ");
                Console.WriteLine("🛋️ ====================================\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("🌟 Main Menu 🌟\n");
                Console.ResetColor();

                Console.WriteLine("[1] 📖 Manage Books");
                Console.WriteLine("[2] 🖋️ Manage Authors");
                Console.WriteLine("[3] 👥 Manage Members");
                Console.WriteLine("[4] 🧑‍💼 Manage Librarians");
                Console.WriteLine("[5] 🗂️ Manage Categories");
                Console.WriteLine("[6] 🏢 Manage Publishers");
                Console.WriteLine("[7] 📚 Borrow Book");
                Console.WriteLine("[8] 🔄 Return Book");
                Console.WriteLine("[9] ❌ Exit");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nChoose Option: ");
                Console.ResetColor();

                if (!int.TryParse(Console.ReadLine(), out int input) || input < 1 || input > 9)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⚠️ Invalid Option! Try Again...");
                    Console.ResetColor();
                    Pause();
                    continue;
                }

                MainMenuOption option = (MainMenuOption)input;

                switch (option)
                {
                    case MainMenuOption.Books:
                        ManageBooks();
                        break;

                    case MainMenuOption.Authors:
                        ManageAuthors();
                        break;

                    case MainMenuOption.Members:
                        ManageMembers();
                        break;

                    case MainMenuOption.Librarians:
                        ManageLibrarians();
                        break;

                    case MainMenuOption.Categories:
                        ManageCategories();
                        break;

                    case MainMenuOption.Publishers:
                        ManagePublishers();
                        break;

                    case MainMenuOption.BorrowBook:
                        BorrowBook();
                        break;

                    case MainMenuOption.ReturnBook:
                        _returnBook();
                        break;

                    case MainMenuOption.Exit:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n👋 Goodbye! Thanks for using the Library System.");
                        Console.ResetColor();
                        return;
                }
            }
        }

        static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        static void PrintLine()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }

        static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✅ {message}");
            Console.ResetColor();
            Pause();
        }

        // ================= BOOKS =================
        static Book ReadBook()
        {
            Book book = new Book();

            Console.Write("Title: ");
            book.Title = Console.ReadLine();

            Console.Write("ISBN: ");
            book.ISBN = Console.ReadLine();
            Console.Write("Published Year: ");
            book.PublishedYear = DateTime.Parse(Console.ReadLine());
            Console.Write("Page Count: ");
            book.PagesCount = int.Parse(Console.ReadLine());

            Console.Write("Language: ");
            book.Language = Console.ReadLine();

            Console.Write("Description: ");
            book.Description = Console.ReadLine();

            Console.Write("Category Id: ");
            book.CategoryId = int.Parse(Console.ReadLine());

            Console.Write("Publisher Id: ");
            book.PublisherId = int.Parse(Console.ReadLine());

            Console.Write("Total Copies: ");
            book.TotalCopies = int.Parse(Console.ReadLine());

            book.AvailableCopies = book.TotalCopies;

            return book;
        }
        static void BorrowBook()
        {
            Console.Clear();
            Console.Write("Book Id: ");
            int bookId = int.Parse(Console.ReadLine());

            Console.Write("Member Id: ");
            int memberId = int.Parse(Console.ReadLine());

            Console.Write("Librarian Id: ");
            int librarianId = int.Parse(Console.ReadLine());

            BorrowTransactionOperations.AddBorrowTransactionOperation(bookId, memberId, librarianId);

            SuccessMessage("Borrow Completed Successfully! 📚✅");
        }

        static void _returnBook()
        {
            Console.Write("Borrow Id: ");
            int id = int.Parse(Console.ReadLine());

            ReturnBook.CreatedReturnBook(id);

            SuccessMessage("Book Returned Successfully! 🔄✅");
        }
        static void ViewAllBooks()
        {
            var books = BookOperations.ReadAllBooks();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n================ Books ================\n");
            Console.ResetColor();

            Console.WriteLine("{0,-5} {1,-25} {2,-15} {3,-6} {4,-6} {5,-6} {6,-10} {7,-10} {8,-15} {9,-20}",
                "ID", "Title", "ISBN", "Year", "Pages", "Lang", "Total", "Avail", "CategoryId", "PublisherId");

            PrintLine();

            foreach (var book in books)
            {
                Console.WriteLine("{0,-5} {1,-25} {2,-15} {3,-6:yyyy} {4,-6} {5,-6} {6,-10} {7,-10} {8,-15} {9,-20}",
                    book.Id,
                    book.Title,
                    book.ISBN,
                    book.PublishedYear,
                    book.PagesCount,
                    book.Language,
                    book.TotalCopies,
                    book.AvailableCopies,
                    book.CategoryId,
                    book.PublisherId
                );

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Description: " + book.Description);
                Console.ResetColor();
                PrintLine();
            }

            Pause();
        }

        static void ManageBooks()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========== 📖 Books Menu ==========\n");
                Console.ResetColor();

                Console.WriteLine("[1] ➕ Add Book");
                Console.WriteLine("[2] ✏️ Update Book");
                Console.WriteLine("[3] 🗑️ Delete Book");
                Console.WriteLine("[4] 📚 View All Books");
                Console.WriteLine("[5] 🔍 Search Book");
                Console.WriteLine("[6] ↩️ Back");

                Console.Write("\nChoose: ");
                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        BookOperations.AddBook(ReadBook());
                        SuccessMessage("Book Added Successfully! 🎉");
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Enter Book Id: ");
                        int id = int.Parse(Console.ReadLine());
                        BookOperations.UpdateBook(ReadBook(), id);
                        SuccessMessage("Book Updated Successfully! ✨");
                        break;

                    case 3:
                        Console.Write("Enter Book Id: ");
                        BookOperations.DeleteBook(int.Parse(Console.ReadLine()));
                        SuccessMessage("Book Deleted Successfully! 🗑️");
                        break;

                    case 4:
                        Console.Clear();
                        ViewAllBooks();
                        break;

                    case 5:
                        Console.Clear();
                        SearchBook();
                        break;

                    case 6:
                        return;
                }
            }
        }

        static void SearchBook()
        {
            Console.Write("Enter Book Id: ");
            int id = int.Parse(Console.ReadLine());

            var book = BookOperations.SearchBook(id);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n📖 Book Info\n");
            Console.ResetColor();

            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"ISBN: {book.ISBN}");
            Console.WriteLine($"Language: {book.Language}");
            Console.WriteLine($"Description: {book.Description}");

            Pause();
        }

        // ================= AUTHORS =================
        static Author ReadAuthor()
        {
            Author author = new Author();

            Console.Write("Name: ");
            author.Name = Console.ReadLine();

            Console.Write("Nationality: ");
            author.Nationality = Console.ReadLine();

            Console.Write("Birth Date: ");
            author.BirthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Biography: ");
            author.Biography = Console.ReadLine();

            return author;
        }

        static void ManageAuthors()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========== 🖋️ Authors Menu ==========\n");
                Console.ResetColor();

                Console.WriteLine("[1] ➕ Add Author");
                Console.WriteLine("[2] ✏️ Update Author");
                Console.WriteLine("[3] 🗑️ Delete Author");
                Console.WriteLine("[4] 📚 View Authors");
                Console.WriteLine("[5] 🔍 Search Author");
                Console.WriteLine("[6] ↩️ Back");

                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        AuthorOperations.AddAuthor(ReadAuthor());
                        SuccessMessage("Author Added Successfully! 🎉");
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Author Id: ");
                        AuthorOperations.UpdateAuthor(ReadAuthor(), int.Parse(Console.ReadLine()));
                        SuccessMessage("Author Updated Successfully! ✨");
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Author Id: ");
                        AuthorOperations.DeleteAuthor(int.Parse(Console.ReadLine()));
                        SuccessMessage("Author Deleted Successfully! 🗑️");
                        break;

                    case 4:
                        Console.Clear();
                        ReadAllAuthors();
                        break;

                    case 5:
                        Console.Clear();
                        SearchAuthor();
                        break;

                    case 6:
                        return;
                }
            }
        }

        static void ReadAllAuthors()
        {
            var authors = AuthorOperations.ReadAllAuthors();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n================ Authors ================\n");
            Console.ResetColor();

            Console.WriteLine("{0,-5} {1,-25} {2,-15} {3,-20}", "ID", "Name", "BirthDate", "Nationality");
            PrintLine();

            foreach (var a in authors)
            {
                Console.WriteLine("{0,-5} {1,-25} {2,-15} {3,-20}",
                    a.Id,
                    a.Name,
                    a.BirthDate.ToShortDateString(),
                    a.Nationality);
            }

            Pause();
        }

        static void SearchAuthor()
        {
            Console.Write("Author Id: ");
            int id = int.Parse(Console.ReadLine());

            var author = AuthorOperations.SearchAuthor(id);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n🖋️ {author.Name} - {author.Nationality}");
            Console.ResetColor();

            Pause();
        }

        // ================= MEMBERS =================
        static void ManageMembers()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========== 👥 Members Menu ==========\n");
                Console.ResetColor();

                Console.WriteLine("[1] ➕ Add Member");
                Console.WriteLine("[2] ✏️ Update Member");
                Console.WriteLine("[3] 🗑️ Delete Member");
                Console.WriteLine("[4] 🔍 Search Member");
                Console.WriteLine("[5] 📚 Member Borrow History");
                Console.WriteLine("[6] ↩️ Back");

                Console.Write("\nChoose Option: ");
                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        MemberOperations.AddMember(ReadMember());
                        SuccessMessage("Member Added Successfully! 🎉");
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Enter Member Id: ");
                        int id = int.Parse(Console.ReadLine());
                        MemberOperations.UpdateMember(ReadMember(), id);
                        SuccessMessage("Member Updated Successfully! ✨");
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Enter Member Id: ");
                        MemberOperations.DeleteMember(int.Parse(Console.ReadLine()));
                        SuccessMessage("Member Deleted Successfully! 🗑️");
                        break;

                    case 4:
                        Console.Clear();
                        SearchMember();
                        break;

                    case 5:
                        Console.Clear();
                        AllBorrowTransactionOfMember();
                        break;

                    case 6:
                        return;
                }
            }
        }

        static Member ReadMember()
        {
            Member member = new Member();

            Console.Write("Name: ");
            member.Name = Console.ReadLine();

            Console.Write("Email: ");
            member.Email = Console.ReadLine();

            Console.Write("Phone: ");
            member.Phone = Console.ReadLine();

            Console.Write("Address: ");
            member.Address = Console.ReadLine();

            Console.Write("Join Date (yyyy-mm-dd): ");
            member.JoinDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Membership Active (true / false): ");
            member.MembershipStatus = bool.Parse(Console.ReadLine());

            return member;
        }

        static void SearchMember()
        {
            Console.Write("Enter Member Id: ");
            int id = int.Parse(Console.ReadLine());

            var member = MemberOperations.SearchMember(id);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n========== Member Info ==========\n");
            Console.ResetColor();

            Console.WriteLine($"Id: {member.Id}");
            Console.WriteLine($"Name: {member.Name}");
            Console.WriteLine($"Email: {member.Email}");
            Console.WriteLine($"Phone: {member.Phone}");
            Console.WriteLine($"Address: {member.Address}");
            Console.WriteLine($"Join Date: {member.JoinDate.ToShortDateString()}");
            Console.WriteLine($"Active: {member.MembershipStatus}");

            Pause();
        }

        static void AllBorrowTransactionOfMember()
        {
            Console.Write("Enter Member Id: ");
            int id = int.Parse(Console.ReadLine());

            var transactions = MemberOperations.AllBorrowTransactionOfMember(id);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n========= Borrow History =========\n");
            Console.ResetColor();

            Console.WriteLine("{0,-5} {1,-10} {2,-15} {3,-15}", "ID", "BookId", "BorrowDate", "ReturnDate");
            PrintLine();

            foreach (var t in transactions)
            {
                Console.WriteLine("{0,-5} {1,-10} {2,-15} {3,-15}",
                    t.Id,
                    t.BookId,
                    t.BorrowDate.ToShortDateString(),
                    t.ReturnDate?.ToShortDateString());
            }

            Pause();
        }

        // ================= LIBRARIANS =================
        static void ManageLibrarians()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========== 🧑‍💼 Librarians Menu ==========\n");
                Console.ResetColor();

                Console.WriteLine("[1] ➕ Add Librarian");
                Console.WriteLine("[2] ✏️ Update Librarian");
                Console.WriteLine("[3] 🗑️ Delete Librarian");
                Console.WriteLine("[4] 📚 View All Librarians");
                Console.WriteLine("[5] 🔍 Search Librarian");
                Console.WriteLine("[6] 📖 Librarian Borrow Transactions");
                Console.WriteLine("[7] ↩️ Back");

                Console.Write("\nChoose Option: ");
                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        LibrarianOperations.AddLibrarian(ReadLibrarian());
                        SuccessMessage("Librarian Added Successfully! 🎉");
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Enter Librarian Id: ");
                        int id = int.Parse(Console.ReadLine());
                        LibrarianOperations.UpdateLibrarian(ReadLibrarian(), id);
                        SuccessMessage("Librarian Updated Successfully! ✨");
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Enter Librarian Id: ");
                        LibrarianOperations.DeleteLibrarian(int.Parse(Console.ReadLine()));
                        SuccessMessage("Librarian Deleted Successfully! 🗑️");
                        break;

                    case 4:
                        Console.Clear();
                        ViewAllLibrarians();
                        break;

                    case 5:
                        Console.Clear();
                        SearchLibrarians();
                        break;

                    case 6:
                        Console.Clear();
                        ReadBorrowTransactionOfLibrarian();
                        break;

                    case 7:
                        return;
                }
            }
        }

        static Librarian ReadLibrarian()
        {
            Librarian librarian = new Librarian();

            Console.Write("Name: ");
            librarian.Name = Console.ReadLine();

            Console.Write("Email: ");
            librarian.Email = Console.ReadLine();

            Console.Write("Phone: ");
            librarian.Phone = Console.ReadLine();

            Console.Write("Role: ");
            librarian.Role = Console.ReadLine();

            return librarian;
        }

        static void ViewAllLibrarians()
        {
            var librarians = LibrarianOperations.ReadAllLibrarians();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n================ Librarians ================\n");
            Console.ResetColor();

            Console.WriteLine("{0,-5} {1,-25} {2,-25} {3,-15} {4,-15}", "ID", "Name", "Email", "Phone", "Role");
            PrintLine();

            foreach (var librarian in librarians)
            {
                Console.WriteLine("{0,-5} {1,-25} {2,-25} {3,-15} {4,-15}",
                    librarian.Id,
                    librarian.Name,
                    librarian.Email,
                    librarian.Phone,
                    librarian.Role);
            }

            Pause();
        }

        static void SearchLibrarians()
        {
            Console.Write("Enter Librarian Id: ");
            int id = int.Parse(Console.ReadLine());

            var librarian = LibrarianOperations.SearchLibrarian(id);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n========== Librarian Info ==========\n");
            Console.ResetColor();

            Console.WriteLine($"Id: {librarian.Id}");
            Console.WriteLine($"Name: {librarian.Name}");
            Console.WriteLine($"Email: {librarian.Email}");
            Console.WriteLine($"Phone: {librarian.Phone}");
            Console.WriteLine($"Role: {librarian.Role}");

            Pause();
        }

        static void ReadBorrowTransactionOfLibrarian()
        {
            Console.Write("Enter Librarian Id: ");
            int id = int.Parse(Console.ReadLine());

            var transactions = LibrarianOperations.ReadBorrowTransaction(id);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n====== Librarian Transactions ======\n");
            Console.ResetColor();

            Console.WriteLine("{0,-5} {1,-10} {2,-10} {3,-15}", "ID", "BookId", "MemberId", "BorrowDate");
            PrintLine();

            foreach (var t in transactions)
            {
                Console.WriteLine("{0,-5} {1,-10} {2,-10} {3,-15}",
                    t.Id,
                    t.BookId,
                    t.MemberId,
                    t.BorrowDate.ToShortDateString());
            }

            Pause();
        }

        // ================= CATEGORY =================
        static Category ReadCategory()
        {
            Category category = new Category();

            Console.Write("Name: ");
            category.CategoryName = Console.ReadLine();

            Console.Write("Description: ");
            category.Description = Console.ReadLine();

            return category;
        }
        static Publisher ReadPublisher()
        {
            Publisher publisher = new Publisher();

            Console.Write("Name: ");
            publisher.PublisherName = Console.ReadLine();

            Console.Write("Country: ");
            publisher.Country = Console.ReadLine();

            Console.Write("Established Year: ");
            publisher.EstablishedYear = DateTime.Parse(Console.ReadLine());

            Console.Write("Website: ");
            publisher.Website = Console.ReadLine();

            return publisher;
        }

        static void ManagePublishers()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========== 🏢 Publishers Menu ==========\n");
                Console.ResetColor();

                Console.WriteLine("[1] ➕ Add Publisher");
                Console.WriteLine("[2] ✏️ Update Publisher");
                Console.WriteLine("[3] 🗑️ Delete Publisher");
                Console.WriteLine("[4] 📚 View Publishers");
                Console.WriteLine("[5] ↩️ Back");

                Console.Write("\nChoose: ");
                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        PublisherOperation.AddPublisher(ReadPublisher());
                        SuccessMessage("Publisher Added Successfully! 🎉");
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Enter Publisher Id: ");
                        int id = int.Parse(Console.ReadLine());
                        PublisherOperation.UpdatePublisher(ReadPublisher(), id);
                        SuccessMessage("Publisher Updated Successfully! ✨");
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Enter Publisher Id: ");
                        PublisherOperation.DeletePublisher(int.Parse(Console.ReadLine()));
                        SuccessMessage("Publisher Deleted Successfully! 🗑️");
                        break;

                    case 4:
                        Console.Clear();
                        ViewAllPublishers();
                        break;

                    case 5:
                        return;
                }
            }
        }

        static void ViewAllPublishers()
        {
            var publishers = PublisherOperation.ReadAllPublishers();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n📚 Publishers List\n");
            Console.ResetColor();

            foreach (var p in publishers)
            {
                Console.WriteLine($"ID: {p.Id} | Name: {p.PublisherName} | Country: {p.Country} | Website: {p.Website}");
            }

            Pause();
        }

       

        static void ManageCategories()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========== 🗂️ Categories Menu ==========\n");
                Console.ResetColor();

                Console.WriteLine("[1] ➕ Add Category");
                Console.WriteLine("[2] ✏️ Update Category");
                Console.WriteLine("[3] 🗑️ Delete Category");
                Console.WriteLine("[4] 📚 View Categories");
                Console.WriteLine("[5] ↩️ Back");

                Console.Write("\nChoose: ");
                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        CategoryOperation.AddCategory(ReadCategory());
                        SuccessMessage("Category Added Successfully! 🎉");
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Enter Category Id: ");
                        int id = int.Parse(Console.ReadLine());
                        CategoryOperation.UpdateCategory(ReadCategory(), id);
                        SuccessMessage("Category Updated Successfully! ✨");
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Enter Category Id: ");
                        CategoryOperation.DeletCategory(int.Parse(Console.ReadLine()));
                        SuccessMessage("Category Deleted Successfully! 🗑️");
                        break;

                    case 4:
                        Console.Clear();
                        ViewAllCategories();
                        break;

                    case 5:
                        return;
                }
            }
        }

        static void ViewAllCategories()
        {
            var categories = CategoryOperation.ReadAllCategorys();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n📚 Categories List\n");
            Console.ResetColor();

            foreach (var c in categories)
            {
                Console.WriteLine($"ID: {c.Id} | Name: {c.CategoryName} | Description: {c.Description}");
            }

            Pause();
        }

    }
}
