using LeaveManagementSystem.DomainModel;
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

        public Department GetDepartmentByDepartmentID(int DepartmentID)
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
    }
}
