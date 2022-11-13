using GameLibraryMAUIApp.ViewModel;

namespace GameLibraryMAUIApp.Page;

public partial class Add : ContentPage
{
	public Add(AddViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}