using GameLibraryMAUIApp.ViewModel;

namespace GameLibraryMAUIApp;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel VM)
    {
        InitializeComponent();
        BindingContext = VM;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        MainViewModel vm = BindingContext as MainViewModel;
        vm.GetGameCommand.Execute(vm);
    }
}

