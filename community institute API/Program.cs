using community_institute_API.Data;
using community_institute_API.Data.config;
using community_institute_API.EXtintion;
using community_institute_API.Serves;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace community_institute_API
{
  
        public class Program
        {
            public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
          
            
                builder.Services.AddSwaggerGen();
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
//allow DI for ItookenServes
            builder.Services.AddScoped<ITookenServiice, TokenServes>();





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

            app.UseRouting();

            app.UseAuthorization();
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

