using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameLibraryMAUIApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibraryMAUIApp.ViewModel
{
    [QueryProperty("Game", "Game")]

    public partial class EditViewModel : ObservableObject
    {
        [ObservableProperty]
        Game game;

        
    }
}
