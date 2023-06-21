using System.Threading.Tasks.Dataflow;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using Project_application.Models;

namespace Project_application.Screens

{

    internal class Company

    {

        public User user;
        public Company(User comp_user)

        {

            user = comp_user;

        }
        public void createJob(Job job)
        {
            if (user.createdJobs == null)
            {
                user.createdJobs = new List<Job>();
            }
            user.createdJobs.Add(job);
            Console.WriteLine("Job created");

        }

        public void deleteJob(long id)

        {
            Job jobToDelete = user.createdJobs.FirstOrDefault(job => job.Id == id);


            user.createdJobs.Remove(jobToDelete);

            Console.WriteLine("Job deleted");

        }public void updateJob(long jobId)

        {
            Job jobToDelete = user.createdJobs.FirstOrDefault(job => job.Id == jobId);
            int index = user.createdJobs.IndexOf(jobToDelete);
            Console.WriteLine("Enter the field you wish to update");
            Console.WriteLine("Select\n1)Location\n2)Shift\n3)Skillset\n4)Years of experience");
            int choice=Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Enter the updated location");
                        string location = Console.ReadLine();
                        jobToDelete.location = location;
                        user.createdJobs[index] = jobToDelete;


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
                case 4 :
                    {
                        Console.WriteLine("Enter the updated Years of Expereince required");
                        int yoe = Convert.ToInt32(Console.ReadLine());
                        jobToDelete.yoe= yoe;
                        user.createdJobs[index] = jobToDelete;


                    }
                    break;
                default:
                    {
                        Console.WriteLine("Invalid option");
                    }
                    break;
            }


        }

        //display own jobs and users applied to them

        //apply filters based on experience, education, skills, etc.
        public void showallcpompjobstoApply()
        {
            if (user.createdJobs == null || user.createdJobs.Count == 0)
            {
                Console.WriteLine("No Jobs are Created");
            }
            else
            {

                AccountUser.users.ForEach(user =>
                {
                    if (user.user_type.ToUpper() == "COMPANY")
                    {

                    }
                    Console.WriteLine(user.user_id + " " + user.password);


                });
            }

            }
        public void displaycreatedJObsCompany()
        {
            if(user.createdJobs!=null || user.createdJobs.Count > 0)
            {
                user.createdJobs.
                ForEach(user =>
                {
                    Console.WriteLine(user.company_name);
                    Console.WriteLine(user.skillset);
                    Console.WriteLine(user.yoe);
                    Console.WriteLine(user.shift);
                    Console.WriteLine(user.location);
                });
            }
            else
            {
                Console.WriteLine("No jobs for now:(");
            }
            
            

           

        }
        public void dispApplicants(List<User> users)
        {

            //display users

            foreach (User user in users)
            {

                Console.WriteLine(user);

            }

        }

    }

}