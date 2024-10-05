using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrackYourWorkout.Configurations;
using TrackYourWorkout.DTOs;

namespace TrackYourWorkout.Controllers
{
    /// <summary>
    /// api endpoint for user's login CRUD
    /// </summary>

    [Route("api/users")]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly JWTSettingsConfiguration _jwtOptions;
        public AuthController(IOptions<JWTSettingsConfiguration> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {

            // just some dummy data. will use real data later
            // when we connect to database
            var attemptLoginUser = new
            {
                userId = "userId",
                name = loginDTO.Name,
                password = loginDTO.Password,
            };

            if (attemptLoginUser.name == "abc" && attemptLoginUser.password == "pw")
            {

                // new user claims
                var claims = new[]
                {
                    new Claim("userId", attemptLoginUser.userId),
                    new Claim("name", attemptLoginUser.name),
                };

                // generate new token with key, signin, claims 
                // token expiry time is 60 minutes from the creation date
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _jwtOptions.Issuer,
                    _jwtOptions.Audience,
                    claims,
                    expires:DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn
                );
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);   

                // return token. User will use this token to access protected rotues
                return Ok(new
                {
                    attemptLoginUser.userId,
                    attemptLoginUser.name,
                    token = tokenValue
                });
            }
            return Unauthorized();
        }
    }
}
