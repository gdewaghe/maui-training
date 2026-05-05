using PcCleaner.Helpers;

namespace PcCleaner.Views;

public partial class MainPage : ContentPage
{
    private bool _temporaryFilesChecked = true;
    private bool _binChecked = true;
    private bool _logsChecked = true;
    private bool _windowsUpdateChecked = true;
    private bool _errorsChecked = true;

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

    private void OnCleanClicked(object? sender, EventArgs e)
    {
        DebugLabel.Text = $"Info: " +
            $"{_temporaryFilesChecked} - " +
            $"{_binChecked} - " +
            $"{_logsChecked} - " +
            $"{_windowsUpdateChecked} - " +
            $"{_errorsChecked}";
    }

    private void OnTemporaryFilesCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        _temporaryFilesChecked = e.Value;
    }

    private void OnEmptyBinCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        _binChecked = e.Value;
    }

    private void OnLogsCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        _logsChecked = e.Value;
    }

    private void OnWindowsUpdateCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        _windowsUpdateChecked = e.Value;
    }

    private void OnErrorsCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        _errorsChecked = e.Value;
    }
}
