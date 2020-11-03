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

namespace LeaveManagementSystem.ServiceLayer
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public List<DepartmentViewModel> GetAllDepartment()
        {
            List<Department> department = departmentRepository.GetAllDepartments();
            List<DepartmentViewModel> dvm = null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Department, DepartmentViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            dvm = mapper.Map<List<Department>, List<DepartmentViewModel>>(department);

            return dvm;

        }

        public DepartmentViewModel GetDepartmentByDepartmentID(int DepartmentID)
        {
            Department department = departmentRepository.GetDepartmentByDepartmentID(DepartmentID);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Department, DepartmentViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            DepartmentViewModel departmentViewModel = mapper.Map<Department, DepartmentViewModel>(department);

            return departmentViewModel;

        }

        public int GetDepartmentIdByName(string DepartmentName)
        {
            //return departmentRepository.GetDepartmentIdByName(DepartmentName);
            throw new NotImplementedException();
        }

       

        public int GetLatestDepartmentID()
        {
            return departmentRepository.GetLatestDepartmentID();
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
        public IEnumerable<SelectListItem> GetSelectListItemsDepartment(IEnumerable<DepartmentViewModel> department)
        {
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
    }
}
