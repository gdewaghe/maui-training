using Microsoft.Win32;
using NvAPIWrapper;
using NvAPIWrapper.GPU;
using System.Text;

namespace PcCleaner.Helpers;

public static class SystemInfo
{
    /// <summary>
    /// Gets the current Windows version.
    /// </summary>
    /// <returns>The Windows version string.</returns>
    public static string GetWindowsVersion()
    {
        try
        {
            return Environment.OSVersion.ToString();
        }
        catch
        {
            return "Windows";
        }
    }

    /// <summary>
    /// Gets the current computer hardware info (CPU, GPU).
    /// </summary>
    /// <returns>The hardware info string.</returns>
    public static string GetHardwareInfo()
    {
        StringBuilder stringBuilder = new();

        RegistryKey? processorName = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);
        if (processorName is not null)
        {
            stringBuilder.AppendLine($"{processorName.GetValue("ProcessorNameString")}");
        }

        try
        {
            NVIDIA.Initialize();
            stringBuilder.AppendLine($"{PhysicalGPU.GetPhysicalGPUs()[0]}");
        }
        catch (Exception ex)
        {

        }

        return stringBuilder.ToString();
    }
}
