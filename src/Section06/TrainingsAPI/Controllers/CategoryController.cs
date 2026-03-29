using Microsoft.AspNetCore.Mvc;
using TrainingsAPI.Models;

namespace TrainingsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    [HttpGet(Name = "GetCategory")]
    public IEnumerable<Category> Get()
    {
        const string DollDescription = "Lorem ipsum dolor sit amet";
        Category[] categories =
        [
            new Category("Development", 10, "Learn programming.", "icon_dev.png"),
            new Category("Design", 20, DollDescription, "icon_design.png"),
            new Category("Business", 24, DollDescription, "icon_cible.png"),
            new Category("Management", 16, DollDescription, "icon_gestion.png"),
            new Category("Office", 2, DollDescription, "icon_ppt.png"),
            new Category("Photo", 8, DollDescription, "icon_photo.png"),
            new Category("Video", 10, DollDescription, "icon_video.png"),
            new Category("3D", 28, DollDescription, "icon_modelisation.png"),
        ];

        return categories;
    }
}
