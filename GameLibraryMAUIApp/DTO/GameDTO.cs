using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = GameLibraryMAUIApp.Model.Console;

namespace GameLibraryMAUIApp.DTO
{
    public class GameDTO
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Completion { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public List<Console> ConsolesList { get; set; }
    }
}
