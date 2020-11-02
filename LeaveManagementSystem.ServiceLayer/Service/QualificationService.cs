using LeaveManagementSystem.Repository;
using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.DomainModel;
using AutoMapper;

namespace LeaveManagementSystem.ServiceLayer
{

    public class QualificationService : IQualificationService
    {
        IQualificationRepository qualificationRepository;

        public QualificationService(IQualificationRepository qualificationRepository)
        {
            this.qualificationRepository = qualificationRepository;
        }

        public List<Qualification> GetAllQualification()
        {
            return qualificationRepository.GetAllQualification(); 
        }

        public string GetQualificationById(int QualificationId)
        {
            return qualificationRepository.GetQualificationById(QualificationId);
        }
    }
}
