namespace Trainings.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLogInButtonClicked(object? sender, EventArgs e)
    {
        // To be used on local
        //if (UsernameEntry.Text == "guillaume" && PasswordEntry.Text == "123")
        //{
        //    return true;
        //}

        // http://10.0.2.2:5152/Login?username=guillaume&password=123
        var restURL = $"http://10.0.2.2:5152/Login?username={UsernameEntry.Text}&password={PasswordEntry.Text}";
        var client = new HttpClient
        {
            BaseAddress = new Uri(restURL)
        };

        HttpResponseMessage response = await client.GetAsync(restURL);
        var content = await response.Content.ReadAsStringAsync();

        if (content == UsernameEntry.Text)
        {
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            // TODO: Error
        }
    }
}