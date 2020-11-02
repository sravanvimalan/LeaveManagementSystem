using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.DomainModel
{
    [Table("Gender")]
    public class Gender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("GenderID", Order = 0, TypeName = "int")]
        public int GenderID { get; set; }
        [Column("GenderName", Order = 1)]
        [MaxLength(150)]
        public string GenderName { get; set; }

    }
}
