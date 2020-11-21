using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.Repository;
using AutoMapper;
using LeaveManagementSystem.DomainModel;
using System.Web.Mvc;
using LeaveManagementSystem.Utility;

namespace LeaveManagementSystem.ServiceLayer
{
   
    public class GenderService : IGenderService
    {
        IGenderRepository genderrepo;

        public GenderService(IGenderRepository genderrepo)
        {
            this.genderrepo = genderrepo;
        }
       
     public IEnumerable<SelectListItem> GenderList()
        {
            var genders = genderrepo.GetGenders();
            var selectList = new List<SelectListItem>();


            foreach (var item in genders)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.GenderID.ToString(),
                    Text = item.GenderName
                });
            }

            return selectList;
        }

       
    }
}
