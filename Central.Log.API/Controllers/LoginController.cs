using Central.Log.API.Model;
using CentraLog.ApplicationCore.AppSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Central.Log.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Construtor

        private readonly IOptions<AppSettings> appSettings;
        public LoginController(IOptions<AppSettings> options)
        {
            appSettings = options;
        }
        #endregion


        [HttpPost("Authenticate")]
        public async Task<ActionResult<AuthenticateResultModel>> SignIn()
        {
            #region Header
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialsByes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialsByes).Split(':');
            string username = credentials[0];
            string password = credentials[1];

            #endregion

            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user != null)
            {
                return BuildToken(user);
            }
            else
            {
                return BadRequest("Não foi possivel fazer autenticação. Usuário ou senha inválidos");
            }

        }
        private AuthenticateResultModel BuildToken(AuthenticateResultModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                                     new SymmetricSecurityKey(key),
                                     SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;
            return user;
        }
        private AuthenticateResultModel HandleAuthenticateAsync(AuthenticationHeaderValue authHeaders)
        {
            var credentialsByes = Convert.FromBase64String(authHeaders.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialsByes).Split(':');
            string username = credentials[0];
            string password = credentials[1];

            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);//ToDo com o banco

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                                     new SymmetricSecurityKey(key),
                                     SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;
            return user;
        }

        private List<AuthenticateResultModel> _users = new List<AuthenticateResultModel>
        {
            new AuthenticateResultModel { Id = 1, FirstName = "Test", LastName = "User", Username = "centraLog", Password = "Teste@123" }
        };
    }
}
