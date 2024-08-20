using incidentMgtSystem.API.DTO;
using incidentMgtSystem.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace incidentMgtSystem.API.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class IncidentController : ControllerBase
{
   
    private readonly ILogger<AccountController> _logger;
    private readonly IncidentService _incService;

    //inject obj IncidentService
    public IncidentController(ILogger<AccountController> logger, IncidentService incService)
    {
        _logger = logger;
        //assign it here
        _incService = incService;
    }

    [HttpPost(Name = "Save")]
    //before calling this api authorize
    [Authorize]    
    public IncidentSaveAPIResponse Save([FromBody] IncidentSaveAPIRequest request)
    {
        //getuserid from toke
        var userId = HttpContext.User.FindFirst("Id").Value;
        //use that calling for saveincidents
        //get current loggedin user id
        var response = _incService.SaveIncident(request,Int32.Parse (userId));
        return response;


    }
}
