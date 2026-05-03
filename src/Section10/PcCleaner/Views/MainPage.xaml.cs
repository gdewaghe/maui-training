using PcCleaner.Helpers;

namespace PcCleaner.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        ShowSystemInfo();
    }

    public void ShowSystemInfo()
    {
        OsVersionLabel.Text = SystemInfo.GetWindowsVersion();
        HardwareLabel.Text = SystemInfo.GetHardwareInfo();
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
