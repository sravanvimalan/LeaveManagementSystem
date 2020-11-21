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
using LeaveManagementSystem.Utility;

namespace LeaveManagementSystem.ServiceLayer
{

    public class QualificationService : IQualificationService
    {
        IQualificationRepository qualificationRepository;

        public QualificationService(IQualificationRepository qualificationRepository)
        {
            this.qualificationRepository = qualificationRepository;
        }

       public IEnumerable<SelectListItem> GetSelectListItemQualification()
        {
            var qualification = qualificationRepository.GetAllQualification();
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
