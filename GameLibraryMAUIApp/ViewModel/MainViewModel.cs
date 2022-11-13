using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameLibraryMAUIApp.Model;
using GameLibraryMAUIApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = GameLibraryMAUIApp.Model.Console;

namespace GameLibraryMAUIApp.ViewModel
{
    public partial class MainViewModel: ObservableObject
    {
        GameLibraryService GS;

        public MainViewModel(GameLibraryService GameLibraryService)
        {
            this.GS = GameLibraryService;
            Jeux = new ObservableCollection<Game>();
            GetGame();
        }

        [ObservableProperty]
        ObservableCollection<Game> jeux;


        [RelayCommand]
        void GetGame()
        {
            var games = GS.GetGame().Result;
            if (games != null)
            {
                Jeux.Clear();
                foreach (var game in games)
                {
                    Jeux.Add(game);
                }
            }
        }

        [RelayCommand]
        async Task GoToAdd()
        {
            await Shell.Current.GoToAsync(nameof(Page.Add));
        }

        [RelayCommand]
        async Task Tap(Game g)
        {
            await Shell.Current.GoToAsync(nameof(Page.Detail),
                new Dictionary<string, object>
                {
                    {"Game", g }
                });
        }
    }
}
