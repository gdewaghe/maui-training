namespace Trainings.Models;

public class Training
{
    public string Title { get; set; }

    public int Price { get; set; }

    public string Description { get; set; }

    public string Image { get; set; }

    public string Tag { get; set; }

    public string FullTitle => $"{Title} ({Tag})";
}
