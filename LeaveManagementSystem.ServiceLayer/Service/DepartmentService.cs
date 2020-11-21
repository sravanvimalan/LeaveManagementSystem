using LeaveManagementSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.Repository;
using LeaveManagementSystem.ViewModel;
using AutoMapper;
using System.Net;
using System.Web.Mvc;
using LeaveManagementSystem.DomainModel.DTOClasses;
using LeaveManagementSystem.Utility;

namespace LeaveManagementSystem.ServiceLayer
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

     
        public void AddDepartment(DepartmentViewModel obj)
        {
            Department departmentobj = new Department();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentViewModel, Department>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            departmentobj = mapper.Map<DepartmentViewModel, Department>(obj);

            departmentRepository.AddDepartment(departmentobj);

        }

        public bool IsDepartmentExist(string department)
        {
            return departmentRepository.IsDepartmentExist(department);
        }
        public IEnumerable<SelectListItem> GetSelectListItemsDepartment()
        {
            var department = departmentRepository.GetAllDepartments();
            var selectList = new List<SelectListItem>();

            foreach (var item in department)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.DepartmentID.ToString(),
                    Text = item.DepartmentName
                });
            }
            return selectList;
        }

        public List<DepartmentWithVirtualHeadViewModel> GetAllDepartmentWithVirtualHead()
        {
            var list = departmentRepository.GetAllDepartmentWithVirtualHead();
            List<DepartmentWithVirtualHeadViewModel> departmentWithVirtualHeadViewModels = null;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentWithVirtualHeadDTO, DepartmentWithVirtualHeadViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            departmentWithVirtualHeadViewModels = mapper.Map<List<DepartmentWithVirtualHeadDTO>, List<DepartmentWithVirtualHeadViewModel>>(list);

            return departmentWithVirtualHeadViewModels;
        }
    }
}
