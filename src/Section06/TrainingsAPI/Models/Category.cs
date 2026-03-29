namespace TrainingsAPI.Models;

public class Category(string title, int count, string description, string image)
{
    public string Title { get; set; } = title;

    public int Count { get; set; } = count;

    public string Description { get; set; } = description;

    public string Image { get; set; } = image;
}
