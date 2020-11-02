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
        public Designation GetDesignationByDesignationID(int DesignationID);
       
        public List<Designation> GetAllDesignations();

        public void DeleteDesignationByDesignationID(int DesignationID);
        public int GetDesignationIdByName(string DesignationName);

        //public int GetLatestDesignationId();

        public void AddDesignation(Designation designation);
        public bool IsDesignationExist(string designation);
    }
}
