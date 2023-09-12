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
    public class StudentRepository : IStudent
    {
        private readonly MainDbContext _context;

        public StudentRepository(MainDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            try
            {
                return await _context.Studets.ToListAsync();
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
                return await _context.Studets.FindAsync(id);
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
                _context.Studets.Add(student);
                await _context.SaveChangesAsync();
                return student;
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
                var existingStudent = await _context.Studets.FindAsync(id);
                if (existingStudent == null)
                {
                    return null; 
                }

                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.ContactInfo = student.ContactInfo;
                existingStudent.DOB = student.DOB;
                existingStudent.EnrollmentDate = student.EnrollmentDate;





                _context.Studets.Update(existingStudent);
                await _context.SaveChangesAsync();
                return existingStudent;
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
                var studentToDelete = await _context.Studets.FindAsync(id);
                if (studentToDelete == null)
                {
                    return null; 
                }

                _context.Studets.Remove(studentToDelete);
                await _context.SaveChangesAsync();
                return studentToDelete;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
