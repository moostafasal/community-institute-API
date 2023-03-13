using community_institute_API.Data.Domin;
using community_institute_API.Data;
using community_institute_API.DTOs;
using community_institute_API.Serves;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using community_institute_API.Errors;

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
        private readonly FileService _fileService;

        public Ahouth(ComContext context, UserManager<Appuser> userManager, RoleManager<IdentityRole> roleManager, ILogger<Ahouth> logger, ITookenServiice tokenServes, FileService fileService)

        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _tokenServes = tokenServes;
          _fileService = fileService;

        }


        [HttpPost("register/student")]

        public async Task<IActionResult> RegisterStudent([FromForm] StudentRegisterDto studentRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var Img = await _fileService.SaveFile(studentRegisterDto.Image);
                var url = _fileService.GetFileUrl(Img);
                var user = new Appuser
                {
                    UserName = studentRegisterDto.Email,
                    Email = studentRegisterDto.Email,
                    FullName = studentRegisterDto.Name,
                    AcademicId = studentRegisterDto.AcademicId,
                    ImgUrl = Img,
                    Role="student"
                    

                };
                //add user data to student table
                var student = new Student
                {
                    Name=studentRegisterDto.Name,
                    Age = studentRegisterDto.Age,
                    UserId = user.Id,
                    AcademicId=studentRegisterDto.AcademicId,
                   year  = studentRegisterDto.year,
                    GPA = studentRegisterDto.GPA,
                    ImageURL= Img,

                };
                var result = await _userManager.CreateAsync(user, studentRegisterDto.Password);

                if (result.Succeeded)
                {
                 _context.Students.Add(student);
                    await _context.SaveChangesAsync();
                    //save data in student table
                    
                    await _userManager.AddToRoleAsync(user, "Student");
                    var token = await _tokenServes.CreateToken(user, _userManager);
                    return Ok(new { token });
                }

                else
                {
                    return BadRequest(new ApiResponse(400, "Try Again same thing Error "));
                    
                }
                
            }
            else
            {
                return BadRequest(new ApiResponse(400));
                
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
                    //get student data
                    var student = await (from s in _context.Students
                                         where s.UserId == user.Id
                                         select new StudentDto
                                         {
                                             Name = s.Name,
                                             Age = s.Age,
                                             AcademicId = s.AcademicId,
                                             Photo = _fileService.GetFileUrl( s.ImageURL),
                                             Year = s.year,
                                            GPA  = s.GPA,
                                            
                                             

                                         }).FirstOrDefaultAsync();


                    return Ok(new { token, student });
                }
                    
                
                else
                {
                    return Unauthorized(new ApiResponse(401));
                }
            }
            else
            {
                return Unauthorized();
            }
        }


    }

}

