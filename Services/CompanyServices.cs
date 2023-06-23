using Project_application.Models;
using Project_application.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_application.Services
{
    public  class CompanyServices
    {
        //User usr ;
        Company comp;
        public CompanyServices(User? usr) {
            //this.usr = usr;
            comp = new Company(usr);
        }
        
        /*AccountUser account = new AccountUser();*/
        /*bool flag = true;
        User curUsr = null;*/
        public void HandleCompanyServices()
        {
            bool companyLoggedIn = true;

            while (companyLoggedIn)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("///////////////////////////////////////////////COMPANY MENU////////////////////////////////////////////////////");
                Console.ForegroundColor = ConsoleColor.White; 
                Console.WriteLine("Select an option:");
                Console.WriteLine("1) Create Job\n2) Delete Job\n3) Modify Posted Job Details\n4)Display Created Jobs\n5) Logout");
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
                            
                            if(comp.user != null && comp.user.createdJobs != null && comp.user.createdJobs.Count > 0)
                            {
                                Console.WriteLine("Choose ID to Delete");
                                long jobId = long.Parse(Console.ReadLine());
                                comp.deleteJob(jobId);
                            }
                            else
                            {
                                Console.WriteLine("No Jobs present at the moment to Delete");
                            }
                           
                        }
                        break;

                    case 3:
                        {
                            if (comp?.user.createdJobs != null && comp.user.createdJobs.Count > 0)
                            {
                                comp.displaycreatedJObsCompany();
                                Console.WriteLine("Choose ID to Modify");
                                long jobIdM = long.Parse(Console.ReadLine());
                                comp.updateJob(jobIdM);
                                Console.WriteLine("Modifying account...");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("No jobs is present to modify");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        }
                        break;

                    case 4:
                        {
                            if ((comp) != null)
                            {
                                //displaying company jobs
                                comp?.displaycreatedJObsCompany();
                            }
                        }
                        break;
                    case 5:
                        {
                            companyLoggedIn = false;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Logged out successfully.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option! Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
    }
 }

