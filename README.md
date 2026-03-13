# 📚 Library Management System

A **Console-Based Library Management System** built with **C#**, **.NET**, and **Entity Framework Core**.
The system allows librarians to manage books, members, authors, publishers, and borrowing operations efficiently.

---

## 🚀 Features

### 📖 Book Management

* Add new books
* Update book details
* Delete books
* View all books
* Search for a specific book

### 🖋️ Author Management

* Add authors
* Update author information
* Delete authors
* View all authors

### 👥 Member Management

* Add new members
* Update member information
* Delete members
* Search members
* View member borrowing history

### 🧑‍💼 Librarian Management

* Add librarians
* Update librarian information
* Delete librarians
* View librarian transactions

### 🗂️ Category Management

* Add categories
* Update categories
* Delete categories
* View all categories

### 🏢 Publisher Management

* Add publishers
* Update publishers
* Delete publishers
* View all publishers

### 📚 Borrowing System

* Borrow books
* Return books
* Automatically update available copies

### ⏰ Fine System

* Automatically calculates late return fines

### ⭐ Review System

* Members can review books
* Each member can review a book only once

### 📌 Reservation System

* Members can reserve books
* Reservations are handled automatically when books are returned

---

## 🏗️ Project Architecture

The project follows a **layered structure**:

```
LibraryManagementSystem
│
├── Models
│   ├── Author
│   ├── Book
│   ├── Member
│   ├── Librarian
│   ├── Category
│   ├── Publisher
│   ├── BorrowTransaction
│   ├── Reservation
│   ├── Review
│   └── Fine
│
├── Operations
│   ├── AuthorOperations
│   ├── BookOperations
│   ├── MemberOperations
│   ├── LibrarianOperations
│   ├── CategoryOperation
│   ├── PublisherOperation
│   ├── BorrowTransactionOperations
│   ├── ReviewOperations
│   └── FineOperation
│
├── Menu
│   └── MainMenu
│
├── AppDbContext
└── Program
```

---

## 🛠️ Technologies Used

* **C#**
* **.NET**
* **Entity Framework Core**
* **LINQ**
* **SQL Server**
* **Console UI**

---

## 🔄 System Workflow

1. Librarian logs into the system.
2. Books, authors, and categories can be managed.
3. Members can borrow books if:

   * Membership is active
   * Copies are available
4. When returning a book:

   * The system updates available copies.
   * Checks if the book is returned late.
   * Automatically generates a fine if needed.
5. Pending reservations are processed automatically.

---

## 📊 UML Diagram

The project includes a **Class Diagram** representing the system entities and relationships.

Main Entities:

* Book
* Author
* Member
* Librarian
* BorrowTransaction
* Reservation
* Review
* Fine
* Category
* Publisher

---

## ▶️ How to Run

1. Clone the repository:

```
git clone https://github.com/your-username/Library-Management-System.git
```

2. Open the project in **Visual Studio**

3. Restore packages

4. Run the project

---

## 👨‍💻 Author

**Youssef Sameh**

Student at
Faculty of Computers and Information
Mansoura University

---

## ⭐ Future Improvements

* Add **GUI interface**
* Add **Authentication system**
* Add **Notifications for reservations**
* Build **Web API version**
* Create **Web or Mobile App**

---

## 📜 License

This project is for **educational purposes**.
