using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GreentableApi.Models;
using GreentableApi.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using GreentableApi.Models.Response;

namespace GreentableApi.Helpers
{
    public class AuthwithJwt : AuthwithJwtBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        public AuthwithJwt(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
      public  static string GenerateJsonWebToken(Users user)
        {
           
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]{
                   new Claim(JwtRegisteredClaimNames.Sub, user.email),
                    new Claim(JwtRegisteredClaimNames.Email, user.email),
               }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            // return Ok(finaltoken);
              return tokenString;
        //     Success = 'jj',
        //     Token = tokenHandler.WriteToken(token)
            
        // }
            // Authresponse response = new Authresponse();
            // response.Token = tokenHandler.WriteToken(token);
            // return Ok(response);
        }
    }
}