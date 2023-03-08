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
				fonts.AddFont("Cairo-ExtraLight.ttf", "RegularFont");
				fonts.AddFont("Cairo-Light.ttf", "LightFont");
			});

		return builder.Build();
	}
}
