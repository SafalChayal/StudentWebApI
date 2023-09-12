using DataAccessLayer.StudentManagementSystem.Data;
using DataAccessLayer.StudentManagementSystem.Interface;
using DataAccessLayer.StudentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.StudentManagementSystem.Repository
{
    public class CourseRepository:ICourse
    {
        private readonly MainDbContext _context;

        public CourseRepository(MainDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCourse()
        {
            try
            {
                return await _context.Courses.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Course> GetCourseById(int id)
        {
            try
            {
                return await _context.Courses.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Course> AddCourse(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return course;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Course> UpdateCourse(Course course, int id)
        {
            try
            {
                var existingCourse = await _context.Courses.FindAsync(id);
                if (existingCourse == null)
                {
                    return null;
                }

                existingCourse.CourseName = course.CourseName;
                existingCourse.CourseDescription = course.CourseDescription;

                _context.Courses.Update(existingCourse);
                await _context.SaveChangesAsync();
                return existingCourse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Course> DeleteCourse(int id)
        {
            try
            {
                var courseToDelete = await _context.Courses.FindAsync(id);
                if (courseToDelete == null)
                {
                    return null;
                }

                _context.Courses.Remove(courseToDelete);
                await _context.SaveChangesAsync();
                return courseToDelete;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
