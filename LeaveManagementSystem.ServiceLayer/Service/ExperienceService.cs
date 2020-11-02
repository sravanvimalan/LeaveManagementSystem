using LeaveManagementSystem.Repository;
using LeaveManagementSystem.ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.ServiceLayer.Service
{
    public class ExperienceService : IExperienceService
    {
        IExperienceRepository ExpRepo;

        public ExperienceService(IExperienceRepository expRepo)
        {
            this.ExpRepo = expRepo;
        }

        public int GetLatestExperienceID()
        {
            return ExpRepo.GetLastestExperienceID();
        }
    }
}
