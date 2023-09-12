using BusinessLogicLayer.StudentManagementSystem.IServices;
using DataAccessLayer.StudentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGrades()
        {
            try
            {
                var grades = await _gradeService.GetAllGrade();
                return Ok(grades);
            }
            catch
            {
                return StatusCode(500, "An error occurred while fetching grades.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGradeById(int id)
        {
            try
            {
                var grade = await _gradeService.GetGradeById(id);
                if (grade == null)
                {
                    return NotFound();
                }
                return Ok(grade);
            }
            catch
            {
                return StatusCode(500, "An error occurred while fetching the grade.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGrade([FromBody] Grade grade)
        {
            try
            {
                var addedGrade = await _gradeService.AddGrade(grade);
                return CreatedAtAction(nameof(GetGradeById), new { id = addedGrade.GradeId }, addedGrade);
            }
            catch
            {
                return StatusCode(500, "An error occurred while adding the grade.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrade(int id, [FromBody] Grade grade)
        {
            try
            {
                var updatedGrade = await _gradeService.UpdateGrade(grade, id);
                if (updatedGrade == null)
                {
                    return NotFound();
                }
                return Ok(updatedGrade);
            }
            catch
            {
                return StatusCode(500, "An error occurred while updating the grade.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            try
            {
                var deletedGrade = await _gradeService.DeleteGrade(id);
                if (deletedGrade == null)
                {
                    return NotFound();
                }
                return Ok(deletedGrade);
            }
            catch
            {
                return StatusCode(500, "An error occurred while deleting the grade.");
            }
        }
    }
}
