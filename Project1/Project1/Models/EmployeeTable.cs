//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    

    public partial class EmployeeTable
    {
        [Required(ErrorMessage = "Employee ID is required")]
        [Display(Name = "Employee Id")]

        public decimal EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Salary")]
        public Nullable<decimal> Salary { get; set; }

        [Display(Name = "Date Of Joining")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        //public Nullable<System.DateTime> DOJ { get; set; }
        public DateTime? DOJ { get; set; }

        [Display(Name = "Is Employee Active")]
        public Nullable<bool> IsActive { get; set; }

        [Display(Name = "Department")]
        public Nullable<decimal> DeptID { get; set; }
        


        public virtual DepartmentTable DepartmentTable { get; set; }
    }
}