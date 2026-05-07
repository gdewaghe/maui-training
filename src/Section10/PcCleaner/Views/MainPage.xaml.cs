using PcCleaner.Helpers;
using System.Runtime.InteropServices;

namespace PcCleaner.Views;

public partial class MainPage : ContentPage
{
    private bool _temporaryFilesChecked;
    private bool _binChecked;
    private bool _logsChecked;
    private bool _windowsUpdateChecked;
    private bool _errorsChecked;

    public MainPage()
    {
        InitializeComponent();

        ShowSystemInfo();

        InitializeCheckBoxesStates();
    }

    public void ShowSystemInfo()
    {
        OsVersionLabel.Text = SystemInfo.GetWindowsVersion();
        HardwareLabel.Text = SystemInfo.GetHardwareInfo();
    }

    public void InitializeCheckBoxesStates()
    {
        _temporaryFilesChecked = Preferences.Get(nameof(_temporaryFilesChecked), false);
        TemporaryFilesCheckBox.IsChecked = _temporaryFilesChecked;

        _binChecked = Preferences.Get(nameof(_binChecked), true);
        EmptyBinCheckBox.IsChecked = _binChecked;

        _logsChecked = Preferences.Get(nameof(_logsChecked), true);
        LogsCheckBox.IsChecked = _logsChecked;

        _windowsUpdateChecked = Preferences.Get(nameof(_windowsUpdateChecked), true);
        WindowsUpdateCheckBox.IsChecked = _windowsUpdateChecked;

        _errorsChecked = Preferences.Get(nameof(_errorsChecked), true);
        ErrorsCheckBox.IsChecked = _errorsChecked;
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
        InfoLabel.IsVisible = false;

        if (_temporaryFilesChecked)
        {
            ClearWindowsTemporaryFolder();
        }

        if (_binChecked)
        {
            EmptyRecycleBin();
        }

        CleaningProgressBar.Progress = 1;
        SummaryTable.IsVisible = true;
    }

    public void EmptyRecycleBin()
    {
        // Flag to cancel confirmation
        const int SHERB_NO_CONFIRMATION = 0x00000001;

        try
        {
            SHEmptyRecycleBin(IntPtr.Zero, null, SHERB_NO_CONFIRMATION);
            BinDetail.Text = "Recycle Bin is empty.";
        }
        catch (Exception ex)
        {

        }
    }

    [DllImport("shell32.dll")]
    private static extern int SHEmptyRecycleBin(IntPtr hwnd, string? pszRootPath, uint dwFlags);

    public void ClearWindowsTemporaryFolder()
    {
        const string TEMP_PATH = @"C:\Windows\Temp";

        if (Directory.Exists(TEMP_PATH))
        {
            TemporaryFilesDetail.Detail = $"{GetFilesCountInFolder(TEMP_PATH)} files removed.";
            ProcessDirectory(TEMP_PATH);
        }
    }

    public int GetFilesCountInFolder(string path)
    {
        int count = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
        return count;
    }

    public void ProcessDirectory(string targetDirectory)
    {
        string[] fileEntries = Directory.GetFiles(targetDirectory);
        foreach (string fileName in fileEntries)
        {
            ProcessFile(fileName);
        }

        string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach (string subdirectory in subdirectoryEntries)
        {
            ProcessDirectory(subdirectory);
        }
    }

    public void ProcessFile(string path)
    {
        try
        {
            if (path.Contains("\\Temp"))
            {
                File.Delete(path);
            }
            else if (path.Contains("\\SoftwareDistribution"))
            {
                File.Delete(path);
            }
            else if (path.Contains("\\winevt\\Logs"))
            {
                File.Delete(path);
            }
            else if (path.Contains("\\Windows\\WER"))
            {
                File.Delete(path);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("The process failed: {0}", ex.Message);
        }
    }

    private void OnTemporaryFilesCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        _temporaryFilesChecked = e.Value;
        Preferences.Set(nameof(_temporaryFilesChecked), _temporaryFilesChecked);
    }

    private void OnEmptyBinCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        _binChecked = e.Value;
        Preferences.Set(nameof(_binChecked), _binChecked);
    }

    private void OnLogsCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        _logsChecked = e.Value;
        Preferences.Set(nameof(_logsChecked), _logsChecked);
    }

    private void OnWindowsUpdateCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        _windowsUpdateChecked = e.Value;
        Preferences.Set(nameof(_windowsUpdateChecked), _windowsUpdateChecked);
    }

    private void OnErrorsCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        _errorsChecked = e.Value;
        Preferences.Set(nameof(_errorsChecked), _errorsChecked);
    }
}
