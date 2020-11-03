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

namespace LeaveManagementSystem.ServiceLayer
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRespository er;

        public EmployeeService(IEmployeeRespository er)
        {
            this.er = er;
        }

        public void DeleteEmployeeByEmployeeID(int EmployeeID)
        {
            er.DeleteEmployeeByEmployeeID(EmployeeID);
        }

        public List<AdminProfileViewModel> GetAllEmployees()
        {
            List<AdminProfileViewModel> list = null;

            List<Employee> emplist = er.GetAllEmployees();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, AdminProfileViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
               
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            list = mapper.Map<List<Employee>, List<AdminProfileViewModel>>(emplist);

            return list;

        }

        public List<AdminProfileViewModel> GetAllVirtualHead()
        {
            List<Employee> list = er.GetAllVirtualHead();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, AdminProfileViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
               
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            List<AdminProfileViewModel> adminProfile = mapper.Map<List<Employee>,List< AdminProfileViewModel >>(list);

            return adminProfile;


        }

        public List<AdminProfileViewModel> GetEmployeeByDepartmentID(int DepartmentId)
        {
            List<Employee> employeelist = er.GetEmployeeByDepartmentID(DepartmentId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, AdminProfileViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
                
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            List<AdminProfileViewModel> emplist = mapper.Map<List<Employee>, List<AdminProfileViewModel>>(employeelist);

            return emplist;
        }

        public AdminProfileViewModel GetEmployeeByEmailAndPassword(string Email, string Password)
        {
            Employee employee = er.GetEmployeeByEmailAndPassword(Email, Password);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, AdminProfileViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
                
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            AdminProfileViewModel adminProfileViewModel = mapper.Map<Employee, AdminProfileViewModel>(employee);

            return adminProfileViewModel;

        }

        public AdminProfileViewModel GetEmployeeByID(int EmployeeID)
        {
            Employee employee = er.GetEmployeeByID(EmployeeID);
            AdminProfileViewModel adminProfileView = null;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, AdminProfileViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
               
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            adminProfileView = mapper.Map<Employee, AdminProfileViewModel>(employee);

            return adminProfileView;
        }

        public List<AdminProfileViewModel> GetEmployeesByDesignationId(int DesignationId)
        {
            List<Employee> list = er.GetEmployeesByDesignationId(DesignationId);

            List<AdminProfileViewModel> employeeProfileViewModel = null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, AdminProfileViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            employeeProfileViewModel = mapper.Map<List<Employee>, List<AdminProfileViewModel>>(list);

            return employeeProfileViewModel;
            
        }

        public bool IsEmailExist(string email)
        {
            return er.IsEmailExist(email);
        }

        public bool IsMobileExist(string mobile)
        {
            return er.IsMobileExist(mobile);
        }

        public void SetNewEmployee(AdminProfileViewModel obj)
        {
            obj.Password = SHA256HashGenerator.GenerateHash(obj.Password);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminProfileViewModel, Employee>();

                cfg.CreateMap<AdminProfileViewModel, Experience>();
               

                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            Employee ed = mapper.Map<AdminProfileViewModel, Employee>(obj);

            Experience exp = mapper.Map<AdminProfileViewModel, Experience>(obj);
            er.SetNewEmployee(ed,exp);

        }

        public void UpdateIsVirtualHeadFlag(int EmployeeId, bool value)
        {
            er.UpdateIsVirtualHeadFlag(EmployeeId, value);
        }

        public void UpdatePassword(string Password, int EmployeeID)
        {
            er.UpdatePassword(Password, EmployeeID);
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

            er.UpdateProfileByAdmin(employee);
        }

        public void UpdateProfileByEmployee(UpdateProfileViewModel updateProfile)
        {
            Employee profile = null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UpdateProfileViewModel, Employee>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            profile = mapper.Map<UpdateProfileViewModel, Employee>(updateProfile);

            er.UpdateProfileByEmployee(profile);
        }
        public IEnumerable<SelectListItem> ApproverList(List<AdminProfileViewModel> list)
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
        public IEnumerable<SelectListItem> GetAllEmployeeOfDepartment(List<AdminProfileViewModel> employee)
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

    }
}
