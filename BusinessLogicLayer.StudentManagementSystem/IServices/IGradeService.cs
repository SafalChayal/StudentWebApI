using DataAccessLayer.StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.StudentManagementSystem.IServices
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>> GetAllGrade();
        Task<Grade> GetGradeById(int id);
        Task<Grade> AddGrade(Grade grade);
        Task<Grade> UpdateGrade(Grade grade, int id);
        Task<Grade> DeleteGrade(int id);

    }
}
