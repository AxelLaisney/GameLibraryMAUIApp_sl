namespace GameLibraryMAUIApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Page.Add), typeof(Page.Add));
		Routing.RegisterRoute(nameof(Page.Detail), typeof(Page.Detail));
		Routing.RegisterRoute(nameof(Page.Edit), typeof(Page.Edit));
	}
}
