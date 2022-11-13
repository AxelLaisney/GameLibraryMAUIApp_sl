using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameLibraryMAUIApp.DTO;
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
    public partial class AddViewModel : ObservableObject
    {
        GameLibraryService gs;
        GenreService genreService;
        ConsoleService consoleService;

        public AddViewModel(GameLibraryService GameService, GenreService genreService, ConsoleService consoleService)
        {
            this.gs = GameService;
            this.genreService = genreService;
            this.consoleService = consoleService;
            GenreList = new List<Genre>();
            ConsoleList = new List<Console>();
            ConsoleCollection = new ObservableCollection<Console>();
            GetGenre();
            GetConsole();
        }

        [ObservableProperty]
        string name;
        [ObservableProperty]
        string publisher;
        [ObservableProperty]
        string completion;
        [ObservableProperty]
        DateTime releaseDate;
        [ObservableProperty]
        Genre genre;


        [ObservableProperty]
        List<Genre> genreList;
        [ObservableProperty]
        List<Console> consoleList;
        [ObservableProperty]
        Console console;
        [ObservableProperty]
        ObservableCollection<Console> consoleCollection;

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
        async Task Add()
        {
            List<Console> consoles = new List<Console>();
            foreach (Console console in consoleCollection)
            {
                consoles.Add(console);
            }
            GameDTO game = new GameDTO()
            {
                Name = Name,
                Publisher = Publisher,
                Completion = Completion,
                ReleaseDate = ReleaseDate,
                GenreId = Genre.GenreId,
                ConsolesList = consoles
            };
            await gs.PostGame(game); //Object need to be filled or else it won't send the request
            Name = String.Empty;
            Publisher = String.Empty;
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        void AddConsole()
        {
            if(Console == null)
            {
                return;
            }
            consoleCollection.Add(Console);
        }

        [RelayCommand]
        void DeleteConsole(Console c)
        {
            if (consoleCollection.Contains(c))
            {
                consoleCollection.Remove(c);
            }
        }
    }
}
