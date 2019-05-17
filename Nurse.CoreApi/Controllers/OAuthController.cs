using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nurse.IBusiness;
using Nurse.Token.Model;
using Nurse.VModel;


namespace Nurse.CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly JwtSettiing _jwtSetting;
        private readonly IMapper _mapper;
        public OAuthController(IMapper mapper, IUserBusiness userBusiness, IOptions<JwtSettiing> option)
        {
            _mapper = mapper;
            _userBusiness = userBusiness;
            _jwtSetting = option.Value;
        }
        [HttpPost]
        [AllowAnonymous]
        public  IActionResult Authenticate([FromBody]UserViewModel userDto)
        {
            //            var users = _userBusiness.GetEntityBySql("select * from T_Sys_User where UserCode='" + userDto.UserCode+"'");
            //            var user = users[0];
            //            if (user == null) return Unauthorized();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is a security key");
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience,"api"),
                    new Claim(JwtClaimTypes.Issuer,"http://localhost:44319"),
//                    new Claim(JwtClaimTypes.Id, user.ID.ToString()),
//                    new Claim(JwtClaimTypes.Name, user.Name)
                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new { token = tokenString });
            //            return Ok(new
            //            {
            //                access_token = tokenString,
            //                token_type = "Bearer",
            //                profile = new
            //                {
            //                    sid = user.Id,
            //                    name = user.Name,
            //                    auth_time = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
            //                    expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
            //                }
            //            });
        }

    }
}