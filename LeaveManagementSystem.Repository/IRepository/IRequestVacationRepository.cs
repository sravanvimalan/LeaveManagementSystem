using LeaveManagementSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public interface IRequestVacationRepository
    {
        public RequestVacation GetRequestVacationByID(int RequestVacationID);
        public List<RequestVacation> GetAllRequestVacation();

        public void SetNewRequestVacation(RequestVacation obj);

        public List<RequestVacation> GetLeaveRequestByApproveId(int EmployeeId);

        public void UpdateLeaveRequest(RequestVacation requestVacation);

        public RequestVacation GetLeaveRequestByRequestID(int RequestID);

        public void UpdateStatusAndResponse(string Status, string Response, int RequestId,int VerifierId);

        public List<RequestVacation> GetAllRequestByRequesterId(int requesterId);

    }
}
