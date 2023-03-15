using community_institute_API.Data;
using community_institute_API.Data.Domin;
using community_institute_API.DTOs;
using community_institute_API.Errors;
using community_institute_API.Serves;
using community_institute_API.Serves.IServes;
using community_institute_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace community_institute_API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Professors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly ComContext _context;
        private readonly UserManager<Appuser> _userManager;
        private readonly ITookenServiice _tooken;

        public ProfessorsController(ComContext context, UserManager<Appuser> userManager, ITookenServiice tooken)
        {
            _context = context;
            _userManager = userManager;
            _tooken = tooken;
        }
        [HttpGet("classes/enrollments")]

        public async Task<ActionResult<IEnumerable<EnrollmentReqoustDto>>> GetEnrollmentRequestsByProfessor()
        {
            // Get the professor's user id from the authentication token
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Find the corresponding professor in the database
            if (userId == null)
            {
                return Unauthorized();
            }

            var professor = await _context.Professors.Include(p => p.clases).ThenInclude(c => c.Enrollments).ThenInclude(e => e.Student)
                                                     .FirstOrDefaultAsync(p => p.UserId == userId);
            if (professor == null)
            {
                return NotFound("Professor not found");
            }

            var enrollmentRequests = new List<EnrollmentReqoustDto>();

            foreach (var @class in professor.clases)
            {
                var requests = @class.Enrollments.Select(e => new EnrollmentReqoustDto
                {
                    StudentName = e.Student.Name,
                    ClassName = @class.Name,
                    GroupNumber = @class.GroupId,
                });

                enrollmentRequests.AddRange(requests);
            }

            return Ok(enrollmentRequests);
        }



        [HttpPost("login/Proff")]
        public async Task<IActionResult> ProffesorLogin([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (result)
                {
                    var token = await _tooken.CreateToken(user, _userManager);
                    return Ok(new { token });
                }
                else
                {
                    return BadRequest(new ApiResponse(401));
                }
            }
            else
            {
                return BadRequest(new { error = "User not found" });
            }
        }






    }
}



