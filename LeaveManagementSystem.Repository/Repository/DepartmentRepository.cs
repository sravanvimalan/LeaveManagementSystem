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

        public void DeleteDepartmentByDepartmentID(int DepartmentID)
        {
            Department obj = Db.Department.Where(temp => temp.DepartmentID == DepartmentID).FirstOrDefault();
            if(obj != null)
            {
                Db.Department.Remove(obj);
                Db.SaveChanges();
            }
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> list = Db.Department.ToList();
            return list;
        }

        public Department GetDepartmentByID(int DepartmentID)
        {
            Department obj = Db.Department.Where(temp => temp.DepartmentID == DepartmentID).FirstOrDefault();

            return obj;
        }

       

        public int GetLatestDepartmentID()
        {
            Department obj = new Department();
            try
            {
                obj = Db.Department.OrderByDescending(temp => temp.DepartmentID).First();
            }
            catch
            {

            }
            if (obj != null)
                return obj.DepartmentID;
            return 0;
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
            var departmentWithVT = from dep in Db.Department.ToList()
                              join emp in Db.Employee.ToList()
                              on dep.DepartmentID equals emp.DepartmentID
                              into depWithVT
                              from dv in depWithVT.DefaultIfEmpty()
                              select new { dep, dv };

            foreach (var item in departmentWithVT)
            {
                if(item.dv != null && item.dv.IsVirtualTeamHead == true)
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
