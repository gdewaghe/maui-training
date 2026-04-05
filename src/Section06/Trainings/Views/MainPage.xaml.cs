using Newtonsoft.Json;
using Trainings.Models;

namespace Trainings.Views;

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

        //LoadDataFromAPI();
        LoadDataFromLocalAssets();
    }

    private async void OnUserClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserPage());
    }

    public async void LoadDataFromAPI()
    {
        // Replace 'localhost' with '10.0.2.2' to connect the phone to the computer
        string restURL = "http://10.0.2.2:5152/Category";
        HttpClient client = new()
        {
            BaseAddress = new Uri(restURL)
        };

        HttpResponseMessage response = await client.GetAsync(restURL);
        string content = await response.Content.ReadAsStringAsync();
        List<Category>? items = JsonConvert.DeserializeObject<List<Category>>(content);
        CategoriesListView.ItemsSource = items;
    }

    public async void LoadDataFromLocalAssets()
    {
        using Stream stream = await FileSystem.OpenAppPackageFileAsync("categories.json");
        using StreamReader reader = new(stream);
        string content = reader.ReadToEnd();
        List<Category>? items = JsonConvert.DeserializeObject<List<Category>>(content);
        CategoriesListView.ItemsSource = items;
    }

    private async void OnCategoryItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        Category category = (Category)e.SelectedItem;
        //Console.WriteLine(category.Title);

        await Navigation.PushAsync(new CategoryPage(category)
        {
            BindingContext = category
        });
    }
}
