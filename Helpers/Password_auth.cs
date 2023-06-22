
using Project_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_application.Helpers
{
    internal class Password_auth
    {
        /*private decimal balance;*/
        private User user=null;
        public Password_auth(User user ) {
            this.user = user;
        }

        public string GetPassword() { return user.password; }
        public void setPassword(string newPassword)
        {
            
            if (user != null)
            {
                user.password = newPassword;
                Console.WriteLine("Password updated successfully");
            }
            else
            {
                Console.WriteLine("User not found! Please check the username.");
            }
        }

        

    }
}
