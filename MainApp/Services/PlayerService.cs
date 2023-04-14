using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MainApp.Services
{
    public class PlayerService
    {
        private readonly string _playersFilePath;

        public PlayerService(string playersFilePath)
        {
            _playersFilePath = playersFilePath;
        }

        public List<Player> GetPlayers()
        {
            string json = File.ReadAllText(_playersFilePath);
            return JsonSerializer.Deserialize<List<Player>>(json);
        }
    }
}
