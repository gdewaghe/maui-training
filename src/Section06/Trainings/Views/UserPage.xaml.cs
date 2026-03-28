namespace Trainings.Views;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        var uri = new Uri("https://www.stable-diffusion-france.fr/Guide_StableDiffusion_fr_v1.pdf");
        await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }

    private async void Button_Clicked_1(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}