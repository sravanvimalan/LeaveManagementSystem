using AutoMapper;
using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.Repository;
using LeaveManagementSystem.ServiceLayer.IService;
using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.ServiceLayer.Service
{
    public class VacationTypeService : IVacationTypeService
    {
        IVacationTypeRepository vacationTypeRepository;

        public VacationTypeService(IVacationTypeRepository vacationTypeRepository)
        {
            this.vacationTypeRepository = vacationTypeRepository;
        }

        public List<VacationType> GetAllVacationType()
        {
            List<VacationType> list = vacationTypeRepository.GetAllVacationTypes();
            return list;
        }

        public VacationTypeViewModel GetVacationTypeByVacationId(int vacationId)
        {
            VacationType vacation = vacationTypeRepository.GetVacationTypeByVacationId(vacationId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VacationType, VacationTypeViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            VacationTypeViewModel vacationTypeViewModel = mapper.Map<VacationType, VacationTypeViewModel>(vacation);

            return vacationTypeViewModel;
        }
    }
}
