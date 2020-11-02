using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.ViewModel;
using LeaveManagementSystem.DomainModel;

namespace LeaveManagementSystem.ServiceLayer
{
    public interface IQualificationService
    {
        public List<Qualification> GetAllQualification();
        public string GetQualificationById(int QualificationId);
    }
}
