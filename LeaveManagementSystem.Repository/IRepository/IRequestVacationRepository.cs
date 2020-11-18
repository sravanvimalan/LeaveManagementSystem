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

        public List<RequestVacation> GetLeaveRequestByApproveId(int EmployeeId);

     

        public RequestVacation GetLeaveRequestByRequestID(int RequestID);

        public void UpdateStatusAndResponse(string Status, string Response, int RequestId,int VerifierId);

        public List<RequestVacation> GetAllRequestByEmployeeId(int id);

        public List<RequestVacation> GetAllLeaveRequestForVirtualHead(int departmentId);
        public List<RequestVacation> GetAllLeaveRequestForProjectManager(int employeeId);
        public List<RequestVacation> GetAllLeaveRequestForHR();
    }
}
