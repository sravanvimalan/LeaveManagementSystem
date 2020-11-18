using LeaveManagementSystem.DomainModel;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public class DesignationRepository : IDesignationRepository
    {
        LeaveManagementSystemDbcontext Db;
        public DesignationRepository()
        {
            Db = new LeaveManagementSystemDbcontext();
        }

        public void DeleteDesignationByDesignationID(int DesignationID)
        {
            Designation obj = Db.Designation.Where(temp => temp.DesignationID == DesignationID).FirstOrDefault();
             if(obj != null)
            {
                Db.Designation.Remove(obj);
                Db.SaveChanges();
            }
        }

        public List<Designation> GetAllDesignations()
        {
            List<Designation> list = Db.Designation.ToList();
            return list;
        }

      

        public void AddDesignation(Designation obj)
        {
            Db.Designation.Add(obj);
            Db.SaveChanges();
        }
      
        public bool IsDesignationExist(string designation)
        {
            return Db.Designation.Any(temp => temp.DesignationName == designation);
        }

       
    }
}
