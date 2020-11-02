using LeaveManagementSystem.DomainModel;
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
        public Department GetDepartmentByDepartmentID(int DepartmentID);

        public void AddDepartment(Department obj);
        public void DeleteDepartmentByDepartmentID(int DepartmentID);

        public int GetLatestDepartmentID();

        public bool IsDepartmentExist(string department);
        
    }
}
