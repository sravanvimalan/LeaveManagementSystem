using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.DomainModel
{
    [Table("Qualification")]
    public class Qualification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("QualificationID", Order = 0, TypeName = "int")]
        public int QualificationID { get; set; }
        [Column("QualificationName", Order = 1)]
        [MaxLength(150)]
        public string QualificationName { get; set; }

    }
}
