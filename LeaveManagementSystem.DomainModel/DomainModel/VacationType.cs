using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.DomainModel
{
    [Table("VacationType")]
    public class VacationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("VacationTypeID", Order = 0, TypeName = "int")]
        public int VacationTypeID { get; set; }
        [Column("VacationName", Order = 1)]
        [MaxLength(150)]
        public string VacationName { get; set; }
    }
}
