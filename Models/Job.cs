using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_application.Models
{
    public class Job
    {

        public long Id;
        public string company_name;
        public int yoe;
        public string job_type;
        public string location;
        public string shift;
        public string skillset;
        public Job(long Id,string company_name, int yoe, string job_type, string location, string shift, string skillset)
        {
            this.Id = Id;
            this.company_name = company_name;
            this.yoe = yoe;
            this.job_type = job_type;
            this.location = location;
            this.shift = shift;
            this.skillset = skillset;
        }

    }
}
