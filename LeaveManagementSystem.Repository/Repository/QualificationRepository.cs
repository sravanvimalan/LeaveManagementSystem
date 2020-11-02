using LeaveManagementSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
   public  class QualificationRepository : IQualificationRepository
    {
        LeaveManagementSystemDbcontext Db;
        public QualificationRepository()
        {
            Db = new LeaveManagementSystemDbcontext();
        }

        public List<Qualification> GetAllQualification()
        {
            List<Qualification> list = Db.Qualification.ToList();
            return list;
        }

        public string GetQualificationById(int QualificationId)
        {
            Qualification qualification = Db.Qualification.Where(temp => temp.QualificationID == QualificationId).FirstOrDefault();

            return qualification.QualificationName;
        }
    }
}
