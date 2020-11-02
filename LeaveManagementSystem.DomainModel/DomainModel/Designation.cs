using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.DomainModel
{
    [Table("Designation")]
    public class Designation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DesignationID", Order = 0, TypeName = "int")]
        public int DesignationID { get; set; }
        [Required]
        [Column("DesignationName", Order = 1)]
        [MaxLength(150)]
        public string DesignationName { get; set; }
    }
}
