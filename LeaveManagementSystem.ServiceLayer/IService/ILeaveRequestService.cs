using LeaveManagementSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.ViewModel;
using AutoMapper;

namespace LeaveManagementSystem.ServiceLayer.IService
{
    public interface ILeaveRequestService
    {
        public void AddLeaveRequest(RequestVacationViewModel requestVacationViewModel);

        public List<RequestVacationViewModel> GetLeaveRequestByApproveId(int EmployeeId);

        public void UpdateLeaveRequest(RequestVacationViewModel requestVacationViewModel);

        public RequestVacationViewModel GetLeaveRequestByRequestID(int RequestID);

        public void UpdateStatusAndResponse(string Status, string Response, int RequestId,int VerifierId);

        public List<RequestVacationViewModel> GetAllRequestVacation();


        public List<RequestVacationViewModel> GetAllRequestByRequesterId(int requesterId);



    }
}
