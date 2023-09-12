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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                var courses = await _courseService.GetAllCourse();
                return Ok(courses);
            }
            catch
            {
                return StatusCode(500, "An error occurred while fetching courses.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            try
            {
                var course = await _courseService.GetCourseById(id);
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch
            {
                return StatusCode(500, "An error occurred while fetching the course.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            try
            {
                var addedCourse = await _courseService.AddCourse(course);
                return CreatedAtAction(nameof(GetCourseById), new { id = addedCourse.CourseId }, addedCourse);
            }
            catch
            {
                return StatusCode(500, "An error occurred while adding the course.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            try
            {
                var updatedCourse = await _courseService.UpdateCourse(course, id);
                if (updatedCourse == null)
                {
                    return NotFound();
                }
                return Ok(updatedCourse);
            }
            catch
            {
                return StatusCode(500, "An error occurred while updating the course.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                var deletedCourse = await _courseService.DeleteCourse(id);
                if (deletedCourse == null)
                {
                    return NotFound();
                }
                return Ok(deletedCourse);
            }
            catch
            {
                return StatusCode(500, "An error occurred while deleting the course.");
            }
        }
    }
}
