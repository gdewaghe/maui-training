namespace TrainingsAPI.Models;

public class Training(string title, int price, string description, string image, string tag)
{
    public string Title { get; set; } = title;

    public int Price { get; set; } = price;

    public string Description { get; set; } = description;

    public string Image { get; set; } = image;

    public string Tag { get; set; } = tag;
}
