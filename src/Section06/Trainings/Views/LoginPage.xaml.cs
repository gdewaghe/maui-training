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
        //if (usernameEntry.Text == "guillaume" && passwordEntry.Text == "123")
        //{
        //    return true;
        //}

        // http://10.0.2.2:5152/Login?username=guillaume&password=123
        var restURL = $"http://10.0.2.2:5152/Login?username={usernameEntry.Text}&password={passwordEntry.Text}";
        var client = new HttpClient
        {
            BaseAddress = new Uri(restURL)
        };

        HttpResponseMessage response = await client.GetAsync(restURL);
        var content = await response.Content.ReadAsStringAsync();

        if (content == usernameEntry.Text)
        {
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            // TODO: Error
        }
    }
}