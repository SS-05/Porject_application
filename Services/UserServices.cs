using Project_application.Models;
using Project_application.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project_application.Services
{
    public class UserServices
    {
        AccountUser account = new AccountUser();
        Company? comp = null;
        /*bool flag = true;*/
        User curUsr = null;
        public void HandleUserLoggedIn()
        {
            bool userLoggedIn = true;

            while (userLoggedIn)
            {
                Console.WriteLine("///////////////////////////////////////////////USER MENU////////////////////////////////////////////////////");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1) Update Username\n2) Update Password\n3) Delete Account\n4)Apply Job\n5)View Applied Job(s)\n6)Withdraw Application\n7) Display Users\n8)Logout");
                Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");

                int userOption = Convert.ToInt32(Console.ReadLine());

                switch (userOption)

                {

                    case 1:
                        {
                            /*Console.ForegroundColor = ConsoleColor.Red;*/
                            Console.Write("Enter the Phonenumber");
                            long p_number = long.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the new username");
                            string newusername = Console.ReadLine();
                            Console.WriteLine("Enter the password");
                            string pword = Console.ReadLine();
                            account.UpdateUsername(p_number, newusername, pword);
                        }
                        break;

                    case 2:
                        {

                            Console.Write("Enter the Phonenumber");
                            long pnumber = long.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the new password");
                            string newpassword = Console.ReadLine();
                            account.UpdatePassword(pnumber, newpassword);
                        }

                        break;

                    case 3:

                        {
                            Console.Write("Enter the Phonenumber");
                            long phone_num = long.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the password");
                            string newpassword = Console.ReadLine();
                            account.DeleteAccount(phone_num, newpassword);
                        }

                        break;

                    case 4:

                        {
                            Console.WriteLine("The Companies that has job vacancies are:");
                            //apply the jobs show list of comp with list of jobs
                            comp?.showallcpompjobstoApply();
                        }

                        break;

                    case 5:
                        {
                            account.dispAppliedJobs(curUsr.applidJobs);

                        }

                        break;

                    case 6:
                        {
                            Console.WriteLine(curUsr.phone_number);
                            account.WithdrawJobs(curUsr.phone_number);
                        }
                        break;

                    case 7:
                        {
                            account.DisplayCurrentUser();
                        }
                        break;

                    case 8:
                        {
                            userLoggedIn = false;
                            Console.WriteLine("Logout successful");

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
