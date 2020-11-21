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

        public List<RequestVacation> GetAllRequestByEmployeeId(int id)
        {
            List<RequestVacation> requestVacations = Db.RequestVacation.Where(temp => temp.CreatorID == id).OrderByDescending(temp=>temp.CreatedOn).ToList();
            return requestVacations;
        }

        public List<RequestVacation> GetAllRequestVacation()
        {
            List<RequestVacation> list = Db.RequestVacation.ToList();
            return list;
        }

        public List<RequestVacation> GetLeaveRequestByApproveId(int employeeId)
        {
            List<RequestVacation> requestVacation = Db.RequestVacation.Where(temp => temp.ApproverID == employeeId & temp.LeaveStatus == "Pending").OrderByDescending(temp => temp.CreatedOn).ToList();

            return requestVacation;
        }

        public RequestVacation GetLeaveRequestByRequestID(int requestID)
        {
            RequestVacation requestVacation = Db.RequestVacation.Where(temp => temp.RequestID == requestID).FirstOrDefault();

            return requestVacation;
        }

        public RequestVacation GetRequestVacationByID(int requestID)
        {
            RequestVacation obj = Db.RequestVacation.Where(temp => temp.RequestID == requestID).FirstOrDefault();
            return obj;
        }

        public void AddRequestVacation(RequestVacation requestVacation)
        {
            Db.RequestVacation.Add(requestVacation);
            Db.SaveChanges();
        }

        public void UpdateLeaveRequest(RequestVacation requestVacation)
        {
            RequestVacation existrequest = Db.RequestVacation.Where(temp => temp.RequestID == requestVacation.RequestID).FirstOrDefault();

            existrequest.LeaveStatus = requestVacation.LeaveStatus;
            Db.SaveChanges();
        }

        public void UpdateStatusAndResponse(string status, string response, int requestId,int verifierId)
        {
            RequestVacation requestVacation = Db.RequestVacation.Where(temp => temp.RequestID == requestId).FirstOrDefault();

            requestVacation.LeaveStatus = status;
            requestVacation.Response = response;
            requestVacation.ApproverID = verifierId;
            Db.SaveChanges();
        }

        public List<RequestVacation> GetAllLeaveRequestForVirtualHead(int departmentId)
        {
            List<RequestVacation> requestVacations = Db.RequestVacation.Where(temp => temp.Creater.DepartmentID == departmentId).ToList();

            return requestVacations;
           
        }
        public List<RequestVacation> GetAllLeaveRequestForProjectManager(int employeeId)
        {
            List<RequestVacation> requestVacations = Db.RequestVacation.Where(temp => temp.ApproverID == employeeId).ToList();
            return requestVacations;
        }
        public List<RequestVacation> GetAllLeaveRequestForHR()
        {
            List<RequestVacation> requestVacations = Db.RequestVacation.Where(temp => temp.LeaveStatus == "Pending").ToList();
            return requestVacations;
        }
    }
}
