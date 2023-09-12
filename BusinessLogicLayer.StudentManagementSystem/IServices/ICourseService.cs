using DataAccessLayer.StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.StudentManagementSystem.IServices
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCourse();
        Task<Course> GetCourseById(int id);
        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Course course, int id);
        Task<Course> DeleteCourse(int id);
    }
}
