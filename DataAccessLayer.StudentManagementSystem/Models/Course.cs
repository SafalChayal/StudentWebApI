using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.StudentManagementSystem.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string ? CourseName { get; set; }

        [Required]
        public string ? CourseDescription { get; set; }

        public List<Grade> ? Grades { get; set; }
    }
}
