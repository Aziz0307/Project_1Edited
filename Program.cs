using System;
using System.Reflection;
using Project1_Edited.Entities;
using Project1_Edited.Entities.Project1;
using Project1_Edited.Services;
using Project1_Edited.Services.Project1.Services;

namespace Project1_Edited
{
    class Program
    {
        static void Main(string[] args)
        {
            UserServices userService = new UserServices();
            BookService bookService = new BookService();
            bookService.BookRegistration("Shohnoma","Firdausi","Tarikh");
            bookService.BookRegistration("Tojikon","Bobojon Ghafurov","Tarikh");
            bookService.BookRegistration("Masnavi va manavi","Jaloliddini Rumi","Tarbiyavi");
            bookService.BookRegistration("1984","George Orwell","Political Fiction");
            bookService.BookRegistration("Pride and Prejudice","Jane Austen","Historical");
            bookService.BookRegistration("The Great Gatsby","F. Scott Fitzgerald","Fiction");

            userService.RegisterAdmin("Admin", "admin");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Authorization ===");
                Console.WriteLine("1. Registration");
                Console.WriteLine("2. Log in");
                // if (userService.CurrentAdmin != null && 
                //     userService.CurrentAdmin.UserRole == Role.Admin)
                // {
                    Console.WriteLine("3. List all users");
                    Console.WriteLine("4. Adding new books to library");
                    Console.WriteLine("5. List all books");
                    Console.WriteLine("6. Search for books");
                    Console.WriteLine("7. View status of books");
                // } 
                Console.WriteLine("8. Issue book");
                Console.WriteLine("9. Returning book");
                Console.WriteLine("10. Deleting user");
                Console.WriteLine("11. Log out");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Wrong input. Try again.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Please input username: ");
                        string regUsername = Console.ReadLine();
                        Console.Write("Please input password: ");
                        string regPassword = Console.ReadLine();
                        if (userService.Registration(regUsername, regPassword))
                        {
                            Console.WriteLine("You have successfully registered.");
                        }

                        break;
                    
                    case 2:
                        Console.Write("Please input username: ");
                        string loginUsername = Console.ReadLine();
                        Console.Write("Please login password: ");
                        string loginPassword = Console.ReadLine();

                        if (userService.Login(loginUsername, loginPassword))
                        {
                            if (userService.CurrentUser != null && userService.CurrentUser.UserRole == Role.Admin)
                            {
                                Console.WriteLine($"Welcome, admin {loginUsername}!");
                            }
                            else if (userService.CurrentUser != null)
                            {
                                Console.WriteLine($"Welcome, {loginUsername}!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong password or username.");
                        }
                        break;
                    case 3:
                        if (userService.CurrentAdmin != null && userService.CurrentAdmin.UserRole == Role.Admin)
                        {
                            userService.GetUsers();
                        }
                        else
                        {
                            Console.WriteLine("Only admins can view all users.");
                        }

                        break;
                        case 4:
                        if (userService.CurrentAdmin != null && userService.CurrentAdmin.UserRole == Role.Admin)
                        {
                            Console.Write("Please input title: ");
                            string addTitleName = Console.ReadLine();
                            Console.Write("Please input author: ");
                            string addAuthorName = Console.ReadLine();
                            Console.Write("Please input genre: ");
                            string addGenreName = Console.ReadLine();
                            if (bookService.BookRegistration(addTitleName, addAuthorName, addGenreName))
                            {
                                Console.WriteLine("You have successfully added books.");
                            }
                            else
                            {
                                Console.WriteLine("Only admins can add new books.");
                            }
                        }

                        break;
                        case 5:
                        if (userService.CurrentAdmin != null && userService.CurrentAdmin.UserRole == Role.Admin)
                        {
                            bookService.GetBooks();
                        }
                        else
                        {
                            Console.WriteLine("Only admins can view all books.");
                        }
                            break;
                        case 6:
                            
                                Console.Write("Please input title: ");
                                string title = Console.ReadLine();
                                Console.Write("Please input author: ");
                                string author = Console.ReadLine();
                                Console.Write("Please input genre: ");
                                string genre = Console.ReadLine();
                                bookService.SearchBook(title, author, genre);
                            
                            break;
                    case 7:
                        // if (userService.CurrentAdmin != null && userService.CurrentAdmin.UserRole == Role.Admin)
                        // {
                            bookService.ViewBookStatus();
                        // }
                        // else
                        // {
                        //     Console.WriteLine("Onlu admin can see the status of books.");
                        // }
                        break;
                    
                    case 8:
                        if (userService.CurrentUser != null)
                        {
                        Console.Write("Please input title of the book: "); 
                        string title1 = Console.ReadLine();
                        bookService.IssueBookToUser(title1, userService.CurrentUser);
                        
                        }
                        else
                        {
                            Console.WriteLine("Only logged user can borrow books.");
                        }
                        break;
                    case 9:
                        if (userService.CurrentUser != null)
                        {
                            Console.Write("Please input title of the book: "); 
                            string title2 = Console.ReadLine();
                            bookService.ReturnBook(title2,userService.CurrentUser);
                        }
                        else
                        {
                            Console.WriteLine("Only logged user can borrow books.");
                        }
                        break;
                    case 10:
                    
                        Console.Write("Please input username: ");
                        string username1 = Console.ReadLine();
                        Console.Write("Please input password: ");
                        string password1 = Console.ReadLine();
                        userService.DeleteUser( username1, password1);
                        
                    
                        break;
                    case 11:
                        userService.Logout();
                        Console.WriteLine("Thank you for using this application.!");
                        break;
                    case 12:
                        Console.Write("Thank you for using this application.!");
                        return;
                    default:
                        Console.WriteLine("Wrong choice. Try again.");
                        break;
                }
                        Console.WriteLine("Please press any key to continue...");
                        Console.ReadKey();
            }
        }
    }
}
