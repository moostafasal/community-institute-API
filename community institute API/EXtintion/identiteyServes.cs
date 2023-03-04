using community_institute_API.Data;
using community_institute_API.Data.Domin;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace community_institute_API.EXtintion
{
    public static class identiteyServes
    {
        public static IServiceCollection IdentityServesiszz(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddIdentity<Appuser , IdentityRole>(op =>
            {
                //op.Password.RequireLowercase
            })
            .AddEntityFrameworkStores<ComContext>();
            Services.AddAuthentication(/*JwtBearerDefaults.AuthenticationScheme*/ options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:validAudience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]))





                };
            });

            return Services;

        }
    }
}
