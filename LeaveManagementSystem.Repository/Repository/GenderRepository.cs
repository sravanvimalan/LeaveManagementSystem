using LeaveManagementSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public class GenderRepository : IGenderRepository
    {
        LeaveManagementSystemDbcontext Db;
        public GenderRepository()
        {
            Db = new LeaveManagementSystemDbcontext();
        }

        public string GetGenderByID(int GenderID)
        {
            Gender obj = Db.Gender.Where(temp => temp.GenderID == GenderID).FirstOrDefault();
            return obj.GenderName;
        }

        public List<Gender> GetGenders()
        {
            List<Gender> list = Db.Gender.ToList();
            return list;
        }
    }
}
