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
            Company? comp = null ;
            /*Job_posting jobs = new Job_posting();*/
            bool flag = true;
            User curUsr= null ;

            while (flag)
            {
                Console.WriteLine("Welcome to Naukri.com");
                Console.WriteLine("Select an option:\n1) Sign up\n2) Login");
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
                                curUsr = new User(username, password, user_type, user_id, skillset, experience, phone_number,null,null,null);
                                account.signup(username, password, user_type, user_id, skillset, experience, phone_number);
                                comp = new  Company(account.FindUser(phone_number,password));
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
                                    curUsr = account.FindUser(phone_number);
                                    string userType = account.GetUserType(phone_number);
                                    //userType.ToUpper();
                                    Console.WriteLine(userType.ToUpper());

                                    if (userType.ToUpper() == "USER")
                                    {
                                        bool userLoggedIn = true;

                                        while (userLoggedIn)
                                        {
                                            Console.WriteLine("Select an option:");
                                            Console.WriteLine("1) Update Username\n2) Update Password\n3) Delete Account\n4)Apply Job\n5)View Applied Job(s)\n6)Withdraw Application\n7) Display Users\n8)Logout");
                                            int userOption = Convert.ToInt32(Console.ReadLine());

                                            switch (userOption)

                                            {

                                                case 1:

                                                    Console.Write("Enter the Phonenumber");

                                                    long p_number = long.Parse(Console.ReadLine());

                                                    Console.WriteLine("Enter the new username");

                                                    string newusername = Console.ReadLine();

                                                    Console.WriteLine("Enter the password");

                                                    string pword = Console.ReadLine();

                                                    account.UpdateUsername(p_number, newusername, pword);

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
                                                        //AccountUser.dispAppliedJobs()
                                                        //comp?.displayJObs();
                                                        comp?.showallcpompjobstoApply();

                                                    }

                                                    break;

                                                case 5:

                                                    {

                                                        //Console.Write("Enter the Phonenumber");

                                                        //long phonenumber = long.Parse(Console.ReadLine());

                                                        account.dispAppliedJobs(curUsr.applidJobs);
                                                        //curUsr = account.FindUser(phone_number);

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
                                    else if (userType.ToUpper() == "COMPANY")
                                    {
                                        bool companyLoggedIn = true;

                                        while (companyLoggedIn)
                                        {
                                            Console.WriteLine("Select an option:");
                                            Console.WriteLine("1) Create Job\n2) Delete Job\n3) Modify Account\n4) Logout");
                                            int companyOption = Convert.ToInt32(Console.ReadLine());

                                            switch (companyOption)
                                            {
                                                case 1:
                                                    {
                                                        Console.WriteLine("Creating a job...");
                                                        Console.WriteLine("Enter Company name:");
                                                        string cpname = Console.ReadLine();
                                                        Console.WriteLine("Enter Years of Experience");
                                                        int yoe = int.Parse(Console.ReadLine());
                                                        Console.WriteLine("Enter JobType");
                                                        string jbtype = Console.ReadLine();
                                                        Console.WriteLine("Enter Location");
                                                        string location = Console.ReadLine();
                                                        Console.WriteLine("Enter Shift");
                                                        string shift = Console.ReadLine();
                                                        Console.WriteLine("Enter SkillType");
                                                        string skilltype = Console.ReadLine();
                                                        int ctJ = (comp.user.createdJobs != null) ? comp.user.createdJobs.Count + 1 : 0;
                                                        comp.createJob(new Job(ctJ, cpname, yoe, jbtype, location, shift, skilltype));
                                                    }
                                                    
                               

                                                    break;

                                                case 2:
                                                    {
                                                        Console.WriteLine("Deleting a job...");
                                                        comp.displaycreatedJObsCompany();
                                                        Console.WriteLine("Choose ID to Delete");
                                                        long jobId = long.Parse(Console.ReadLine());
                                                        comp.deleteJob(jobId);
                                                    }
                                                    break;

                                                case 3:
                                                    {
                                                        if(comp.user.createdJobs!=null && comp.user.createdJobs.Count>0)
                                                        {
                                                            Console.WriteLine("Choose ID to Modify");
                                                            long jobIdM = long.Parse(Console.ReadLine());
                                                            comp.updateJob(jobIdM);
                                                            Console.WriteLine("Modifying account...");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("No jobs is present to modify");
                                                        }
                                                       
                                                    }
                                                    break;

                                                case 4:
                                                    {
                                                        companyLoggedIn = false;
                                                        Console.WriteLine("Logged out successfully.");
                                                    }
                                                    break;
                                                case 5:
                                                    {
                                                        if ((comp) != null)
                                                        {
                                                            //displaying company jobs
                                                            comp?.displaycreatedJObsCompany();
                                                        }
                                                    }
                                                    break;

                                                default:
                                                    Console.WriteLine("Invalid option! Please try again.");
                                                    break;
                                            }
                                        }
                                    }
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
                }
            }
        }
    }
}

                   /* case 3:
                        {
                            Console.WriteLine("Enter your Phone number:");
                            long phone_number = long.Parse(Console.ReadLine());
                            Console.WriteLine("Enter your new password:");
                            string newPassword = Console.ReadLine();
                            account.UpdatePassword(phone_number, newPassword);
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
                            int yoe = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the job description");
                            string j_type = Console.ReadLine();
                            Console.WriteLine("Enter the Job Locations");
                            string location = Console.ReadLine();
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
}*/
