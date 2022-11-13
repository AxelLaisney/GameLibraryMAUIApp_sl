using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameLibraryMAUIApp.Model;
using GameLibraryMAUIApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibraryMAUIApp.ViewModel
{
    [QueryProperty("Game", "Game")]
    public partial class DetailViewModel : ObservableObject
    {
        GameLibraryService gs;

        public DetailViewModel(GameLibraryService gs)
        {
            this.gs = gs;
        }
        [ObservableProperty]
        Game game;

        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async void Delete(Game game)
        {
            bool answer = await App.Current.MainPage.DisplayAlert("WARNING!", "Are you sure you want yo delete this entry?", "Yes", "No");
            if (answer == true) {
                await gs.DeleteGame(game.GameId);
                await Shell.Current.GoToAsync("..");

            }
        }

        [RelayCommand]
        async Task GoEdit(Game g)
        {
            await Shell.Current.GoToAsync(nameof(Page.Edit),
                new Dictionary<string, object>
                {
                    {"Game", g }
                });
        }
    }
}
