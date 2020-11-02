using LeaveManagementSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public class VacationTypeRepository : IVacationTypeRepository
    {
        LeaveManagementSystemDbcontext Db;
        public VacationTypeRepository()
        {
            Db = new LeaveManagementSystemDbcontext();
        }

        public List<VacationType> GetAllVacationTypes()
        {
            List<VacationType> list = Db.VacationType.ToList();
            return list;
        }

        public VacationType GetVacationTypeByVacationId(int vacationId)
        {
            VacationType vacationType = Db.VacationType.Where(temp => temp.VacationTypeID == vacationId).FirstOrDefault();

            return vacationType;
        }
    }
}
