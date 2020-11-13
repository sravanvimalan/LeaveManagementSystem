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
        public DateTime FromDate { get; set; } = DateTime.Now;
        [Column("ToDate", Order = 2, TypeName = "datetime")]
        [Required]
        public DateTime ToDate { get; set; }= DateTime.Now;
        [Column("AmOnly", Order = 3, TypeName = "bit")]
        public bool? AmOnly { get; set; }
        [Column("PmOnly", Order = 4, TypeName = "bit")]
        public bool? PmOnly { get; set; }
        [Column("VacationTypeID", Order = 5, TypeName = "int")]
        [Required]
        public int VacationTypeID { get; set; }
        [Column("CreatorID", Order = 6, TypeName = "int")]
        public int? CreatorID { get; set; }
        [Column("CreatedOn", Order = 7, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column("Comments", Order = 8)]
        [MaxLength(150)]
        public string Comments { get; set; }

        [Column("ApproverID", Order = 9, TypeName = "int")]
        [Required]
        public int? ApproverID { get; set; } = 0;
        [Column("LeaveStatus", Order = 10, TypeName = "varchar")]
        public string LeaveStatus { get; set; }
        
        [Column("Response", Order = 11)]
        [MaxLength(200)]
        public string Response { get; set; }
        [Column("No Of Days", Order = 12, TypeName = "int")]
        [Required]
        public int NoOfDays { get; set; }


        [ForeignKey("VacationTypeID")]
        public virtual VacationType VacationType { get; set; }
        [ForeignKey("ApproverID")]
        public virtual Employee Approver { get; set; }

        [ForeignKey("CreatorID")]
        public virtual Employee Creater { get; set; }



    }
}
