using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.ViewModel;
using LeaveManagementSystem.DomainModel;
using System.Web.Mvc;
using AutoMapper.Configuration.Conventions;

namespace LeaveManagementSystem.ServiceLayer
{
    public interface IGenderService
    {
       
        public IEnumerable<SelectListItem> GenderList();
    }
}
