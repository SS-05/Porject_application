using Microsoft.VisualBasic;
using Project_application.Models;
using Project_application.Screens;
using System.Net.Http.Headers;

namespace Project_application
yyy
{
    public class Naukri
    {
        static void Main(string[] args)
        {
            AccountUser account = new AccountUser();
            Job_posting jobs=new Job_posting();
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Welcome to Naukri.com");
                Console.WriteLine("Select an option:\n1) Create Account\n2) Login\n3) Update Password\n4) Update Username\n5) Delete Account\n6)Create Job\n7)Delete Job\n8)Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter your username:");
                            string username = Console.ReadLine();
                            Console.WriteLine("Enter your password:");
                            string password = Console.ReadLine();
                            account.CreateAccount(username, password);
                        }
                        break;

                    case 2:
                        {
                            Console.WriteLine("Enter your username:");
                            string username = Console.ReadLine();
                            Console.WriteLine("Enter your password:");
                            string password = Console.ReadLine();
                            account.Login(username, password);
                        }
                        break;

                    case 3:
                        {
                            Console.WriteLine("Enter your username:");
                            string username = Console.ReadLine();
                            Console.WriteLine("Enter your new password:");
                            string newPassword = Console.ReadLine();
                            account.UpdatePassword(username,newPassword);
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
            }
        }
    }
}