using community_institute_API.Data.Domin;
using community_institute_API.Data;
using community_institute_API.DTOs;
using community_institute_API.Serves;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Helpers;

namespace community_institute_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ahouth : ControllerBase
    {

        private readonly ComContext _context;
        private readonly UserManager<Appuser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //logger
        private readonly ILogger<Ahouth> _logger;
        private readonly ITookenServiice _tokenServes;

        public Ahouth(ComContext context, UserManager<Appuser> userManager, RoleManager<IdentityRole> roleManager, ILogger<Ahouth> logger, ITookenServiice tokenServes)

        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _tokenServes = tokenServes;
        }


        [HttpPost("register/student")]

        public async Task<IActionResult> RegisterStudent([FromForm] StudentRegisterDto studentRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var user = new Appuser
                {
                    UserName = studentRegisterDto.Email,
                    Email = studentRegisterDto.Email,
                    FullName = studentRegisterDto.Name,
                    AcademicId = studentRegisterDto.AcademicId,
                    ImgUrl = await FileHelper.SaveFile(studentRegisterDto.Image),
                    

                };
                //add user data to student table
                var student = new Student
                {
                    Age = studentRegisterDto.Age,
                    UserId = user.Id,
                   year  = studentRegisterDto.year,
                    GPA = studentRegisterDto.GPA,

                };

                var result = await _userManager.CreateAsync(user, studentRegisterDto.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Student");
                    var token = await _tokenServes.CreateToken(user, _userManager);
                    return Ok(new { token });
                }

                else
                {
                    return BadRequest(result.Errors);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        //student login end point 
        [HttpPost("login/student")]
        public async Task<IActionResult> LoginStudent([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (result)
                {
                    var token = await _tokenServes.CreateToken(user, _userManager);
                    return Ok(new { token });
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }


    }

}

