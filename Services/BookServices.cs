using System;
using System.Collections.Generic;
using Project1_Edited.Entities;
using Project1_Edited.Intefaces;

namespace Project1_Edited.Services
{

    namespace Project1.Services
    {
        public class BookService : IBookService
        {
            private List<Book> RegisteredBooks = new List<Book>();

            public bool BookRegistration(string title, string author, string genre)
            {
               
                    if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(genre))
                    {
                        Console.WriteLine("Title, Author, or Genre must be filled");
                        return false;
                    }

                    Book newBook = new Book()
                    {
                        Title = title,
                        Author = author,
                        Genre = genre,
                    };

                    RegisteredBooks.Add(newBook);
                    Console.WriteLine("New book added to library");
                    return true;
            }

            public List<Book> GetBooks()
            {
                Console.WriteLine("List of books:");
                foreach (var book in RegisteredBooks)
                {
                    Console.WriteLine($"Book name: {book.Title}, Author: {book.Author}, Genre: {book.Genre}");
                }

                return RegisteredBooks;
            }

            public bool SearchBook(string title, string author, string genre)
            {
                bool found = false;
                foreach (var book in RegisteredBooks)
                {
                    if ((string.IsNullOrEmpty(title) || book.Title == title) &&
                        (string.IsNullOrEmpty(author) || book.Author == author) &&
                        (string.IsNullOrEmpty(genre) || book.Genre == genre))
                    {
                        Console.WriteLine($"Book found: {book.Title}, {book.Author}, {book.Genre}");
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Book not found");
                }

                return found;
            }

            public bool IssueBookToUser(string title, User user)
            {
                foreach (var book in RegisteredBooks)
                {
                    if (book.Title == title && book.IsAvailable)
                    {
                        book.IsAvailable = false;
                        book.Borrower = user;
                        book.DueDate = DateTime.Now.AddDays(5);
                        user.BorrowedBooks.Add(book);
                        Console.WriteLine($"Book '{title}' issued to {user.UserName}. Due Date: {book.DueDate}");
                        return true;
                    }
                }

                Console.WriteLine($"Book '{title}' is either not available or does not exist.");
                return false;
            }
            public void ViewBookStatus()
            {
                if (RegisteredBooks.Count == 0)
                {
                    Console.WriteLine("No books found in the library.");
                    return;
                }

                Console.WriteLine("Book Status:");
                foreach (var book in RegisteredBooks)
                {
                    string status = book.IsAvailable ? "Available" : $"Borrowed by {book.Borrower.UserName}, Due Date: {book.DueDate?.ToShortDateString()}";
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Status: {status}");
                }
            }
            public bool ReturnBook(string title, User user)
            {
                foreach (var book in RegisteredBooks)
                {
                    if (book.Title == title && book.Borrower == user)
                    {
                        book.IsAvailable = true;
                        book.Borrower = null;
                        book.DueDate = null;

                        user.BorrowedBooks.Remove(book);
                        Console.WriteLine($"Book '{title}' has been returned by {user.UserName}.");
                        return true;
                    }
                }
                Console.WriteLine($"Book '{title}' was not found or was not borrowed by {user.UserName}.");
                return false;
            }
            public List<Book> SearchBookByFirstLetter(char firstLetter)
            {
                List<Book> matchingBooks = new List<Book>();

                foreach (var book in RegisteredBooks)
                {
                    if (book.Title[0] == char.ToUpper(firstLetter))
                    {
                        matchingBooks.Add(book);
                        Console.WriteLine($"Book: {book.Title}, Author: {book.Author}, Genre: {book.Genre}");
                    }
                }
                if (matchingBooks.Count == 0)
                {
                    Console.WriteLine($"No books found starting with '{firstLetter}'");
                }

                return matchingBooks;
            }

        }
    }
}