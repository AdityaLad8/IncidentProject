using incidentMgtSystem.API.DTO;
using incidentMgtSystem.API.Models;
using incidentMgtSystem.API.Respositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace incidentMgtSystem.API.Services
{
    public class IncidentService
    {
        //wanted to call func from account repo
        public readonly IncidentRepo _incRepo;
        public readonly IConfiguration _configuration;

        public IncidentService(IncidentRepo incRepo, IConfiguration configuration)
        {
            _incRepo = incRepo;
            _configuration = configuration;
        }

        //here we get incidentreqobj
        //call this function from controller
        public IncidentSaveAPIResponse SaveIncident(IncidentSaveAPIRequest request ,int userId)
        {
            //pass all thing from request to incidentMaster
            IncidentMaster incidentMaster= new IncidentMaster()
            {
                CityId = request.CityId,
                CreatedDate = DateTime.Now,
                Description = request.Description,
                Priority= request.Priority,
                //get claims from jwt token for requesterid
                RequesterId= userId,
                Status = Enums.IncidentStatus.New,
                Symptoms= request.Symptoms,
                TenantId= request.TenantId,
                Urgency=request.Urgency,
            };
            

            var result = _incRepo.SaveIncident(incidentMaster);
            IncidentSaveAPIResponse response = new IncidentSaveAPIResponse();
            //if successfully stored in db return true
            //if not true throw error message
            if (!result)
            {
                response.Success = false;
                response.ErrorMessage = "Some error occured at server side";
            }
            else
            {
                response.Success = true;
            }
            //this token return as api res
            return response;

        }

        //to genarate token -->use class symmentric seq.key
        //-->encoding.UTF8.GetBytes -->pass seq key
        // seq.key get from configuration ---> add confguration dependency
        //add to _configuration 
        private string GenerateToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //creating claims -->payload --> payload want to store inside jwt token add them as claims 

            var claims = new[]
            {
            new Claim(ClaimTypes.Name,username)
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


            /*return new JwtSecurityTokenHandler.WriteToken(token);*/
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }

}

