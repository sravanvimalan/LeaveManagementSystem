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

namespace LeaveManagementSystem.ServiceLayer
{
    public class DesignationService : IDesignationService
    {
        IDesignationRepository designationRepository;
       

        public DesignationService(IDesignationRepository designationRepository)
        {
            this.designationRepository = designationRepository;
           
        }

        public List<Designation> GetAllDesignation()
        {
            List<Designation> designation = designationRepository.GetAllDesignations();
            //List<DesignationViewModel> dvm = null;

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Designation, DesignationViewModel>();
            //    cfg.IgnoreUnmapped();
            //});
            //IMapper mapper = config.CreateMapper();

            //dvm = mapper.Map<List<Designation>,List<DesignationViewModel>>(d);

            return designation;
        }

        public DesignationViewModel GetDesignationByDesignationID(int DesignationID)
        {
            Designation designation = designationRepository.GetDesignationByDesignationID(DesignationID);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Designation, DesignationViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            DesignationViewModel designationViewModel = mapper.Map<Designation, DesignationViewModel>(designation);

            return designationViewModel;
        }

        public int GetDesignationIdByName(string DesignationName)
        {
            return designationRepository.GetDesignationIdByName(DesignationName);
        }

        //public int GetLatestDesignationId()
        //{
        //    return designationRepository.GetLatestDesignationId();
        //}

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


       public IEnumerable<SelectListItem> GetSelectListItemDesignation(IEnumerable<Designation> designation)
        {
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
    }
}
