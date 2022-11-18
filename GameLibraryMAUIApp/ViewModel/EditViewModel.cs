using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameLibraryMAUIApp.DTO;
using GameLibraryMAUIApp.Model;
using GameLibraryMAUIApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = GameLibraryMAUIApp.Model.Console;

namespace GameLibraryMAUIApp.ViewModel
{
    [QueryProperty("Game", "Game")]

    public partial class EditViewModel : ObservableObject
    {
        GenreService genreService;
        ConsoleService consoleService;
        GameLibraryService gameLibraryService;

        public EditViewModel(GenreService genreService, ConsoleService consoleService, GameLibraryService gameLibraryService)
        {
            this.gameLibraryService = gameLibraryService;
            this.genreService = genreService;
            this.consoleService = consoleService;
            GenreList = new List<Genre>();
            ConsoleList = new List<Console>();
            GetGenre();
            GetConsole();
            ConsoleCollection = new ObservableCollection<Console>();
        }

        [ObservableProperty]
        Game game;
        [ObservableProperty]
        ObservableCollection<Console> consoleCollection;
        [ObservableProperty]
        Genre genre;
        [ObservableProperty]
        List<Genre> genreList;
        [ObservableProperty]
        List<Console> consoleList;
        [ObservableProperty]
        Console console;

        partial void OnGameChanged(Game value)
        {
            this.Genre = GenreList.Find(x => x.GenreId == value.GenreId);
            foreach(Console console in value.ConsolesList)
            {
                ConsoleCollection.Add(console);
            }
        }

        void GetGenre()
        {
            List<Genre> genres = genreService.GetGenre().Result;
            if (genres != null)
            {
                foreach (var genre in genres)
                {
                    GenreList.Add(genre);
                }
            }
        }

        void GetConsole()
        {
            List<Console> consoles = consoleService.GetConsole().Result;
            if (consoles != null)
            {
                foreach (var console in consoles)
                {
                    ConsoleList.Add(console);
                }
            }
        }

        [RelayCommand]
        async  Task UpdateGame()
        {
            List<Console> consoles = new();
            foreach(Console console in ConsoleCollection)
            {
                consoles.Add(console);
            }
            GameDTO gameDTO = new GameDTO()
            {
                GameId = Game.GameId,
                Name = Game.Name,
                Publisher = Game.Publisher,
                Completion = Game.Completion,
                ReleaseDate = Game.ReleaseDate,
                GenreId = Genre.GenreId,
                ConsolesList = consoles
            };
            await gameLibraryService.UpdateGame(gameDTO);
            await Shell.Current.GoToAsync("//MainPage");
        }

        [RelayCommand]
        void DeleteConsole(Console c)
        {
            if (consoleCollection.Contains(c))
            {
                consoleCollection.Remove(c);
            }
        }

        [RelayCommand]
        void AddConsole()
        {
            if (Console == null)
            {
                return;
            }
            consoleCollection.Add(Console);
        }
    }
}
