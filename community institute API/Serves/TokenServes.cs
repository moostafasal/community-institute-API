using community_institute_API.Data.Domin;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace community_institute_API.Serves
{
    public class TokenServes : ITookenServiice
    {
        public IConfiguration Configuration { get; }
        public TokenServes(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        


        public async Task<string> CreateToken(Appuser user, UserManager<Appuser> userManager)
        {
            //privet claim (UsrtDefind)
            var aouthClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),

            };
            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
                aouthClaim.Add(new Claim(ClaimTypes.Role, role));

            //secret key
            var aouthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"]));


            var token = new JwtSecurityToken(
                issuer: Configuration["JWT:ValidIssuer"],
                audience: Configuration["JWT:validAudience"],
                //expires: Configuration["JWT:DuratiinInDay"]
                expires: DateTime.Now.AddDays(double.Parse(Configuration["JWT:DuratiinInDay"])),
                claims: aouthClaim,
                signingCredentials: new SigningCredentials(aouthKey, SecurityAlgorithms.HmacSha256)



                );
            return new JwtSecurityTokenHandler().WriteToken(token);



        }
    }


}
