using LeaveManagementSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public class ExperienceRepository : IExperienceRepository
    {
        LeaveManagementSystemDbcontext Db;

        public ExperienceRepository()
        {
            Db = new LeaveManagementSystemDbcontext();
        }

        public int GetLastestExperienceID()
        {
            try
            {
                Experience obj = Db.Experience.OrderByDescending(temp => temp.ExperienceID).First();


                return obj.ExperienceID;
            }
            catch
            {
               
            }
            return 0;



        }
    }
}
