using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.DomainModel.DTOClasses;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        LeaveManagementSystemDbcontext Db;
        public DepartmentRepository()
        {
            Db = new LeaveManagementSystemDbcontext();
        }

      
        public List<Department> GetAllDepartments()
        {
            List<Department> list = Db.Department.ToList();
            return list;
        }

       

        public void AddDepartment(Department obj)
        {
      
            Db.Department.Add(obj);
            Db.SaveChanges();
        }

        public bool IsDepartmentExist(string department)
        {
            return Db.Department.Any(temp => temp.DepartmentName == department);
        }

        public List<DepartmentWithVirtualHeadDTO> GetAllDepartmentWithVirtualHead()
        {
            var departmentWithVirtualHeadDTO = new List<DepartmentWithVirtualHeadDTO>();

            var vhList = Db.Employee.Where(temp => temp.IsVirtualTeamHead == true).ToList();

            var departmentWithVT = from dep in Db.Department.ToList()
                              join emp in vhList
                              on dep.DepartmentID equals emp.DepartmentID
                              into depWithVT
                              from dv in depWithVT.DefaultIfEmpty()
                              select new { dep, dv };

            foreach (var item in departmentWithVT)
            {
                if (item.dv != null && item.dv.IsVirtualTeamHead == true)
                {
                    departmentWithVirtualHeadDTO.Add(new DepartmentWithVirtualHeadDTO
                    {
                        DepartmentID = item.dep.DepartmentID,
                        DepartmentName = item.dep.DepartmentName,
                        EmployeeID = item.dv.EmployeeID,
                        EmployeeName = item.dv.FirstName + item.dv.MiddleName + item.dv.LastName
                    });
                }
                else
                {
                    departmentWithVirtualHeadDTO.Add(new DepartmentWithVirtualHeadDTO
                    {
                        DepartmentID = item.dep.DepartmentID,
                        DepartmentName = item.dep.DepartmentName,
                        EmployeeID = 0,
                        EmployeeName = "Not Yet Assigned "
                    });
                }

            }
           

            return departmentWithVirtualHeadDTO;
        }
    }
}
