using GameLibraryMAUIApp.ViewModel;

namespace GameLibraryMAUIApp.Page;

public partial class Edit : ContentPage
{
	public Edit(EditViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}