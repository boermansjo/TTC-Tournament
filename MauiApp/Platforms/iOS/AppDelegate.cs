using Foundation;

namespace MauiApp1.Platforms.iOS;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp1 CreateMauiApp() => MauiProgram.CreateMauiApp();
}
