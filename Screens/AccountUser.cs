using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_application.Models;

namespace Project_application.Screens
{
    public class AccountUser
    {
        List<User> users = new List<User>();

        public void signup(string username, string password, string user_type, int user_id, List<string> skillset, int experience, long phone_number)
        {
            if (FindUser(user_id) == null)
            {
                users.Add(new User(username, password, user_type, user_id, skillset, experience, phone_number));
                Console.WriteLine("Account created successfully!");
            }
            else
            {
                Console.WriteLine("User already exists!");
            }
        }
        private User? FindUser(long user_id, string password)
        {
            foreach (User user in users)
            {
                if (user.user_id == user_id && user.password == password)
                {
                    return user;
                }
            }
            return null;
        }
        private User? FindUser(long user_id)
        {
            foreach (User user in users)
            {
                if (user.user_id == user_id)
                {
                    return user;
                }
            }
            return null;
        }
        public void Login(long user_id, string password)
        {
            User? user = FindUser(user_id, password);
            if (user != null)
            {
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.WriteLine("Invalid username or password! Please try again.");
            }
        }
      
        public void UpdatePassword(long user_id, string newPassword)
        {
            User user = FindUser(user_id);
            if (user != null)
            {
                user.password = newPassword;
                Console.WriteLine("Password updated successfully");
            }
            else
            {
                Console.WriteLine("User not found! Please check the username.");
            }
        }

        public void UpdateUsername(long user_id, string newUsername, string password)
        {
            User? user = FindUser(user_id, password);
            if (user != null)
            {
                user.username = newUsername;
                Console.WriteLine("Username updated successfully");
            }
            else
            {
                Console.WriteLine("Invalid username or password! Please try again.");
            }
        }

        public void DeleteAccount(long user_id, string password)
        {
            User? user = FindUser(user_id, password);
            if (user != null)
            {
                users.Remove(user);
                Console.WriteLine("Account deleted successfully");
            }
            else
            {
                Console.WriteLine("Invalid username or password! Please try again.");
            }
        }
        public void ReadUsers()
        {
            Console.WriteLine("* UserName                    phonenumber        skillset");
            foreach(User u in users)
            {
                Console.WriteLine("* "+u.username.Substring(0,20)+ "        "+u.phone_number+"         "+ u.skillset);
                
            }
        }
      
    }
}
