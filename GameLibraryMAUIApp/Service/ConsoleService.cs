using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = GameLibraryMAUIApp.Model.Console;

namespace GameLibraryMAUIApp.Service
{
    public class ConsoleService
    {
        HttpClient client;
        string url = "http://192.168.1.22:5187/api/";
        public ConsoleService()
        {
            client = new HttpClient();
        }

        public async Task<List<Console>> GetConsole()
        {
            try
            {
                var json = await client.GetStringAsync(url + "Console").ConfigureAwait(false);
                List<Console> consoles = JsonConvert.DeserializeObject<List<Console>>(json);
                return consoles;
            }
            catch (HttpRequestException)
            {
                var consoles = new List<Console>();
                return consoles;
            }
        }
    }
}
