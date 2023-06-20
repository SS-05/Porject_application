using Microsoft.VisualBasic;
using Project_application.Models;
using Project_application.Screens;
using System.Net.Http.Headers;

namespace Project_application
{
    public class Naukri
    {
        static void Main(string[] args)
        {
            AccountUser account = new AccountUser();
            Job_posting jobs = new Job_posting();
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Welcome to Naukri.com");
                Console.WriteLine("Select an option:\n1) Sign up\n2) Login\n3) Update Password\n4) Update Username\n5) Delete Account\n6)Create Job\n7)Delete Job\n8)Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
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
                            Console.WriteLine("Enter experience (numeric value):");
                            int experience = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter your phone number:");
                            long phone_number = long.Parse(Console.ReadLine());

                            //display the entered information
                            Console.WriteLine("\nEntered Information:");
                            Console.WriteLine("Name: " + username);
                            Console.WriteLine("User Type: " + user_type);
                            Console.WriteLine("User ID: " + user_id);
                            Console.WriteLine("Skillset: " + string.Join(", ", skillset));
                            Console.WriteLine("Experience: " + experience);
                            Console.WriteLine("Phone Number: " + phone_number);
                            Console.WriteLine("\nConfirm registration (Y/N):");
                            string confirmation = Console.ReadLine();

                            if (confirmation.ToUpper() == "Y")
                            {
                                account.signup(username, password, user_type, user_id, skillset, experience, phone_number);
                            }
                            else
                            {
                                Console.WriteLine("Account creation cancelled:(");
                            }
                        }
                        break;

                    case 2:
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
                                    Console.WriteLine("CAPTCHA verification successful. Account created or logged in!");
                                    account.Login(phone_number, password);
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
                        break;
                        /* case 3:
                             {
                                 Console.WriteLine("Enter your Phone number:");
                                 long phone_number = long.Parse(Console.ReadLine()); Console.WriteLine("Enter your new password:");
                                 string newPassword = Console.ReadLine();
                                 account.UpdatePassword(phone_number,newPassword);
                             }
                             break;

                         case 4:
                             {
                                 Console.WriteLine("Enter your current username:");
                                 string currentUsername = Console.ReadLine();
                                 Console.WriteLine("Enter your new username:");
                                 string newUsername = Console.ReadLine();
                                 Console.WriteLine("Enter your password:");
                                 string password = Console.ReadLine();
                                 account.UpdateUsername(currentUsername, newUsername, password);
                             }
                             break;

                         case 5:
                             {
                                 Console.WriteLine("Enter your username:");
                                 string username = Console.ReadLine();
                                 Console.WriteLine("Enter your password:");
                                 string password = Console.ReadLine();
                                 account.DeleteAccount(username, password);
                             }
                             break;
                         case 6:
                             { 
                                 Console.WriteLine("Enter the Company name as per registration norms");
                                 string company_name = Console.ReadLine();
                                 Console.WriteLine("Enter the Years of Experience needed");
                                 int yoe=Convert.ToInt32(Console.ReadLine());
                                 Console.WriteLine("Enter the job description");
                                 string j_type = Console.ReadLine();
                                 Console.WriteLine("Enter the Job Locations");
                                 string location= Console.ReadLine();
                                 Console.WriteLine("Enter the nature of the job(Hybrid/Remote/Office in)");
                                 string shift = Console.ReadLine(); ;
                                 Console.WriteLine("Enter the required skill set to apply for the job");
                                 string skillset = Console.ReadLine();
                                 jobs.CreateJobs(company_name, yoe, j_type, location, shift, skillset);

                             }
                             break;
                             case 7:
                             {
                                 Console.WriteLine("Enter the Company name as per registration norms");
                                 string company_name = Console.ReadLine();
                                 Console.WriteLine("Enter the job description");
                                 string j_type = Console.ReadLine();
                                 jobs.DeleteJob(company_name, j_type);



                             }
                             break;

                         case 8:
                             {
                                 flag = false;
                                 Console.WriteLine("Exiting Naukri.com");
                             }
                             break;

                         default:
                             {
                                 Console.WriteLine("Invalid option! Please try again.");
                             }
                             break;
                     }
                 }*/
                }
            }
        }

        /*private static string GenerateRandomString(int v)
        {
            throw new NotImplementedException();
        }*/
    }
}
