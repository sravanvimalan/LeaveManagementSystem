using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.DomainModel
{
    [Table("Experience")]
    public class Experience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ExperienceID", Order = 0, TypeName = "int")]
        public int ExperienceID { get; set; }
        [Column("CompanyName", Order = 1)]
        [MaxLength(150)]
        public string CompanyName { get; set; }
        [Column("JobRole", Order = 2)]
        [MaxLength(150)]
        public string JobRole { get; set; }
        [Column("StartDate", Order = 3, TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column("EndDate", Order = 4, TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
    }
}
