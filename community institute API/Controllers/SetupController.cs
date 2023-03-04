using community_institute_API.Data;
using community_institute_API.Data.Domin;
using community_institute_API.DTOs;
using community_institute_API.Serves;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace community_institute_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly ComContext  _context;
        private readonly UserManager<Appuser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //logger
        private readonly ILogger<SetupController> _logger;
        private readonly ITookenServiice _tookenServes;

        public SetupController(ComContext context, UserManager<Appuser> userManager, RoleManager<IdentityRole> roleManager, ILogger<SetupController> logger, ITookenServiice tookenServes)


        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _tookenServes = tookenServes;
        }
        [HttpGet]
        [Route("ALLRole")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }
        [HttpPost]
        // rout crate role
        [Route("CreateRole")]

        public async Task<IActionResult>CreatRole(string name)
        {
            //cheek if role are exsest
            var roleExist = await _roleManager.RoleExistsAsync(name);
            if (!roleExist)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(name));
                if (roleResult.Succeeded)
                {
                    _logger.LogInformation($"Ther role {name} has been added sucssisfuly");
                    return Ok(new
                    {
                        R = $"the Role {name} added successfuly"
                    });
                    
                }
            }
            return BadRequest(new { error = "Role alredey Exist" });
            
        }
        [HttpGet]
        [Route("GetAllUsers")] 
        public async Task<IActionResult> GetAllusers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }


        






    }
}
