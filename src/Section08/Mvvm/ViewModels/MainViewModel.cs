using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _text;

    [ObservableProperty]
    private ObservableCollection<string> _ingredients;

    public MainViewModel()
    {
        Ingredients = [];
    }

    [RelayCommand]
    private void AddItem()
    {
        Ingredients.Add(Text);
        Text = string.Empty;
    }
}
