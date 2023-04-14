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

        public void AddPlayer(Player player)
        {
            List<Player> list = GetPlayers();
            list.Add(player);
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(_playersFilePath, json);
        }

        public List<Player> GetPlayers()
        {
            if (File.Exists(_playersFilePath))
            {
                string json = File.ReadAllText(_playersFilePath);
                return JsonSerializer.Deserialize<List<Player>>(json);
            }
            else
            {
                return new List<Player>();
            }
            
        }
    }
}
