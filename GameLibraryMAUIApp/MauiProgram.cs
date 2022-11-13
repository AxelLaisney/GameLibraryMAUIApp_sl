using GameLibraryMAUIApp.Page;
using GameLibraryMAUIApp.Service;
using GameLibraryMAUIApp.ViewModel;

namespace GameLibraryMAUIApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<GameLibraryService>();
		builder.Services.AddSingleton<GenreService>();
		builder.Services.AddSingleton<ConsoleService>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<AddViewModel>();
		builder.Services.AddTransient<Page.Add>();
		builder.Services.AddTransient<Page.Detail>();
		builder.Services.AddSingleton<DetailViewModel>();
		builder.Services.AddTransient<EditViewModel>();
		builder.Services.AddTransient<Page.Edit>();

		return builder.Build();
	}
}
