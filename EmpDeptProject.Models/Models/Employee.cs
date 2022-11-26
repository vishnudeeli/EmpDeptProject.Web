using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmpDeptProject.Models.Models
{
    
        public class Employee
        {
            [Key]
            public int EmployeeId { get; set; }

            [Required]
            public string EmployeeName { get; set; }

            public float EmployeeSalary { get; set; }

            // Foreign key   
            [Display(Name = "Department")]
            public virtual int DepartmentId { get; set; }

            [ForeignKey("DepartmentId")]
            public virtual Department? Departments { get; set; }
     
        
    }
}
