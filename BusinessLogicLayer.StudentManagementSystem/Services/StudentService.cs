using BusinessLogicLayer.StudentManagementSystem.IService;
using DataAccessLayer.StudentManagementSystem.Interface;
using DataAccessLayer.StudentManagementSystem.Models;
using DataAccessLayer.StudentManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudent _studentRepository;

        public StudentService(IStudent studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            try
            {
                return await _studentRepository.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Student> GetStudentById(int id)
        {
            try
            {
                return await _studentRepository.GetStudentById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<Student> AddStudent(Student student)
        {
            try
            {
                return await _studentRepository.AddStudent(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<Student> UpdateStudent(Student student, int id)
        {
            try
            {
                return await _studentRepository.UpdateStudent(student, id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<Student> DeleteStudent(int id)
        {
            try
            {
                return await _studentRepository.DeleteStudent(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
