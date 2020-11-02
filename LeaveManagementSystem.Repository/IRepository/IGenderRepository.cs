using LeaveManagementSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public interface IGenderRepository
    {
        public string GetGenderByID(int GenderID);
        public List<Gender> GetGenders();
    }
}
