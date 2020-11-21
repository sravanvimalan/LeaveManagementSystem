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
        
        public List<RequestVacation> GetAllRequestVacation();

        public void AddRequestVacation(RequestVacation requestVacation);

        public List<RequestVacation> GetLeaveRequestByApproveId(int employeeId);

     

        public RequestVacation GetLeaveRequestByRequestID(int requestID);

        public void UpdateStatusAndResponse(string status, string response, int requestId,int verifierId);

        public List<RequestVacation> GetAllRequestByEmployeeId(int id);

        public List<RequestVacation> GetAllLeaveRequestForVirtualHead(int departmentId);
        public List<RequestVacation> GetAllLeaveRequestForProjectManager(int employeeId);
        public List<RequestVacation> GetAllLeaveRequestForHR();
    }
}
