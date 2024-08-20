/*using incidentMgtSystem.API.DTO;
using incidentMgtSystem.API.Models;
using incidentMgtSystem.API.Respositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace incidentMgtSystem.API.Services
{
    public class AccountService
    {
        //wanted to call func from account repo
        public readonly AccountRepo _accountRepo;
        public readonly IConfiguration _configuration;

        public AccountService(AccountRepo accountRepo,IConfiguration configuration) {
            _accountRepo = accountRepo;
            _configuration = configuration;
        }

        //this api gets call from controller
        public LoginResponse validateLogindetails(LoginRequest loginRequest)
        {
            //if user==null then loginresponse = false-->invalid .if success
            //if not null -->generate token
            var user = _accountRepo.validateLoginDetails(loginRequest.username, loginRequest.password);
            LoginResponse response = new LoginResponse();
            if (user == null)
            {
                response.Success= false;
                response.ErrorMessage = "Invalid Username and Password";
            }
            else
            {
                //call GenerateToken method
                var token = GenerateToken(loginRequest.username,user.User.email);
                response.JwtToken = token;
            }
            //this token return as api res
            return response;

        }

        //to genarate token -->use class symmentric seq.key
        //-->encoding.UTF8.GetBytes -->pass seq key
        // seq.key get from configuration ---> add confguration dependency
        //add to _configuration 
        private string GenerateToken(string username, string email, string Id)
        *//*private string GenerateToken(User user)*//*
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //creating claims -->payload --> payload want to store inside jwt token add them as claims 

            var claims = new[]
            {
            *//*new Claim(ClaimTypes.Name,username)*//*
            new Claim(ClaimTypes.Name,username),
            new Claim("email",email),
            new Claim("Id",Id)
            *//*new Claim(ClaimTypes.Name, user.email),
            new Claim("Id",user.Id.ToString()),*//*
        };

            //creating token
            var token = new JwtSecurityToken(
                //reading from appsetting.json files
                //parameter will be issuer -->get from configuration from jwt section
                //Audience -->who can use my token
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireInMinutes"])),
                signingCredentials: credentials

                );


            *//*return new JwtSecurityTokenHandler.WriteToken(token);*//*
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        
    }

}
*/


using incidentMgtSystem.API.DTO;
using incidentMgtSystem.API.Models;
using incidentMgtSystem.API.Respositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace incidentMgtSystem.API.Services
{
    public class AccountService
    {
        //wanted to call func from account repo
        public readonly AccountRepo _accountRepo;
        public readonly IConfiguration _configuration;


        //this api gets call from controller
        public AccountService(AccountRepo accountRepo, IConfiguration configuration)
        {
            _accountRepo = accountRepo;
            _configuration = configuration;
        }

        public LoginResponse validateLogindetails(LoginRequest loginRequest)
        {
            //if user==null then loginresponse = false-->invalid .if success
            //if not null -->generate token
            var user = _accountRepo.validateLoginDetails(loginRequest.username, loginRequest.password);
            LoginResponse response = new LoginResponse();
            if (user == null)
            {
                response.Success = false;
                response.ErrorMessage = "Invalid Username and Password";
            }
            else
            {
                //call GenerateToken method
                var token = GenerateToken(loginRequest.username, user.User.email, user.User.Id.ToString());
                response.JwtToken = token;
            }
            //this token return as api res
            return response;
        }

        //to genarate token -->use class symmentric seq.key
        //-->encoding.UTF8.GetBytes -->pass seq key
        // seq.key get from configuration ---> add confguration dependency
        //add to _configuration
        private string GenerateToken(string username, string email, string Id)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //creating claims -->payload --> payload want to store inside jwt token add them as claims 

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim("email", email),
                new Claim("Id", Id)
            };

            //creating token
            var token = new JwtSecurityToken(
                //reading from appsetting.json files
                //parameter will be issuer -->get from configuration from jwt section
                //Audience -->who can use my token
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
