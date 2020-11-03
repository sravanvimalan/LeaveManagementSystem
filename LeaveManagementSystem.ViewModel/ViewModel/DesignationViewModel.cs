﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.ViewModel
{
    public class DesignationViewModel
    {
        public int? DesignationID { get; set; }
        [Required]
        public string DesignationName { get; set; }
    }
}
