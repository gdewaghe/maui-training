using Microsoft.AspNetCore.Mvc;

namespace TrainingsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    [HttpGet(Name = "GetUser/{username}/{password}")]
    public string Get(string username, string password)
    {
        const string CorrectUsername = "guillaume";
        const string CorrectPassword = "123";
        if (username == CorrectUsername && password == CorrectPassword)
        {
            return CorrectUsername;
        }
        return "false";
    }
}
