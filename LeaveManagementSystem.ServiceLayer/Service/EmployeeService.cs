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
using LeaveManagementSystem.Utility;

namespace LeaveManagementSystem.ServiceLayer
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRespository employeeRespository;

        public EmployeeService(IEmployeeRespository employeeRespository)
        {
            this.employeeRespository = employeeRespository;
        }

        public void DeleteEmployeeByEmployeeID(int employeeID)
        {
            employeeRespository.DeleteEmployeeByEmployeeID(employeeID);
        }

        public List<EmployeeViewModel> GetAllEmployees()
        {
            List<EmployeeViewModel> list = null;

            List<Employee> emplist = employeeRespository.GetAllEmployees();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Qualification, QualificationViewModel>();
                cfg.CreateMap<Experience, ExperienceViewModel>();
                cfg.CreateMap<Gender, GenderViewModel>();
                cfg.CreateMap<Designation, DesignationViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
               
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            list = mapper.Map<List<Employee>, List<EmployeeViewModel>>(emplist);

            return list;

        }

        public List<EmployeeViewModel> GetAllVirtualHead()
        {
            //List<Employee> list = employeeRespository.GetAllVirtualHead();
            List<Employee> list = null;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Qualification, QualificationViewModel>();
                cfg.CreateMap<Experience, ExperienceViewModel>();
                cfg.CreateMap<Gender, GenderViewModel>();
                cfg.CreateMap<Designation, DesignationViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();

                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            List<EmployeeViewModel> adminProfile = mapper.Map<List<Employee>,List< EmployeeViewModel >>(list);

            return adminProfile;


        }

        public IEnumerable<SelectListItem> GetAllEmployeeByDepartmentID(int departmentId)
        {
            List<Employee> employeelist = employeeRespository.GetEmployeeByDepartmentID(departmentId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Qualification, QualificationViewModel>();
                cfg.CreateMap<Experience, ExperienceViewModel>();
                cfg.CreateMap<Gender, GenderViewModel>();
                cfg.CreateMap<Designation, DesignationViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();

                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            List<EmployeeViewModel> emplist = mapper.Map<List<Employee>, List<EmployeeViewModel>>(employeelist);

            return GetAllEmployeeOfDepartment(emplist);
        }

        public int AuthenticateUser(string email, string password)
        {
            return employeeRespository.AuthenticateUser(email, password);
        }

        public EmployeeViewModel GetEmployeeByID(int employeeID)
        {
           Employee employee = employeeRespository.GetEmployeeByID(employeeID);
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

      

        public bool IsEmailExist(string email)
        {
            return employeeRespository.IsEmailExist(email);
        }

        public bool IsMobileExist(string mobile)
        {
            return employeeRespository.IsMobileExist(mobile);
        }

        public void AddEmployee(AddEmployeeViewModel addEmployeeViewModel)
        {
            addEmployeeViewModel.Password = SHA256HashGenerator.GenerateHash(addEmployeeViewModel.Password);
            addEmployeeViewModel.GenderID = Convert.ToInt32(addEmployeeViewModel.SelectedGenderId);
            addEmployeeViewModel.DepartmentID = Convert.ToInt32(addEmployeeViewModel.SelectedDepartmentId);
            addEmployeeViewModel.DesignationID = Convert.ToInt32(addEmployeeViewModel.SelectedDesignationId);
            addEmployeeViewModel.QualificationID = Convert.ToInt32(addEmployeeViewModel.SelectedQualificationId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddEmployeeViewModel, Employee>();
                cfg.CreateMap<ExperienceViewModel, Experience>();
                cfg.CreateMap<GenderViewModel, Gender>();
                cfg.CreateMap<DesignationViewModel, Designation>();
                cfg.CreateMap<DepartmentViewModel, Department>();
                cfg.CreateMap<QualificationViewModel, Qualification>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            Employee employee = mapper.Map<AddEmployeeViewModel, Employee>(addEmployeeViewModel);
            employeeRespository.AddEmployee(employee);

        }

        public void UpdateIsVirtualHead(int employeeId, bool value)
        {
            employeeRespository.UpdateIsVirtualHead(employeeId, value);
        }

        public void UpdatePassword(string password, int employeeID)
        {
            employeeRespository.UpdatePassword(password, employeeID);
        }

        public void UpdateProfileByAdmin(EmployeeViewModel profile)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeViewModel, Employee>();
                cfg.CreateMap<ExperienceViewModel, Experience>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            Employee employee = mapper.Map<EmployeeViewModel, Employee>(profile);

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

        public List<EmployeeViewModel> ListEmployee(string name)
        {
            List<EmployeeViewModel> list = null;

            List<Employee> emplist = employeeRespository.ListEmployee(name);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Qualification, QualificationViewModel>();
                cfg.CreateMap<Experience, ExperienceViewModel>();
                cfg.CreateMap<Gender, GenderViewModel>();
                cfg.CreateMap<Designation, DesignationViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();

                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            list = mapper.Map<List<Employee>, List<EmployeeViewModel>>(emplist);

            return list;
        }
        
    }
}
