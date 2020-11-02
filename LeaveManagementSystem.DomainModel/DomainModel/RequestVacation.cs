using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.DomainModel
{
    [Table("RequestVacation")]
    public class RequestVacation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RequestID", Order = 0, TypeName = "int")]
     
        public int RequestID { get; set; }
        [Column("FromDate", Order = 1, TypeName = "datetime")]
        [Required]
        public DateTime FromDate { get; set; }
        [Column("ToDate", Order = 2, TypeName = "datetime")]
        [Required]
        public DateTime ToDate { get; set; }
        [Column("AmOnly", Order = 3, TypeName = "bit")]
        public bool? AmOnly { get; set; }
        [Column("PmOnly", Order = 4, TypeName = "bit")]
        public bool? PmOnly { get; set; }
        [Column("VacationTypeID", Order = 5, TypeName = "int")]
        [Required]
        public int VacationTypeID { get; set; }
        [Column("CreatedBy", Order = 6, TypeName = "int")]
        public int? CreatedBy { get; set; }
        [Column("CreatedOn", Order = 7, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column("Comments", Order = 8)]
        [MaxLength(150)]
        public string Comments { get; set; }
       
        [Column("ApproverID", Order = 9, TypeName = "int")]
        [Required]
        public int? ApproverID { get; set; }
        [Column("LeaveStatus", Order = 10, TypeName = "varchar")]
        public string LeaveStatus { get; set; }
        
        [Column("Response", Order = 11)]
        [MaxLength(200)]
        public string Response { get; set; }
        
        

        [ForeignKey("VacationTypeID")]
        public virtual VacationType VacationType { get; set; }
    }
}
