using System;
using System.Collections.Generic;
using Project1_Edited.Entities;
using Project1_Edited.Entities.Project1;

namespace Project1_Edited.Services
{
    public class UserServices
    {
        private List<User> RegisteredUsers = new List<User>();
        public User CurrentUser { get; set; }
        public Admin CurrentAdmin { get; set; }
        public bool RegisterAdmin(string username, string password)
        {
            foreach (var user in RegisteredUsers)
            {
                if (user.UserName == username)
                {
                    Console.WriteLine("Username already taken");
                    return false;
                }
            }

            Admin newAdmin = new Admin()
            {
                UserName = username,
                Password = password
            };

            RegisteredUsers.Add(newAdmin);
            Console.WriteLine("New admin registered successfully");
            return true;
        }


        public bool Registration(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Username or password must be filled");
                return false;
            }

            foreach (var user in RegisteredUsers)
            {
                if (user.UserName == username)
                {
                    Console.WriteLine("Username already taken");
                    return false;
                }
            }

            User newUser = new User()
            {
                UserName = username,
                Password = password,
            };

            RegisteredUsers.Add(newUser);
            Console.WriteLine("New user created");
            return true;
        }

        public bool Login(string username, string password)
        {
            foreach (var user in RegisteredUsers)
            {
                if (user.UserName == username && user.Password == password)
                {
                    if (user.UserRole == Role.Admin)
                    {
                        CurrentAdmin = (Admin)user;
                        Console.WriteLine($"Admin {user.UserName} logged in.");
                    }
                    else
                    {
                        CurrentUser = user;
                        Console.WriteLine($"User {user.UserName} logged in.");
                    }
                    return true;
                }
            }
            Console.WriteLine("Invalid credentials");
            return false;
        }


        public void Logout()
        {
            if (CurrentAdmin != null)
            {
                Console.WriteLine($"Admin {CurrentAdmin.UserName} logged out.");
                CurrentAdmin = null;
            }
            else if (CurrentUser != null)
            {
                Console.WriteLine($"User {CurrentUser.UserName} logged out.");
                CurrentUser = null;
            }
        }
    

        public User GetUserByUsername(string username)
        {
            foreach (var user in RegisteredUsers)
            {
                if (user.UserName == username)
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> GetUsers()
        {
            Console.WriteLine("List of users:");
            foreach (var user in RegisteredUsers)
            {
                Console.WriteLine($"User name: {user.UserName}, Role: {user.UserRole}");
            }

            return RegisteredUsers;
        }

        public bool DeleteUser(string username, string password)
        {
            for (int i = 0; i < RegisteredUsers.Count; i++)
            {
                if (RegisteredUsers[i].UserName == username && RegisteredUsers[i].Password == password)
                {
                    RegisteredUsers.RemoveAt(i);
                    Console.WriteLine($"User {username} deleted");
                    return true;
                }
            }
            Console.WriteLine($"User {username} not found");
            return false;
        }
    }
}

    