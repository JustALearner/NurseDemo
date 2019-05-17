using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nurse.CoreApi.Model;
using Nurse.Token.Model;
using Nurse.VModel;

namespace Nurse.CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtSettiing _jwtsetting;

        public TokenController(IOptions<JwtSettiing> option)
        {
            _jwtsetting = option.Value;
        }
        [HttpPost]
        public async Task<IActionResult> GenToken(UserModel model)
        { 
            //get username and pwd from this model ,then get data from db 
            //var user = _context.Users.FirstOrDefault(l => l.Name == model.Name && l.Pwd == model.PassWord);
            //If there is data in the database
            var user = new UserModel() { ID = 1, Email = "example@live.com", Name = "tester", PassWord = "123456" };
            //if user null ,return
            if (user == null) return Unauthorized();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsetting.SecretKey);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience,_jwtsetting.Audience.ToString()),
                    new Claim(JwtClaimTypes.Issuer,_jwtsetting.Issuer.ToString()),
                    new Claim(JwtClaimTypes.Id, user.ID.ToString()),
                    new Claim(JwtClaimTypes.Name, user.Name)
                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                access_token = tokenString,
                token_type = "Bearer",
                profile = new
                {
                    sid = user.ID,
                    name = user.Name,
                    auth_time = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
                    expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
                }
            });
        }
    }
}