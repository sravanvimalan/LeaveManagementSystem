using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.DomainModel
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EmployeeID", Order = 0, TypeName = "int")]
        public int EmployeeID { get; set; }
        [Column("Image", Order = 1)]
        public string Image { get; set; }
        [Column("FirstName", Order = 2)]
        [MaxLength(150)]
        [Required]
        public string FirstName { get; set; }
        [Column("MiddleName", Order = 3)]
        [MaxLength(150)]
        public string MiddleName { get; set; }
        [Column("LastName", Order = 4)]
        [MaxLength(150)]
        [Required]
        public string LastName { get; set; }
        [Column("JoinDate", Order = 5, TypeName = "datetime")]
        [Required]
        public DateTime JoinDate { get; set; }
        [Column(" DateOfBirth", Order = 6, TypeName = "datetime")]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Column(" QualificationID", Order = 7, TypeName = "int")]
       
        public int? QualificationID  { get; set; }
        [Column("ExperienceID", Order = 8, TypeName = "int")]
       
        public int? ExperienceID { get; set; }
        [Column(" EmployeeStatus", Order = 9, TypeName = "bit")]
        [Required]
        public bool EmployeeStatus { get; set; }
        [Column("AddressLine1", Order = 10)]
        [MaxLength(150)]
        public string AddressLine1 { get; set; }
        [Column("AddressLine2", Order = 11)]
        [MaxLength(150)]
        public string AddressLine2 { get; set; }
        [Column("AddressLine3", Order = 12)]
        [MaxLength(150)]
        public string AddressLine3 { get; set; }
        [Column("EmailID", Order = 13)]
        [MaxLength(150)]
        [Required]
        public string EmailID { get; set; }
       

        [Column(" GenderID", Order = 15, TypeName = "int")]
        [Required]
        public int? GenderID { get; set; }
        [Column("Nationality", Order = 16)]
        [MaxLength(150)]
        public string Nationality { get; set; }
        [Column(" MobileNumber ", Order = 17)]
        [MaxLength(150)]
        [Required]
        public string MobileNumber { get; set; }
        [Column("DesignationID", Order = 18, TypeName = "int")]
        [Required]
        public int? DesignationID { get; set; }
        [Column("DepartmentID", Order = 19, TypeName = "int")]
        [Required]
        public int? DepartmentID { get; set; }
        [Column("CreatedBy", Order = 20, TypeName = "int")]
        [Required]
        public int? CreatedBy { get; set; }
        [Column("CreatedOn", Order = 21, TypeName = "datetime")]
        [Required]
        public DateTime? CreatedOn { get; set; }
        [Column("ModifiedBy", Order = 22, TypeName = "int")]
        public int? ModifiedBy { get; set; }
        [Column("ModifiedOn", Order = 23, TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        [Column("Password", Order = 24)]
        [MaxLength(150)]
        [Required]
        public string Password { get; set; }
        [Required]
        [Column("IsVirtualTeamHead", Order = 25, TypeName = "bit")]
        public bool IsVirtualTeamHead { get; set; }

        [Column("IsSpecialPermission", Order = 26, TypeName = "bit")]
        [Required]
        public bool IsSpecialPermission { get; set; }


        [ForeignKey("QualificationID")]
        public virtual Qualification Qualification { get; set; }
        [ForeignKey("ExperienceID")]
        public virtual Experience Experience { get; set; }

        [ForeignKey("GenderID")]
        public virtual Gender Gender { get; set; }

        [ForeignKey("DesignationID")]
        public virtual Designation Designation { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

    }
}
