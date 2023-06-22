using Microsoft.VisualBasic;
using Project_application.Models;
using Project_application.Screens;
using Project_application.Services;
using System.Net.Http.Headers;

namespace Project_application
{
    public class Naukri : AuthenticationServices
    {
        static void Main(string[] args)
        {
            bool flag = true;
            Naukri authenticationServices = new Naukri();


            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("*********************************");
                Console.WriteLine("***** Welcome to Naukri.com *****");
                Console.WriteLine("*********************************");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("SELECT AN OPTION:\n1) Sign up\n2) Login");
                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)

                {
                    default:
                        {
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine("Invalid option! Please try again.");
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

                        }
                        break;
                    case 1:
                        {
                            authenticationServices.Signup();
                        }
                        break;

                    case 2:
                        {
                            authenticationServices.Login();
                        }
                        break;


                }

            }
        }
    }
}

