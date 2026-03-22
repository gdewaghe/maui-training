using Newtonsoft.Json;
using Trainings.Models;

namespace Trainings;

public partial class MainPage : ContentPage
{
    private List<Category> _categories = [];

    public List<Category> Categories
    {
        get => _categories; 
        set => _categories = value;
    }

    public MainPage()
    {
        InitializeComponent();

        LoadDataFromAPI();
    }

    private void ToolbarItem_Clicked(object? sender, EventArgs e)
    {
        // TODO
        Console.WriteLine("*** TODO: ToolbarItem_Clicked");
    }

    public async void LoadDataFromAPI()
    {
        // Replace 'localhost' with '10.0.2.2' to connect the phone to the computer
        var restURL = "http://10.0.2.2:5152/Category";
        var client = new HttpClient
        {
            BaseAddress = new Uri(restURL)
        };

        HttpResponseMessage response = await client.GetAsync(restURL);
        var content = await response.Content.ReadAsStringAsync();
        var items = JsonConvert.DeserializeObject<List<Category>>(content);
        categoriesCollectionView.ItemsSource = items;
    }
}
