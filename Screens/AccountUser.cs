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
        static public List<User> users = new List<User>();

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
        public  void dispAppliedJobs(List<Job> jobs)
        {
            if(jobs != null && jobs.Count > 0)
            {
                foreach (Job item in jobs)

                {
                    Console.WriteLine("Company name:{0}", item.company_name);
                    Console.WriteLine("Min years of expereince neeeded {0}", item.yoe);
                    Console.WriteLine("The type of job is {0}", item.job_type);

                }
            }
            else
            {
                Console.WriteLine("No job vacancy at the present. Check sometimes later");
            }
           
           /* if (new AccountUser().FindUser(id) != null)
            {
                foreach (Job item in (new AccountUser().FindUser(id).applidJobs))

                {
                    Console.WriteLine("Company name:{0}", item.company_name);
                    Console.WriteLine("Min years of expereince neeeded {0}", item.yoe);
                    Console.WriteLine("The type of job is {0}", item.job_type);

                }
            }
            else
            {
                Console.WriteLine("No job vacancy at the present. Check sometimes later");
            }*/
           
        }
        public User? FindUser(long phoneNumber, string password)
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

        public User? FindUser(long phoneNumber)
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

        public string GetUserType(long phoneNumber)
        {
            /*List<User> registeredUsers = new List<User>();*/
            User user = users.Find(u => u.phone_number == phoneNumber);
           

            if (user != null)
            {
                return user.user_type;
            }

            return string.Empty;
        }
        public void DisplayCurrentUser()
        {
            foreach(var user in users)
            {
                Console.WriteLine(user.username);
                Console.WriteLine(user.password);
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
        public void WithdrawJobs(long id)
        {
            User user = FindUser(id);
            Console.WriteLine("The applied job list(s) is as follows:");
            if (user != null && user.applidJobs != null && user.applidJobs.Count> 0) {

                foreach (var item in user.applidJobs)
                {
                    Console.WriteLine(item.company_name+"  "+item.job_type);
                }
                Console.WriteLine("Enter Id to withdraw");
                int jid = int.Parse(Console.ReadLine());
                Job job = user.applidJobs.Find(u => u.Id == jid);

                if (job != null)
                {
                    user.applidJobs.Remove(job);
                }
                else
                {
                    Console.WriteLine("No jobs present to withdraw");
                }
            }
            else
            {
                Console.WriteLine("You havent applied for any job");
            }
           
            

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
