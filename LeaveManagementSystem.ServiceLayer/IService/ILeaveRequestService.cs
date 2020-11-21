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

        public List<RequestVacationViewModel> GetLeaveRequestByApproveId(int employeeId);

        

        public RequestVacationViewModel GetLeaveRequestByID(int requestID);

        public void UpdateStatusAndResponse(string status, string response, int requestId,int verifierId);

        public List<RequestVacationViewModel> GetAllRequestVacation();


        public List<RequestVacationViewModel> GetAllRequestByEmployeeId(int id);
        List<RequestVacationViewModel> GetAllLeaveRequest(string designation, string department, int departmentId, int designationId);
    }
}
