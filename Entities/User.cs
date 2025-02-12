using System;
using System.Collections.Generic;

namespace Project1_Edited.Entities
{

        public class User
        {
            public Guid Id { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public Role UserRole { get; set; }
            public List<Book> BorrowedBooks { get; set; }

            public User()
            {
                Id = Guid.NewGuid();
                UserName = string.Empty;
                Password = string.Empty;
                Email = string.Empty;
                Phone = string.Empty;
                UserRole = Role.Reader;
                BorrowedBooks = new List<Book>();
            }
        }

        public enum Role
        {
            Admin,
            Reader
        }
    }

    