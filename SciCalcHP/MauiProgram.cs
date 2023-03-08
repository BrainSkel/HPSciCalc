namespace SciCalcHP;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Cairo-ExtraLight.ttf", "OpenSansRegular");
				fonts.AddFont("Cairo-Light.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
