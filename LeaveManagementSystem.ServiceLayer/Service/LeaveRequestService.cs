using AutoMapper;
using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.Repository;
using LeaveManagementSystem.ServiceLayer.IService;
using LeaveManagementSystem.ViewModel;
using LeaveManagementSystem.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.Utility;

namespace LeaveManagementSystem.ServiceLayer.Service
{

    public class LeaveRequestService : ILeaveRequestService
    {
        IRequestVacationRepository RequestVacationRepository;

        public LeaveRequestService(IRequestVacationRepository requestVacationRepository)
        {
            RequestVacationRepository = requestVacationRepository;
        }

        public void AddLeaveRequest(RequestVacationViewModel requestVacationViewModel)
        {
            RequestVacation requestVacation = null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestVacationViewModel, RequestVacation>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            requestVacation = mapper.Map<RequestVacationViewModel, RequestVacation>(requestVacationViewModel);
            RequestVacationRepository.AddRequestVacation(requestVacation);

        }

        public List<RequestVacationViewModel> GetAllRequestByEmployeeId(int id)
        {
            List<RequestVacation> vacations = RequestVacationRepository.GetAllRequestByEmployeeId(id);
            List<RequestVacationViewModel> requestVacations = null;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestVacation, RequestVacationViewModel>();
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
                cfg.CreateMap<Designation, DesignationViewModel>();
                cfg.CreateMap<Gender, GenderViewModel>();
                cfg.CreateMap<Qualification, QualificationViewModel>();
                cfg.CreateMap<Experience, ExperienceViewModel>();
                cfg.CreateMap<VacationType, VacationTypeViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            requestVacations = mapper.Map<List<RequestVacation>, List<RequestVacationViewModel>>(vacations);

            return requestVacations;

        }

        public List<RequestVacationViewModel> GetAllRequestVacation()
        {
            List<RequestVacationViewModel> requestVacationList = null;

            List<RequestVacation> requestVacation = RequestVacationRepository.GetAllRequestVacation();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestVacation, RequestVacationViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            requestVacationList = mapper.Map<List<RequestVacation>, List<RequestVacationViewModel>>(requestVacation);

            return requestVacationList;


        }

        public List<RequestVacationViewModel> GetLeaveRequestByApproveId(int employeeId)
        {
            List<RequestVacation> List = RequestVacationRepository.GetLeaveRequestByApproveId(employeeId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestVacation, RequestVacationViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            List<RequestVacationViewModel> requestVacationViewModel = mapper.Map<List<RequestVacation>, List<RequestVacationViewModel>>(List);

            return requestVacationViewModel;


        }

        public RequestVacationViewModel GetLeaveRequestByID(int requestID)
        {
            RequestVacation requestVacation = RequestVacationRepository.GetLeaveRequestByRequestID(requestID);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestVacation, RequestVacationViewModel>();
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
                cfg.CreateMap<Designation, DesignationViewModel>();
                cfg.CreateMap<Gender, GenderViewModel>();
                cfg.CreateMap<Qualification, QualificationViewModel>();
                cfg.CreateMap<Experience, ExperienceViewModel>();
                cfg.CreateMap<VacationType, VacationTypeViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            RequestVacationViewModel requestVacationViewModel = mapper.Map<RequestVacation, RequestVacationViewModel>(requestVacation);

            return requestVacationViewModel;
        }



        public void UpdateStatusAndResponse(string status, string response, int requestId, int verifierId)
        {
            RequestVacationRepository.UpdateStatusAndResponse(status, response, requestId, verifierId);
        }
       
        public List<RequestVacationViewModel> GetAllLeaveRequest(string designation, string department, int departmentId, int employeeId)
        {
            if (department == "HR")
            {
                return MapRequestDV(RequestVacationRepository.GetAllLeaveRequestForHR());
            }
            if (designation == "Project Manager")
            {
               var leaveRequests =  MapRequestDV(RequestVacationRepository.GetAllLeaveRequestForProjectManager(employeeId));

                return leaveRequests;
               
            }
            return MapRequestDV(RequestVacationRepository.GetAllLeaveRequestForVirtualHead(departmentId));
        }


        public List<RequestVacationViewModel> MapRequestDV(List<RequestVacation> requestVacation)
        {
            List<RequestVacationViewModel> requestVacationViewModel = null;
            var config = new MapperConfiguration(cfg =>
            { 

                cfg.CreateMap<RequestVacation, RequestVacationViewModel>();
                cfg.CreateMap<Employee, EmployeeViewModel>();
                cfg.CreateMap<Department, DepartmentViewModel>();
                cfg.CreateMap<Designation, DesignationViewModel>();
                cfg.CreateMap<Gender, GenderViewModel>();
                cfg.CreateMap<Qualification, QualificationViewModel>();
                cfg.CreateMap<Experience, ExperienceViewModel>();
                cfg.CreateMap<VacationType, VacationTypeViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            requestVacationViewModel = mapper.Map<List<RequestVacation>, List<RequestVacationViewModel>>(requestVacation);

            return requestVacationViewModel;
        }
    }      
       
}


















    