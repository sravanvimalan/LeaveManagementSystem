using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.DomainModel.DTOClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAllDepartments();
        //public Department GetDepartmentByID(int DepartmentID);

        public List<DepartmentWithVirtualHeadDTO> GetAllDepartmentWithVirtualHead();

        public void AddDepartment(Department obj);
      

        public bool IsDepartmentExist(string department);
        
    }
}
