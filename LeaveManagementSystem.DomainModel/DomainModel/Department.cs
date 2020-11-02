using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace LeaveManagementSystem.DomainModel
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DepartmentID",Order = 0, TypeName = "int")]
        public int DepartmentID { get; set; }
        
        [Column("DepartmentName", Order =1)]
        [MaxLength(150)]
        [Required]
        public string DepartmentName { get; set; }
    }
}
