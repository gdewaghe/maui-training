using Android.App;
using Android.Content.Res;
using Android.Runtime;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace Trainings.Platforms.Android;

[Application]
public class MainApplication(IntPtr handle, JniHandleOwnership ownership) : MauiApplication(handle, ownership)
{
    protected override MauiApp CreateMauiApp()
    {
        // Remove Entry control underline
        EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, entry) =>
        {
            handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
        });

        return MauiProgram.CreateMauiApp();
    }
}
