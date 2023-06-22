using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_application.Models
{
    public class User
    {
        public string username;
        public string password;
        public string user_type;
        public long user_id;
        public List<string> skillset;
        //for company
        public List<Job>? createdJobs;
        //for company
        public List<User>? applicants;
        //for user
        public List<Job>? applidJobs;
        public int? experience;
        public long phone_number;
        public User(string username, string password, string user_type, long user_id, List<string> skillset, int? experience, long phone_number, List<Job>? applidJobs, List<User>? applicants,List<Job>? createdJobs)
        {
            this.username = username;
            this.password = password;
            this.user_type = user_type;
            this.user_id = user_id;
            this.skillset = skillset;
            this.experience = experience;
            this.phone_number = phone_number;
            this.applidJobs = applidJobs;
            this.applicants = applicants;
            this.createdJobs = createdJobs; 

        }
    }
}
