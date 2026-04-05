namespace Trainings.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLogInClicked(object? sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        // To be used on local
        //if (username == "guillaume" && password == "123")
        //{
        //    return true;
        //}

        // http://10.0.2.2:5152/Login?username=guillaume&password=123
        string restURL = $"http://10.0.2.2:5152/Login?username={username}&password={password}";
        HttpClient client = new()
        {
            BaseAddress = new Uri(restURL)
        };

        HttpResponseMessage response = await client.GetAsync(restURL);
        string content = await response.Content.ReadAsStringAsync();

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