using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.DomainModel
{
    public class LeaveManagementSystemDbcontext : DbContext
    {
        public LeaveManagementSystemDbcontext() : base("LeaveManagementSystemConnectionString")
        {
           
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<RequestVacation> RequestVacation { get; set; }
        public DbSet<VacationType> VacationType { get; set; }
    }
}
