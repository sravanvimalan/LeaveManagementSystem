﻿using LeaveManagementSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public interface IVacationTypeRepository
    {
        public List<VacationType> GetAllVacationTypes();
        public VacationType GetVacationTypeByVacationId(int vacationId);
    }
}
