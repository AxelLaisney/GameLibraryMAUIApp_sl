using GameLibraryMAUIApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibraryMAUIApp.Service
{
    public class GenreService
    {
        HttpClient client;
        string url = "http://192.168.1.22:5187/api/";
        public GenreService()
        {
            client = new HttpClient();
        }

        public async Task<List<Genre>> GetGenre()
        {
            try
            {
                var json = await client.GetStringAsync(url + "Genre").ConfigureAwait(false);
                var genres = JsonConvert.DeserializeObject<List<Genre>>(json);
                return genres;
            }
            catch (HttpRequestException)
            {
                var genres = new List<Genre>();
                return genres;
            }
        }
    }
}
