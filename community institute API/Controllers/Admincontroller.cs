using community_institute_API.Data;
using community_institute_API.Data.Domin;
using community_institute_API.DTOs;
using community_institute_API.Serves;
using community_institute_API.Serves.IServes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Helpers;

namespace community_institute_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admincontroller : ControllerBase
    {
        private readonly ComContext _context;
        private readonly UserManager<Appuser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //logger
        private readonly ILogger<Admincontroller> _logger;
        private readonly ITookenServiice _tokenServes;
        private readonly FileService _fileService;

        public Admincontroller(ComContext context, UserManager<Appuser> userManager, RoleManager<IdentityRole> roleManager, ILogger<Admincontroller> logger, ITookenServiice tokenServes, FileService fileService)

        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _tokenServes = tokenServes;
            _fileService = fileService;
        }
        [HttpPost]//route
        [Route("register/admin")]

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminDto registerAdminDto)
        {
            // Check if user already exists
            var userExists = await _userManager.FindByEmailAsync(registerAdminDto.Email);
            if (userExists != null)
            {
                return BadRequest("User with this email already exists");
            }

            // Create a new user with the given email and password
            var user = new Appuser
            {
                UserName = registerAdminDto.Username,
                FullName = registerAdminDto.Username,
                AcademicId = "111111A",
                Email = registerAdminDto.Email
            };
            var result = await _userManager.CreateAsync(user, registerAdminDto.Password);
            var token = await _tokenServes.CreateToken(user, _userManager);


            // Check if user creation was successful
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Add the admin role to the user
            var roleResult = await _userManager.AddToRoleAsync(user, "Admin");
            if (!roleResult.Succeeded)
            {
                return BadRequest(roleResult.Errors);
            }


            // Create a new admin entity and add it to the database
            var admin = new Admin
            {
                Name = registerAdminDto.Username,
                CreatedAt = DateTime.Now,

                UserId = user.Id

            };
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();




            return Ok(new { message = "Admin registered successfully", token });

        }
        [HttpPost("admin/login")]
        public async Task<IActionResult> AdminLogin(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                {
                    var token = await _tokenServes.CreateToken(user, _userManager);

                    return Ok(new
                    {
                        id = user.Id,
                        username = user.UserName,
                        email = user.Email,
                        roles = roles,
                        token = token
                    });
                }
            }

            return Unauthorized(new { message = "Invalid login attempt." });
        }

        //creat proffesor acoont 
        //brear token aouthrize 






        //add defoult Jwt berar token aohtrize 

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost("professor/register")]
        public async Task<IActionResult> RegisterProfessor([FromForm] ProfessorAndTAsRegistrationDto professorRegistrationDto)
        {
            // check if user has admin role
            if (!User.IsInRole("Admin"))
            {
                return Unauthorized("You are not authorized to access this resource.");
            }
            var ImgUrl = await _fileService.SaveFile(professorRegistrationDto.Image);

            // create a new user with the given email and password
            var user = new Appuser
            {
                Email = professorRegistrationDto.Email,
                UserName = professorRegistrationDto.Email.Split('@')[0],
                FullName = professorRegistrationDto.Name,
                ImgUrl = ImgUrl,
                Role = "professor",
                AcademicId = professorRegistrationDto.AcademicId,



            };

            var result = await _userManager.CreateAsync(user, professorRegistrationDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            await _userManager.AddToRoleAsync(user, "Professors");

            // create a new Professor entity with the given properties
            var professor = new Professors
            {
                Name = professorRegistrationDto.Name,
                AcademicId = professorRegistrationDto.AcademicId,
                ImgUrl = ImgUrl,
                UserId = user.Id,
            };

            await _context.Professors.AddAsync(professor);
            await _context.SaveChangesAsync();

            return Ok("Professor registration successful.");
        }

        //add suject endpoint

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost("subject/add")]
        public async Task<IActionResult> AddSubject([FromBody] SubjectDto subjectDto)
        {
            // check if user has admin role
            if (!User.IsInRole("Admin"))
            {
                return Unauthorized("You are not authorized to access this resource.");
            }

            // create a new subject entity with the given properties
            var subject = new Subject
            {
                Name = subjectDto.Name,
                Code = subjectDto.Code,
                Units = subjectDto.Units,
                year = subjectDto.year,
            };

            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();

            return Ok("Subject added successfully.");

        }

        //delet subject endpoint
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("subject/delete/{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            // check if user has admin role
            if (!User.IsInRole("Admin"))
            {
                return Unauthorized("You are not authorized to access this resource.");
            }

            // get the subject with the given id
            var subject = await _context.Subjects.FindAsync(id);

            // check if the subject exists
            if (subject == null)
            {
                return NotFound("Subject not found.");
            }

            // delete the subject
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return Ok("Subject deleted successfully.");
        }

        //creat group end point 

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost("group/add")]
        public async Task<IActionResult> AddGroup([FromBody] GroupDto groupDto)
        {
            // check if user has admin role
            if (!User.IsInRole("Admin"))
            {
                return Unauthorized("You are not authorized to access this resource.");
            }

            // create a new group entity with the given properties
            var group = new Groups
            {

                GroupName = groupDto.GroupName,
                Number = groupDto.Number



            };

            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();

            return Ok("Group added successfully.");
        }


        //end point for add classes and assing to group and subject and profesor 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost("class/add")]
        public async Task<IActionResult> AddClass([FromBody] ClassDto classDto)
        {
            // check if user has admin role
            if (!User.IsInRole("Admin"))
            {
                return Unauthorized("You are not authorized to access this resource.");
            }

            // create a new group entity with the given properties
            var classes = new clases
            {

                Name = classDto.Name,
                GroupId = classDto.GroupId,
                SubjectId = classDto.SubjectId,
                ProfessorId = classDto.ProfessorId,
                Description = classDto.description,




            };

            await _context.clases.AddAsync(classes);
            await _context.SaveChangesAsync();

            return Ok("Class added successfully.");


















        }
    }
}
