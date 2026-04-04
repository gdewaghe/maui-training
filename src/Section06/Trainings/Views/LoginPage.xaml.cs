namespace Trainings.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLogInButtonClicked(object? sender, EventArgs e)
    {
        var username = UsernameEntry.Text;
        var password = PasswordEntry.Text;

        // To be used on local
        //if (username == "guillaume" && password == "123")
        //{
        //    return true;
        //}

        // http://10.0.2.2:5152/Login?username=guillaume&password=123
        var restURL = $"http://10.0.2.2:5152/Login?username={username}&password={password}";
        var client = new HttpClient
        {
            BaseAddress = new Uri(restURL)
        };

        HttpResponseMessage response = await client.GetAsync(restURL);
        var content = await response.Content.ReadAsStringAsync();

        if (content == username)
        {
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            // TODO: Error
        }
    }
}