using GameLibraryMAUIApp.ViewModel;

namespace GameLibraryMAUIApp.Page;

public partial class Detail : ContentPage
{
	public Detail(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}