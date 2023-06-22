using Project_application.Models;
using Project_application.Screens;
using System;
using System.Collections.Generic;
using Project_application.Models;
using Project_application.Screens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_application.Services
{
    public class AuthenticationServices 
    {
        AccountUser account = new AccountUser();
        Company? comp = null;
        bool flag = true;
        User curUsr = null;
        public void Login()
        {
            {
                Console.WriteLine("Enter your Phone number:");
                long phone_number = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();


                // Check if the username and password are valid
                if (account.ValidateCredentials(phone_number, password))
                {
                    string captcha = account.GenerateRandomString(6);

                    Console.WriteLine("Please enter the following CAPTCHA: " + captcha);
                    string userInput = Console.ReadLine();
                    if (userInput == captcha)
                    {
                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine("CAPTCHA verification successful.Logged in successfully!");
                        Console.WriteLine("*****************************************************************************");
                        account.Login(phone_number, password);
                        curUsr = account.FindUser(phone_number);
                        string userType = account.GetUserType(phone_number);

                        if (userType.ToUpper() == "USER")
                        {
                            UserServices userServices = new UserServices();
                            userServices.HandleUserLoggedIn();
                        }
                        else if (userType.ToUpper() == "COMPANY")
                        {
                            CompanyServices companyServices = new CompanyServices();
                            companyServices.HandleCompanyServices();
                        }
                        else
                        {
                            Console.WriteLine("CAPTCHA verification failed. Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account does not exist!");
                    }
                }
            }
        } 
    public void Signup()
        {
            int? experience = null;
            Console.WriteLine("Enter name:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter user_type (User/Company):");
            string user_type = Console.ReadLine();
            Console.WriteLine("Enter user ID (numeric value):");
            int user_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter skillset (comma-separated values):");
            string skillsetInput = Console.ReadLine();
            List<string> skillset = skillsetInput.Split(',').ToList();
            if (user_type.ToUpper() == "USER")
            {
                Console.WriteLine("Enter experience (numeric value):");

                experience = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter your phone number:");
            long phone_number = long.Parse(Console.ReadLine());

            //display the entered information
            Console.WriteLine("****************************************************");
            Console.WriteLine("\nEntered Information:");
            Console.WriteLine("Name: " + username);
            Console.WriteLine("User Type: " + user_type);
            Console.WriteLine("User ID: " + user_id);
            Console.WriteLine("Skillset: " + string.Join(", ", skillset));
            if (user_type.ToUpper() == "USER" && experience != null)
            {
                Console.WriteLine("Experience: " + experience);
            }
            Console.WriteLine("Phone Number: " + phone_number);
            Console.WriteLine("****************************************************");

            Console.WriteLine("\nConfirm registration (Y/N):");
            string confirmation = Console.ReadLine();

            if (confirmation.ToUpper() == "Y")
            {
                curUsr = new User(username, password, user_type, user_id, skillset, experience, phone_number, null, null, null);
                account.signup(username, password, user_type, user_id, skillset, experience, phone_number);
                comp = new Company(account.FindUser(phone_number, password));
            }
            else
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Account creation cancelled:(");
                Console.WriteLine("-----------------------------------");

            }
        }

    }
}






