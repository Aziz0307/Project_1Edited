using System.Collections.Generic;
using Project1_Edited.Entities;

namespace Project1_Edited.Intefaces
{
    public interface IBookService
    {
        public bool BookRegistration(string title, string author, string genre);
        List<Book> GetBooks();
        bool SearchBook(string title, string author, string genre);
        bool IssueBookToUser(string title, User user);
        public void ViewBookStatus();
        public bool ReturnBook(string title, User user);

    }
    

}