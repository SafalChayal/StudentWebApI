using BusinessLogicLayer.StudentManagementSystem.IServices;
using DataAccessLayer.StudentManagementSystem.Interface;
using DataAccessLayer.StudentManagementSystem.Models;
using DataAccessLayer.StudentManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.StudentManagementSystem.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourse _courseRepository;

        public CourseService(ICourse courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllCourse()
        {
            try
            {
                return await _courseRepository.GetAllCourse();
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
                return await _courseRepository.GetCourseById(id);
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
                return await _courseRepository.AddCourse(course);
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
                return await _courseRepository.UpdateCourse(course, id);
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
                return await _courseRepository.DeleteCourse(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
