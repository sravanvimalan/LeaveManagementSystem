using LeaveManagementSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public interface IQualificationRepository
    {
        public List<Qualification> GetAllQualification();
        public string GetQualificationById(int QualificationId);
    }
}
