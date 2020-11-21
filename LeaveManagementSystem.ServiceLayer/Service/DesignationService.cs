using AutoMapper;
using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.Repository;
using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LeaveManagementSystem.Utility;
namespace LeaveManagementSystem.ServiceLayer
{

    public class DesignationService : IDesignationService
    {
        IDesignationRepository designationRepository;
       

        public DesignationService(IDesignationRepository designationRepository)
        {
            this.designationRepository = designationRepository;
           
        }


        public void AddDesignation(DesignationViewModel obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DesignationViewModel, Designation>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            Designation designation = mapper.Map<DesignationViewModel, Designation>(obj);

            designationRepository.AddDesignation(designation); 
        }

        public bool IsDesignationExist(string designation)
        {
            return designationRepository.IsDesignationExist(designation);
        }


       public IEnumerable<SelectListItem> GetSelectListItemDesignation()
        {
            var designation = designationRepository.GetAllDesignations();
            var selectList = new List<SelectListItem>();

            foreach (var item in designation)
            {
                selectList.Add(new SelectListItem
                {
                    Text = item.DesignationName,
                    Value = item.DesignationID.ToString()
                });
            }

            return selectList;
        }

        public List<DesignationViewModel> GetAllDesignations()
        {
            var designations = designationRepository.GetAllDesignations();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Designation, DesignationViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            List<DesignationViewModel> designationViewModel = mapper.Map<List<Designation>,List< DesignationViewModel>>(designations);

            return designationViewModel;
        }
    }
}
