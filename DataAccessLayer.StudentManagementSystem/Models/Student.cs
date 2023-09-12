using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.StudentManagementSystem.Models
{
   public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string ? FirstName { get; set; }

        [Required]
        public string ? LastName { get; set; }

        [Required]
        public string ? ContactInfo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public List<Grade> ?Grades { get; set; }
    }

}

