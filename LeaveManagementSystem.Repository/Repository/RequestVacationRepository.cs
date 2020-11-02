using LeaveManagementSystem.DomainModel;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public class RequestVacationRepository : IRequestVacationRepository
    {
        LeaveManagementSystemDbcontext Db;
        public RequestVacationRepository()
        {
            Db = new LeaveManagementSystemDbcontext();
        }

        public List<RequestVacation> GetAllRequestByRequesterId(int requesterId)
        {
            List<RequestVacation> requestVacations = Db.RequestVacation.Where(temp => temp.CreatedBy == requesterId).ToList();
            return requestVacations;
        }

        public List<RequestVacation> GetAllRequestVacation()
        {
            List<RequestVacation> list = Db.RequestVacation.ToList();
            return list;
        }

        public List<RequestVacation> GetLeaveRequestByApproveId(int EmployeeId)
        {
            List<RequestVacation> requestVacation = Db.RequestVacation.Where(temp => temp.ApproverID == EmployeeId & temp.LeaveStatus == "Pending").ToList();

            return requestVacation;
        }

        public RequestVacation GetLeaveRequestByRequestID(int RequestID)
        {
            RequestVacation requestVacation = Db.RequestVacation.Where(temp => temp.RequestID == RequestID).FirstOrDefault();

            return requestVacation;
        }

        public RequestVacation GetRequestVacationByID(int RequestID)
        {
            RequestVacation obj = Db.RequestVacation.Where(temp => temp.RequestID == RequestID).FirstOrDefault();
            return obj;
        }

        public void SetNewRequestVacation(RequestVacation obj)
        {
            Db.RequestVacation.Add(obj);
            Db.SaveChanges();
        }

        public void UpdateLeaveRequest(RequestVacation requestVacation)
        {
            RequestVacation existrequest = Db.RequestVacation.Where(temp => temp.RequestID == requestVacation.RequestID).FirstOrDefault();

            existrequest.LeaveStatus = requestVacation.LeaveStatus;
            Db.SaveChanges();
        }

        public void UpdateStatusAndResponse(string Status, string Response, int RequestId,int VerifierId)
        {
            RequestVacation requestVacation = Db.RequestVacation.Where(temp => temp.RequestID == RequestId).FirstOrDefault();

            requestVacation.LeaveStatus = Status;
            requestVacation.Response = Response;
            requestVacation.ApproverID = VerifierId;
            Db.SaveChanges();
        }
    }
}
