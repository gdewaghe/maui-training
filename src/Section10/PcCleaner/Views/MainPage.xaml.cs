namespace PcCleaner.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnInfoClicked(object? sender, EventArgs e)
    {
        try
        {
            Uri uri = new("http://anthony-cardinale.fr?from=pccleaner");
            await Browser.Default.OpenAsync(uri);
        }
        catch (Exception ex)
        {
            //An unexpected error occurred. No browser may be installed on this device
        }
    }
}
