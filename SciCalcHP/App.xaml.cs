#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using SciCalcHP.Views;
using Windows.Graphics;
#endif
namespace SciCalcHP;

public partial class App : Application
{
	const int WindowWidth = 540;
	const int WindowsHeight = 1000;
	public App()
	{
		InitializeComponent();

#if WINDOWS
		Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
		{
			var mauiWindow = handler.VirtualView;
			var nativeWindow = handler.PlatformView;
			nativeWindow.Activate();
			IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
			WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
			AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
			appWindow.Resize(new SizeInt32(WindowWidth, WindowsHeight));
		});
#endif

        MainPage = new CalculatorPage();
	}
}
