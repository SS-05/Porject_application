using Project_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_application.Storage
{
    public class container
    {
        List<User> list= new List<User>();
        public bool Add(User user)
        {   
            if(user != null)
            {
                list.Add(user);
                return true;
            }
            return false;
        }

        public bool Delete(User user)
        {
            if (user != null)
            {
                list.Remove(user);
                return true;
            }
            return false;
        }

    }
}
