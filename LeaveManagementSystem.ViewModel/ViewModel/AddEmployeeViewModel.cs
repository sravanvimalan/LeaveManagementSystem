using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LeaveManagementSystem.ViewModel.ViewModel
{
    public class AddEmployeeViewModel
    {
        
        public int EmployeeID { get; set; }
        public string Image { get; set; }
       
        [MaxLength(150)]
        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }
      
        [MaxLength(150)]
        public string MiddleName { get; set; }
        
        [MaxLength(150)]
        [Required(ErrorMessage ="Last name is required")]

        public string LastName { get; set; }
        
        [Required(ErrorMessage ="Join date is required")]
        public DateTime JoinDate { get; set; }
     
        [Required(ErrorMessage ="Date of Birth field is required")]
        public DateTime DateOfBirth { get; set; }
       

        public int? QualificationID { get; set; }
        [Required(ErrorMessage = "Qualification field is required")]
        public string SelectedQualificationId { get; set; }

        //public int? ExperienceID { get; set; } = 0;
       
       
        public bool EmployeeStatus { get; set; }
       
        [MaxLength(150)]
        [Required(ErrorMessage ="Address is required")]
        public string AddressLine1 { get; set; }
        
        [MaxLength(150)]
        public string AddressLine2 { get; set; }
       
        [MaxLength(150)]
        public string AddressLine3 { get; set; }
       
        [MaxLength(150)]
        [Required(ErrorMessage ="Email ID field is Required")]
        public string EmailID { get; set; }


       
       
        public int? GenderID { get; set; }
        [Required(ErrorMessage ="Gender field is required")]
        public string SelectedGenderId { get; set; }
       
        [MaxLength(150)]
        public string Nationality { get; set; }
       
        [MaxLength(150)]
        [Required(ErrorMessage ="Mobile number is required")]
        public string MobileNumber { get; set; }
       
        
        public int? DesignationID { get; set; }
        [Required(ErrorMessage = "Designation field is required")]
        public int SelectedDesignationId { get; set; }
       
        
        public int? DepartmentID { get; set; }
        [Required(ErrorMessage ="Department field is required")]
        public string SelectedDepartmentId { get; set; }
      
        public int? CreatedBy { get; set; }
        
       
        public DateTime? CreatedOn { get; set; }
       
        public int? ModifiedBy { get; set; }
       
        public DateTime? ModifiedOn { get; set; }
       
        [MinLength(5)]
        [Required]
        public string Password { get; set; }

        [MinLength(5)]
        [Required(ErrorMessage ="Confirm password is required")]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }


    
        
        public bool IsVirtualTeamHead { get; set; }

        
       
        public bool IsSpecialPermission { get; set; }


        [ForeignKey("QualificationID")]
        public virtual QualificationViewModel Qualification { get; set; }
        [ForeignKey("ExperienceID")]
        public virtual ExperienceViewModel Experience { get; set; }

        [ForeignKey("GenderID")]
        public virtual GenderViewModel Gender { get; set; }

        [ForeignKey("DesignationID")]
        public virtual DesignationViewModel Designation { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual DepartmentViewModel Department { get; set; }


        public IEnumerable<SelectListItem> GenderList { get; set; }
        public IEnumerable<SelectListItem> QualificationList { get; set; }
        public IEnumerable<SelectListItem> DesignationList { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }

    }
}
