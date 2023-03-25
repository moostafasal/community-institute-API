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
        private readonly FileService _fileService;

        public ProfessorsController(ComContext context, UserManager<Appuser> userManager, ITookenServiice tooken, FileService fileService)


        {
            _context = context;
            _userManager = userManager;
            _tooken = tooken;
           _fileService = fileService;
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

        // uplode assinment using uplodingAssinmentDto ,cheek if the assinment is uploded before and cheek the user is a professor (has a professor role), using file uploder service to uplode the file to the server change defoult path to assingment folder in wwwroot
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Professors")]

        [HttpPost("assingment")]
        
        public async Task<ActionResult<Assignment>> PostAssignment([FromForm] UplodingAssignmentDto uplodingAssinmentDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            var professor = await _context.Professors.Include(p => p.clases).FirstOrDefaultAsync(p => p.UserId == userId);
            if (professor == null)
            {
                return NotFound("Professor not found");
            }

            var @class = professor.clases.FirstOrDefault(c => c.Id == uplodingAssinmentDto.ClassId);
            if (@class == null)
            {
                return NotFound("Class not found");
            }

            var assignment = await _context.Assignments.FirstOrDefaultAsync(a => a.classid == uplodingAssinmentDto.ClassId && a.Name == uplodingAssinmentDto.Name);
            if (assignment != null)
            {
                return BadRequest("Assignment already exists");
            }

            try
            {
                assignment = new Assignment
                {
                    Name = uplodingAssinmentDto.Name,
                    classid = uplodingAssinmentDto.ClassId,
                    proffid = uplodingAssinmentDto.userId,
                    Deadline = uplodingAssinmentDto.Deadline,

                    FileUrl = await _fileService.SaveFile(uplodingAssinmentDto.File, "wwwroot/Assignments")
                };
            }
            catch (Exception ex)
            {
                return BadRequest("Error saving file: " + ex.Message);
            }

            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            //return ok with massage 
            return Ok("Assignment added successfully");
        }

        //uplode class material using uplodingClassMaterialDto ,cheek if the class material is uploded before and cheek the user is a professor (has a professor role), using file uploder service to uplode the file to the server change defoult path to MaterialClass folder in wwwroot
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Professors")]
        [HttpPost("classMaterial")]
        public async Task<ActionResult<ClassMaterial>> PostClassMaterial([FromForm] UplodingClassMaterialDto uplodingClassMaterialDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            var professor = await _context.Professors.Include(p => p.clases).FirstOrDefaultAsync(p => p.UserId == userId);
            if (professor == null)
            {
                return NotFound("Professor not found");
            }

            var @class = professor.clases.FirstOrDefault(c => c.Id == uplodingClassMaterialDto.ClassId);
            if (@class == null)
            {
                return NotFound("Class not found");
            }

            var classMaterial = await _context.ClassMaterials.FirstOrDefaultAsync(a => a.Name == uplodingClassMaterialDto.Name);
            if (classMaterial != null)
            {
                return BadRequest("Class material already exists");
            }

            try
            {
                classMaterial = new ClassMaterial
                {
                    proffID = userId,
                    Name = uplodingClassMaterialDto.Name,
                    ClassId = uplodingClassMaterialDto.ClassId,
                    Url = await _fileService.SaveFile(uplodingClassMaterialDto.File, "wwwroot/MaterialClass"),
                    Description = uplodingClassMaterialDto.Description,
                    
                };
            }
            
            catch (Exception ex)
            {
                return BadRequest("Error saving file: " + ex.Message);
            }

            _context.ClassMaterials.Add(classMaterial);
            await _context.SaveChangesAsync();
            //return ok with massage 
            return Ok($"Class material added successfully{classMaterial.Name}");
        }






    }
}



