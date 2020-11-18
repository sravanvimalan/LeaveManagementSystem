using LeaveManagementSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public interface IDesignationRepository
    {
       
        public List<Designation> GetAllDesignations();
        public void AddDesignation(Designation designation);
        public bool IsDesignationExist(string designation);
    }
}
