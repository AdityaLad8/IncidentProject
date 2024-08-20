using incidentMgtSystem.API.DTO;
using incidentMgtSystem.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace incidentMgtSystem.API.Controllers;



//add dependencies into the program.cs file
//appsetting file -->add jwt 
[ApiController]
[Route("[controller]/[action]")]
public class AccountController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<AccountController> _logger;
    
    //add dependency of service class
    private readonly AccountService _accontService;
    
    public AccountController(ILogger<AccountController> logger,AccountService accountService)
    {
        _logger = logger;
        _accontService = accountService;
    }

    [HttpPost(Name = "Login")]
    //frombody --> info pass as request body
    public LoginResponse Login([FromBody]LoginRequest loginRequest)
    {
        // call service method
        LoginResponse response = _accontService.validateLogindetails(loginRequest);
        return response;


    }
}
