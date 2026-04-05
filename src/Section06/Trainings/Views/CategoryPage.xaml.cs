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
        NoCoursesErrorLabel.IsVisible = false;

        LoadFromMauiAssets(category.Title.ToLower());
    }

    private async void LoadFromMauiAssets(string categoryTitle)
    {
        try
        {
            using Stream stream = await FileSystem.OpenAppPackageFileAsync($"{categoryTitle}.json");
            using StreamReader reader = new(stream);
            string content = reader.ReadToEnd();
            List<Training>? items = JsonConvert.DeserializeObject<List<Training>>(content);
            TrainingsListView.ItemsSource = items;
        }
        catch (Exception)
        {
            TrainingsListView.ItemsSource = null;
            NoCoursesErrorLabel.IsVisible = true;
        }
    }

    private void OnTrainingItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {

    }
}