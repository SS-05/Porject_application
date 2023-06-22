using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_application.Models;
using Project_application.Screens;

namespace Project_application.Screens
{
    internal abstract class Company_abst
    {
        public User user;

        public Company_abst(User comp_user)
        {
            user = comp_user;
        }

        public abstract void createJob(Job job);

        public abstract void deleteJob(long id);

        public abstract void updateJob(long jobId);

        public abstract void showallcpompjobstoApply();

        public abstract void displaycreatedJObsCompany();

        public abstract void dispApplicants(List<User> users);
    }
}
