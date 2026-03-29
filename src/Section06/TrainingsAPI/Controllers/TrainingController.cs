using Microsoft.AspNetCore.Mvc;
using TrainingsAPI.Models;

namespace TrainingsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TrainingController : ControllerBase
{
    [HttpGet(Name = "GetTrainings")]
    public IEnumerable<Training> Get()
    {
        const string DollDescription = "Lorem ipsum dolor sit amet";
        Training[] trainings =
        [
            new Training("C#", 100, DollDescription, "1.png", "Code"),
            new Training("Unity", 200, DollDescription, "2.png", "Unity"),
            new Training("Symfony", 150, DollDescription, "3.png", "Web"),
            new Training("C++", 120, DollDescription, "4.png", "Code"),
            new Training("Figma", 100, DollDescription, "5.png", "Design"),
            new Training("MAUI", 100, DollDescription, "6.png", "Code")
        ];

        return trainings;
    }
}
