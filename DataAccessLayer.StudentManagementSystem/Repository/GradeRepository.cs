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
    public class GradeRepository:IGrade
    {
        private readonly MainDbContext _context;

        public GradeRepository(MainDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grade>> GetAllGrade()
        {
            try
            {
                return await _context.Grades.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Grade> GetGradeById(int id)
        {
            try
            {
                return await _context.Grades.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Grade> AddGrade(Grade grade)
        {
            try
            {
                _context.Grades.Add(grade);
                await _context.SaveChangesAsync();
                return grade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Grade> UpdateGrade(Grade grade, int id)
        {
            try
            {
                var existingGrade = await _context.Grades.FindAsync(id);
                if (existingGrade == null)
                {
                    return null;
                }

                existingGrade.GradeDate = grade.GradeDate;
                existingGrade.GradeValue = grade.GradeValue;

                _context.Grades.Update(existingGrade);
                await _context.SaveChangesAsync();
                return existingGrade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Grade> DeleteGrade(int id)
        {
            try
            {
                var gradeToDelete = await _context.Grades.FindAsync(id);
                if (gradeToDelete == null)
                {
                    return null;
                }

                _context.Grades.Remove(gradeToDelete);
                await _context.SaveChangesAsync();
                return gradeToDelete;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
