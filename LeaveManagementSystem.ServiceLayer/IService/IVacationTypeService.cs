﻿using LeaveManagementSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.ViewModel;
using System.Web.Mvc;

namespace LeaveManagementSystem.ServiceLayer.IService
{
    public interface IVacationTypeService
    {
        public List<VacationType> GetAllVacationType();
        public VacationTypeViewModel GetVacationTypeByVacationId(int vacationId);

        public IEnumerable<SelectListItem> GetAllVacationTypeList(IEnumerable<VacationType> vacationType);
    }
}
