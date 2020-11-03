using LeaveManagementSystem.Repository;
using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.DomainModel;
using AutoMapper;
using System.Web.Mvc;

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
       public IEnumerable<SelectListItem> GetSelectListItemQualification(IEnumerable<Qualification> qualification)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in qualification)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.QualificationID.ToString(),
                    Text = item.QualificationName
                });


            }
            return selectList;
        }

    }
}
