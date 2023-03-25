using community_institute_API.Data;
using community_institute_API.Data.config;
using community_institute_API.Errors;
using community_institute_API.EXtintion;
using community_institute_API.Midelware;
using community_institute_API.Serves;
using community_institute_API.Serves.IServes;
using community_institute_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace community_institute_API
{

    public class Program
        {
            public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
          
            
                builder.Services.AddSwaggerGen(c =>
                {
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT"
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
                });
            //allow any origin
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            //all endpoint controller API
            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();

            //allow DI for ItookenServes
            builder.Services.AddScoped<ITookenServiice, TokenServes>();
            builder.Services.AddScoped<IEnrollmentServes, EnrollmentService>();


            builder.Services.AddScoped<FileService>();
            builder.Services.Configure<ApiBehaviorOptions>(Options =>
            {
                //momdel state was not valid acthin context its contan the action active now 
                Options.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var errors = ActionContext.ModelState.Where(M => M.Value.Errors.Count() > 0)
                    //lisst of model has error  we use select meny
                    .SelectMany(M => M.Value.Errors).Select(E => E.ErrorMessage).ToArray();
                    var ErrorrRespons = new ApiValidation()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(ErrorrRespons);
                };
            });

            //adding ExptionMidelWare  piplin 
            
  
            



            builder.Services.AddDbContext<ComContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("oo")));


                builder.Services.IdentityServesiszz(builder.Configuration);


                //configer the identity
                // Add services to the container.
                builder.Services.AddAuthorization();


                var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExptionMidelWare>();

            app.UseRouting();
             app.UseStaticFiles();


            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
        
    }
}

