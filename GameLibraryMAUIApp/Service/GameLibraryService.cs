using GameLibraryMAUIApp.DTO;
using GameLibraryMAUIApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameLibraryMAUIApp.Service
{
    public class GameLibraryService
    {
        HttpClient client;
        string url = "http://192.168.1.22:5187/api/";

        public GameLibraryService()
        {
            client = new HttpClient();
        }

        public async Task<List<Game>> GetGame()
        {
            try
            {
                var json = await client.GetStringAsync(url+"Game").ConfigureAwait(false);
                var games = JsonConvert.DeserializeObject<List<Game>>(json);
                return games;
            }
            catch (HttpRequestException)
            {
                var games = new List<Game>();
                return games;
            }
        }

        public async Task PostGame(GameDTO gameDTO)
        {
            string json = JsonConvert.SerializeObject(gameDTO);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(url+"Game", content);
        }

        public async Task DeleteGame(int id)
        {
            await client.DeleteAsync(url + "Game/" + id);
        }
    }
}
