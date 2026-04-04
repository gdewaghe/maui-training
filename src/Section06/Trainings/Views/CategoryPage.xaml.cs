using Newtonsoft.Json;
using Trainings.Models;

namespace Trainings.Views;

public partial class CategoryPage : ContentPage
{
    private readonly Category _category;

    public CategoryPage(Category category)
    {
        _category = category;
        InitializeComponent();
        //NoCoursesError.IsVisible = true;

        LoadFromMauiAssets(category.Title.ToLower());
    }

    private async void LoadFromMauiAssets(string categoryTitle)
    {
        try
        {
            using Stream stream = await FileSystem.OpenAppPackageFileAsync($"{categoryTitle}.json");
            using var reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            var items = JsonConvert.DeserializeObject<List<Training>>(content);
            //TrainingsListView.ItemsSource = items;
        }
        catch (Exception ex)
        {
            //TrainingsListView.ItemsSource = null;
            //NoCoursesError.IsVisible = true;
        }
    }
}