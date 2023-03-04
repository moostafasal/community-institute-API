using community_institute_API.Data;
using community_institute_API.Data.Domin;
using community_institute_API.DTOs;
using community_institute_API.Serves;
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

        public Admincontroller(ComContext context, UserManager<Appuser> userManager, RoleManager<IdentityRole> roleManager, ILogger<Admincontroller> logger, ITookenServiice tokenServes)

        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _tokenServes = tokenServes;
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
                FullName= registerAdminDto.Username,
                AcademicId="111111A",
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
        public async Task<IActionResult> RegisterProfessor([FromForm] ProfessorAndTAsRegistrationDto professorRegistrationDto )
        {
            // check if user has admin role
            if (!User.IsInRole("Admin"))
            {
                return Unauthorized("You are not authorized to access this resource.");
            }

            // create a new user with the given email and password
            var user = new Appuser
            {
                Email = professorRegistrationDto.Email,
                UserName = professorRegistrationDto.Name,
                ImgUrl = await FileHelper.SaveFile(professorRegistrationDto.Image)
                


            };

            var result = await _userManager.CreateAsync(user, professorRegistrationDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // create a new Professor entity with the given properties
            var professor = new Professors
            {
                Name = professorRegistrationDto.Name,
                AcademicId = professorRegistrationDto.AcademicId,
                UserId = user.Id
            };

            await _context.Professors.AddAsync(professor);
            await _context.SaveChangesAsync();

            return Ok("Professor registration successful.");
        }

    }
}
