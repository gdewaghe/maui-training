namespace Trainings.Views;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
	}

    private async void OnBrowserButtonClicked(object? sender, EventArgs e)
    {
        var uri = new Uri("https://www.stable-diffusion-france.fr/Guide_StableDiffusion_fr_v1.pdf");
        await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }

    private async void OnLoginButtonClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}