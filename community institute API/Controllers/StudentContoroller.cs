using community_institute_API.Data;
using community_institute_API.Data.Domin;
using community_institute_API.DTOs;
using community_institute_API.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace community_institute_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class StudentContoroller: ControllerBase
    {
        public StudentContoroller(ComContext context  )
        {
            _Context = context;
        }

        public ComContext _Context { get; }

        [Authorize(Roles = "Student")]
        [HttpGet("me")]
        
        public async Task<ActionResult<StudentDto>> GetStudent()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var student = await _Context.Students
                .Include(s => s.User)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.clases)
                        .ThenInclude(c => c.Subject)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Grades)
                .Include(s => s.Enrollments)
                .FirstOrDefaultAsync(s => s.UserId == userId);

            if (student == null)
            {
                return BadRequest(new ApiResponse(404));
            }

            var studentDto = new StudentDto
            {
                Name = student.Name,
                Email = student.User.Email,
                Age = student.Age,
                Year = student.year,
                AcademicId = student.AcademicId,
                Enrollments = student.Enrollments.Select(e => new EnrollmentDto
                {
                    CourseName = e.clases.Subject.Name,
                    IsEnrolled = e.states,
                    Grade = e.Grades.final,
                }).ToList()
            };
            

            return studentDto;
        }



    }
}
