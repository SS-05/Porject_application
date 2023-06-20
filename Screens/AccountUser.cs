using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
                users.Add(new User(username, password, user_type, user_id, skillset, experience, phone_number,null,null,null));
                Console.WriteLine("Account created successfully!");
            }
            else
            {
                Console.WriteLine("User already exists!");
            }
        }
        private User? FindUser(long phoneNumber, string password)
        {
            foreach (User user in users)
            {
                if (user.phone_number == phoneNumber && user.password == password)
                {
                    return user;
                }
            }
            return null;
        }

        private User? FindUser(long phoneNumber)
        {
            foreach (User user in users)
            {
                if (user.phone_number == phoneNumber)
                {
                    return user;
                }
            }
            return null;
        }
        public void Login(long phone_number, string password)
        {
            User? user = FindUser(phone_number);
            if (user != null)
            {
                if (user.password == password)
                {
                    Console.WriteLine("Login successful");
                }
                else
                {
                    Console.WriteLine("Incorrect password! Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Account does not exist!");
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
        public bool ValidateCredentials(long phone_number, string password)
        {
            User user = FindUser(phone_number);
            if (user != null && user.password == password)
            {
                return true;
            }
            return false;
        }
        public string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
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
