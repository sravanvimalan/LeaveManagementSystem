using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.Repository;
using LeaveManagementSystem.DomainModel;
using AutoMapper;
using System.Data.Entity.Migrations.Model;
using LeaveManagementSystem.ViewModel.ViewModel;
using System.Web.Mvc;
using LeaveManagementSystem.DomainModel.DTOClasses;

namespace LeaveManagementSystem.ServiceLayer
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRespository employeeRespository;

        public EmployeeService(IEmployeeRespository employeeRespository)
        {
            this.employeeRespository = employeeRespository;
        }

        public void DeleteEmployeeByEmployeeID(int EmployeeID)
        {
            employeeRespository.DeleteEmployeeByEmployeeID(EmployeeID);
        }

        public List<EmployeeViewModel> GetAllEmployees()
        {
            List<EmployeeViewModel> list = null;

            List<Employee> emplist = employeeRespository.GetAllEmployees();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
               
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            list = mapper.Map<List<Employee>, List<EmployeeViewModel>>(emplist);

            return list;

        }

        public List<EmployeeViewModel> GetAllVirtualHead()
        {
            List<Employee> list = employeeRespository.GetAllVirtualHead();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
               
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            List<EmployeeViewModel> adminProfile = mapper.Map<List<Employee>,List< EmployeeViewModel >>(list);

            return adminProfile;


        }

        public List<EmployeeViewModel> GetEmployeeByDepartmentID(int DepartmentId)
        {
            List<Employee> employeelist = employeeRespository.GetEmployeeByDepartmentID(DepartmentId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
                
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            List<EmployeeViewModel> emplist = mapper.Map<List<Employee>, List<EmployeeViewModel>>(employeelist);

            return emplist;
        }

        public int AuthenticateUser(string Email, string Password)
        {
            return employeeRespository.AuthenticateUser(Email, Password);
        }

        public EmployeeViewModel GetEmployeeByID(int EmployeeID)
        {
           Employee employee = employeeRespository.GetEmployeeByID(EmployeeID);
            EmployeeViewModel employeeViewModel = null;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
                cfg.CreateMap<Designation, DesignationViewModel>();
                cfg.CreateMap<Gender, GenderViewModel>();
                cfg.CreateMap<Qualification, QualificationViewModel>();
                cfg.CreateMap<Experience, ExperienceViewModel>();

                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            employeeViewModel = mapper.Map<Employee, EmployeeViewModel>(employee);

            return employeeViewModel;
        }

        public List<EmployeeViewModel> GetEmployeesByDesignationId(int DesignationId)
        {
            List<Employee> list = employeeRespository.GetEmployeesByDesignationId(DesignationId);

            List<EmployeeViewModel> employeeProfileViewModel = null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
                cfg.CreateMap<Designation, DesignationViewModel>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            employeeProfileViewModel = mapper.Map<List<Employee>, List<EmployeeViewModel>>(list);

            return employeeProfileViewModel;
            
        }

        public bool IsEmailExist(string email)
        {
            return employeeRespository.IsEmailExist(email);
        }

        public bool IsMobileExist(string mobile)
        {
            return employeeRespository.IsMobileExist(mobile);
        }

        public void SetNewEmployee(EmployeeViewModel obj)
        {
            //obj.Password = SHA256HashGenerator.GenerateHash(obj.Password);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeViewModel, Employee>();

                cfg.CreateMap<EmployeeViewModel, Experience>();
               

                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            Employee ed = mapper.Map<EmployeeViewModel, Employee>(obj);

            Experience exp = mapper.Map<EmployeeViewModel, Experience>(obj);
            employeeRespository.SetNewEmployee(ed,exp);

        }

        public void UpdateIsVirtualHeadFlag(int EmployeeId, bool value)
        {
            employeeRespository.UpdateIsVirtualHeadFlag(EmployeeId, value);
        }

        public void UpdatePassword(string Password, int EmployeeID)
        {
            employeeRespository.UpdatePassword(Password, EmployeeID);
        }

        public void UpdateProfileByAdmin(UpdateEmpProfileByAdminViewModel profile)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UpdateEmpProfileByAdminViewModel, Employee>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            Employee employee = mapper.Map<UpdateEmpProfileByAdminViewModel, Employee>(profile);

            employeeRespository.UpdateProfileByAdmin(employee);
        }

        public void UpdateProfileByEmployee(UpdateProfileByEmployeeViewModel updateProfile)
        {
            Employee employeeProfile = null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UpdateProfileByEmployeeViewModel, Employee>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            employeeProfile = mapper.Map<UpdateProfileByEmployeeViewModel, Employee>(updateProfile);

            employeeRespository.UpdateProfileByEmployee(employeeProfile);
        }
        public IEnumerable<SelectListItem> ApproverList(List<EmployeeViewModel> list)
        {
            var selectlist = new List<SelectListItem>();

            foreach (var item in list)
            {
                selectlist.Add(new SelectListItem
                {
                    Text = item.FirstName + " " + item.MiddleName + " " + item.LastName,
                    Value = item.EmployeeID.ToString()

                });
            }
            return selectlist;
        }
        public IEnumerable<SelectListItem> GetAllEmployeeOfDepartment(List<EmployeeViewModel> employee)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in employee)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.EmployeeID.ToString(),
                    Text = item.FirstName + " " + item.MiddleName + " " + item.LastName
                });
            }
            return selectList;
        }
        //newly addedd
        public IEnumerable<SelectListItem> GetAllProjectManagers()
        {
            var ProjectManagers = employeeRespository.GetAllProjectManagers();

            var selectListItem = new List<SelectListItem>();

            foreach (var item in ProjectManagers)
            {
                selectListItem.Add(new SelectListItem
                {
                    Value =Convert.ToString(item.EmployeeID),
                    Text = item.FirstName + " " + item.MiddleName + " " + item.LastName
                });
            }

            return selectListItem;
        }
        //newly addedd
    }
}
