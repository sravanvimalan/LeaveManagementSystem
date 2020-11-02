using System.Web.Http;
using Unity;
using Unity.WebApi;
using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.Repository;
using System.Web.Mvc;
using LeaveManagementSystem.ServiceLayer.IService;
using LeaveManagementSystem.ServiceLayer.Service;

namespace LeaveManagementSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IEmployeeRespository, EmployeeRepository>();
            container.RegisterType<IGenderRepository,GenderRepository>();
            container.RegisterType<IGenderService, GenderService>();
            container.RegisterType<IQualificationRepository, QualificationRepository>();
            container.RegisterType<IQualificationService, QualificationService>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IDesignationRepository, DesignationRepository>();
            container.RegisterType<IDesignationService, DesignationService>();
            container.RegisterType<IExperienceRepository, ExperienceRepository>();
            container.RegisterType<IExperienceService, ExperienceService>();
            container.RegisterType<ILeaveRequestService, LeaveRequestService>();
            container.RegisterType<IRequestVacationRepository, RequestVacationRepository>();
            container.RegisterType<IVacationTypeRepository, VacationTypeRepository>();
            container.RegisterType<IVacationTypeService, VacationTypeService>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}