using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameLibraryMAUIApp.Model
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Completion { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public List<Console> ConsolesList { get; set; }
    }
}
