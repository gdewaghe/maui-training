using Trainings.Models;

namespace Trainings.Views;

public partial class TrainingPage : ContentPage
{
	private readonly Training _training;

	public List<string> Items { get; } = [];

	public TrainingPage(Training training)
	{
		_training = training;
		InitializeComponent();

		Items.Add("Chapter 1");
		Items.Add("Chapter 2");
		Items.Add("Chapter 3");
		ChaptersListView.ItemsSource = Items;
    }
}