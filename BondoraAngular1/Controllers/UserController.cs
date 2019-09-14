using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BondoraAngular1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BondoraAngular1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private UserManager<UserModel> _userManager;

        List<UserModel> users = new List<UserModel>();
        private readonly ApplicationSettings _appSettings;

        public UserController(IOptions<ApplicationSettings> appSettings)
        {
            users.Add(new UserModel { Id = 1, FirstName = "Jane", LastName = "Doe", Address = "Somewhere in Tartu", Email = "jane@doe.com", Password = "janedoe1" });
            users.Add(new UserModel { Id = 2, FirstName = "John", LastName = "Doe", Address = "Somewhere in Tallinn", Email = "john@doe.com", Password = "johndoe2" });
            _appSettings = appSettings.Value;
        }


        // GET: api/User
        [HttpGet]
        [Authorize]
        public async Task<Object> Get()
        {
            string userEmail = User.Claims.First(c => c.Type == "UserEmail").Value;

            var optionalUser = users.FirstOrDefault(s => s.Email == userEmail);

            return new
            {
                optionalUser.Id,
                optionalUser.FirstName,
                optionalUser.LastName,
                optionalUser.Address,
                optionalUser.Email,
                optionalUser.Password
            };
        }

        // GET: api/User/5
        [HttpGet("/{email}/{password}", Name = "Get")]
        public UserModel Get(string email, string password)
        {
            return null;
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post(dynamic model)
        {
            var c = JsonConvert.DeserializeObject<UserModel>(model.ToString());

            var optionalUser = users.FirstOrDefault(s => s.Email == c.Email);
            

            if (optionalUser != null)
            {
                UserModel user = optionalUser;

                if (user.Password.Equals(c.Password))
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserEmail", user.Email)
                    }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();

                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);

                    return Ok(new { token });
                }

            }

            
                 
            return BadRequest(new { message = "Username or password is incorrect." });
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
