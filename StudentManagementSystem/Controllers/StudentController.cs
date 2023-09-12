using BusinessLogicLayer.StudentManagementSystem.IService;
using DataAccessLayer.StudentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudents();
                return Ok(students);
            }
            catch 
            {
                return StatusCode(500, "An error occurred while fetching students.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _studentService.GetStudentById(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch 
            {
                return StatusCode(500, "An error occurred while fetching the student.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            try
            {
                var addedStudent = await _studentService.AddStudent(student);
                return CreatedAtAction(nameof(GetStudentById), new { id = addedStudent.StudentId }, addedStudent);
            }
            catch 
            {
                return StatusCode(500, "An error occurred while adding the student.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            try
            {
                var updatedStudent = await _studentService.UpdateStudent(student, id);
                if (updatedStudent == null)
                {
                    return NotFound();
                }
                return Ok(updatedStudent);
            }
            catch 
            {
                return StatusCode(500, "An error occurred while updating the student.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var deletedStudent = await _studentService.DeleteStudent(id);
                if (deletedStudent == null)
                {
                    return NotFound();
                }
                return Ok(deletedStudent);
            }
            catch 
            {
                return StatusCode(500, "An error occurred while deleting the student.");
            }
        }
    }
}
