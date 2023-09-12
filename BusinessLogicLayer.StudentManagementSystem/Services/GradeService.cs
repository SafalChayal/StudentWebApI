using BusinessLogicLayer.StudentManagementSystem.IServices;
using DataAccessLayer.StudentManagementSystem.Interface;
using DataAccessLayer.StudentManagementSystem.Models;
using DataAccessLayer.StudentManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.StudentManagementSystem.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGrade _gradeRepository;

        public GradeService(IGrade gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<IEnumerable<Grade>> GetAllGrade()
        {
            try
            {
                return await _gradeRepository.GetAllGrade();
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
                return await _gradeRepository.GetGradeById(id);
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
                return await _gradeRepository.AddGrade(grade);
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
                return await _gradeRepository.UpdateGrade(grade, id);
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
                return await _gradeRepository.DeleteGrade(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
