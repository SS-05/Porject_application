using System.Threading.Tasks.Dataflow;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using Project_application.Models;

namespace Project_application.Screens

{
    internal  class Company : Company_abst

    {
        public User? user;
        public Company(User? comp_user) : base(comp_user)
        {
            // Constructor implementation
            user = comp_user;
        }
        public override void createJob(Job job)
        {
            
            if (user.createdJobs == null)
            {
                user.createdJobs = new List<Job>();
            }
         
            user.createdJobs.Add(job);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Job created");
            Console.WriteLine("Job ID", job.Id);
            Console.WriteLine("Company Name", job.company_name);
            Console.WriteLine("Years of Experience", job.yoe);
            Console.WriteLine("Job Type", job.job_type);
            Console.WriteLine("Location", job.location);
            Console.WriteLine("Shift", job.shift);
            Console.WriteLine("Skillset", job.skillset);
            Console.ForegroundColor = ConsoleColor.White;

        }

        public override void deleteJob(long id)

        {
            
            Job jobToDelete = user.createdJobs.FirstOrDefault(job => job.Id == id);
            if (jobToDelete != null)
            { 
                user.createdJobs.Remove(jobToDelete);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Job deleted!!");
                Console.ForegroundColor = ConsoleColor.White;

            }
           

        }public override void updateJob(long jobId)

        {
            Job jobToDelete = user.createdJobs.FirstOrDefault(job => job.Id == jobId);

            if (jobToDelete == null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Job Not Found to update!!");
                Console.ForegroundColor = ConsoleColor.White;
                //return;

            }
            else
            {
               // displaycreatedJObsCompany();
                int index = user.createdJobs.IndexOf(jobToDelete);
                Console.WriteLine("Enter the field you wish to update");
                Console.WriteLine("Select\n1)Location\n2)Shift\n3)Skillset\n4)Years of experience");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the updated location");
                            string location = Console.ReadLine();
                            jobToDelete.location = location;
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter the updated Shift Details");
                            string shift = Console.ReadLine();
                            jobToDelete.shift = shift;
                            user.createdJobs[index] = jobToDelete;
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Enter the updated skilset needed");
                            string skillset = Console.ReadLine();
                            jobToDelete.skillset = skillset;
                            user.createdJobs[index] = jobToDelete;
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Enter the updated Years of Expereince required");
                            int yoe = Convert.ToInt32(Console.ReadLine());
                            jobToDelete.yoe = yoe;
                            user.createdJobs[index] = jobToDelete;
                        }
                        break;
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option");
                            Console.ForegroundColor = ConsoleColor.White ;
                        }
                        break;
                }

            }
        }

        //display own jobs and users applied to them
        //apply filters based on experience, education, skills, etc.
        public override void showallcpompjobstoApply()
            
        {
            if (user.createdJobs == null || user.createdJobs.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No Jobs are Created for now");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {

                AccountUser.users.ForEach(user =>
                {
                    if (user.user_type.ToUpper() == "COMPANY")
                    {
                        if (user.createdJobs != null && user.createdJobs.Count > 0)
                        {
                            user.createdJobs.ForEach(action => {
                                Console.WriteLine(action.company_name + "\t" + action.yoe + "\t" + action.Id);
                            });
                        }
                    }

                });
            }

         }
        public override void displaycreatedJObsCompany()
        {
            
            if(user!= null && user.createdJobs!=null && user.createdJobs.Count > 0)
            {
                user.createdJobs.
                ForEach(user =>
                {
                    int columnWidth = 20;

                    // Print the table headers
                    Console.WriteLine("ID".PadRight(columnWidth) +
                                      "Company Name".PadRight(columnWidth) +
                                      "Skillset".PadRight(columnWidth) +
                                      "Years of Experience".PadRight(columnWidth) +
                                      "Shift".PadRight(columnWidth) +
                                      "Location".PadRight(columnWidth));

                    // Print the user data
                    Console.WriteLine(user.Id.ToString().PadRight(columnWidth) +
                                      user.company_name.PadRight(columnWidth) +
                                      user.skillset.PadRight(columnWidth) +
                                      user.yoe.ToString().PadRight(columnWidth) +
                                      user.shift.PadRight(columnWidth) +
                                      user.location.PadRight(columnWidth));

                });
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("No jobs for now:(");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
        public override void dispApplicants(List<User> users)
        {
            //display users
            foreach (User user in users)
            {

                Console.WriteLine(user);

            }

        }

    }

}