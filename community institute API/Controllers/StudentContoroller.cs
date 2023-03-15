using community_institute_API.Data;
using community_institute_API.Data.Domin;
using community_institute_API.DTOs;
using community_institute_API.Errors;
using community_institute_API.Serves.IServes;
using community_institute_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        private readonly ComContext _context;
        private readonly IEnrollmentServes _enrollment;
        private readonly UserManager<Appuser> _userManager;


        public StudentContoroller(ComContext context,IEnrollmentServes enrollment ,UserManager<Appuser> userManager)
        {
            _context = context;
            _enrollment = enrollment;
           _userManager = userManager;
        }


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "student")]
        //[HttpGet("me")]
        
        //public async Task<ActionResult<StudentDto>> GetStudent()
        //{
        //    //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    //var student = await _context.Students
        //    //    .Include(s => s.User)
        //    //    .Include(s => s.Enrollments)
        //    //        .ThenInclude(e => e.clases)
        //    //            .ThenInclude(c => c.Subject)
        //    //    .Include(s => s.Enrollments)
        //    //        .ThenInclude(e => e.Grades)
        //    //    .Include(s => s.Enrollments)
        //    //    .FirstOrDefaultAsync(s => s.UserId == userId);

        //    if (student == null)
        //    {
        //        return BadRequest(new ApiResponse(404));
        //    }

        //    var studentDto = new StudentDto
        //    {
        //        Name = student.Name,
        //        Email = student.User.Email,
        //        Age = student.Age,
        //        Year = student.year,
        //        AcademicId = student.AcademicId,
        //        Enrollments = student.Enrollments.Select(e => new EnrollmentDto
        //        {
        //            CourseName = e.clases.Subject.Name,
        //            IsEnrolled = e.states,
        //            Grade = e.Grades.final,
        //        }).ToList()
        //    };
            

        //    return studentDto;
        //}

        // student enrollmet to class 

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "student")]

        [HttpPost("{classId}/enroll")]
        public async Task<IActionResult> EnrollInClass(int classId)
        {
            // Get the current user's id
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Find the corresponding student in the database
            var student = await _context.Students.FirstOrDefaultAsync(s => s.UserId == userId);

            // If the student isn't found, return a 404 Not Found response
            if (student == null)
            {
                return NotFound(new ApiResponse(404, $"EntTa meen {userId}"));
            }

            // Attempt to enroll the student in the specified class
            var enrollmentAdded = await _enrollment.AddEnrollmentAsync(student.Id, classId);

            // If the enrollment was added successfully, return a 201 Created response
            if (enrollmentAdded)
            {
                return Ok(new {massge="you have reqoust to join into class "});
            }
            // Otherwise, return a 400 Bad Request response
            else
            {
                return BadRequest(new ApiResponse(400));
            }
        }


    }
}
