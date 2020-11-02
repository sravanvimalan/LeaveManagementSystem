using AutoMapper;
using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.Repository;
using LeaveManagementSystem.ServiceLayer.IService;
using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            RequestVacationRepository.SetNewRequestVacation(requestVacation);
            
        }

        public List<RequestVacationViewModel> GetAllRequestByRequesterId(int requesterId)
        {
            List<RequestVacation> vacations = RequestVacationRepository.GetAllRequestByRequesterId(requesterId);
            List<RequestVacationViewModel> requestVacations = null;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestVacation, RequestVacationViewModel>();
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

        public List<RequestVacationViewModel> GetLeaveRequestByApproveId(int EmployeeId)
        {
            List<RequestVacation> List = RequestVacationRepository.GetLeaveRequestByApproveId(EmployeeId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestVacation, RequestVacationViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            List<RequestVacationViewModel> requestVacationViewModel = mapper.Map<List<RequestVacation>, List<RequestVacationViewModel>>(List);

            return requestVacationViewModel;


        }

        public RequestVacationViewModel GetLeaveRequestByRequestID(int RequestID)
        {
            RequestVacation requestVacation = RequestVacationRepository.GetLeaveRequestByRequestID(RequestID);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestVacation, RequestVacationViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            RequestVacationViewModel requestVacationViewModel = mapper.Map<RequestVacation, RequestVacationViewModel>(requestVacation);

            return requestVacationViewModel;
        }

        public void UpdateLeaveRequest(RequestVacationViewModel requestVacationViewModel)
        {
            RequestVacation requestVacation = null;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestVacationViewModel, RequestVacation>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            requestVacation = mapper.Map<RequestVacationViewModel, RequestVacation>(requestVacationViewModel);

            RequestVacationRepository.UpdateLeaveRequest(requestVacation);
        }

        public void UpdateStatusAndResponse(string Status, string Response, int RequestId,int VerifierId)
        {
            RequestVacationRepository.UpdateStatusAndResponse(Status, Response, RequestId, VerifierId);
        }
    }
}
