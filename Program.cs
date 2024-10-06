using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrackYourWorkout.Configurations;
using TrackYourWorkout.Context;

namespace TrackYourWorkout
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;
            builder.Services.AddControllers();
            builder.Services.Configure<JWTSettingsConfiguration>(
                config.GetSection("JWTSettings")
            );
            builder.Services.Configure<DBSettingsConfiguration>(
                config.GetSection("ConnectionStrings")
            );

            builder.Services.AddSingleton<DapperContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                // 
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                // generate token using these parameters
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config["JWTSettings:Issuer"],
                    ValidAudience = config["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTsettings:Key"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
            var app = builder.Build();


            //has to be logged in first
            app.UseAuthentication();

            // then you can be granted access to resources
            app.UseAuthorization();

            // then map controllers
            app.MapControllers();

            app.Run();
        }
    }
}
