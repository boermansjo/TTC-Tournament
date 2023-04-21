using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace App1.Models
{
    internal class PlayerManager
    {
        private const string FILE_NAME = "players.json";

        public static List<PlayerModel> LoadPlayers()
        {
            var list = new List<PlayerModel>();

            try
            {
                using (var stream = File.OpenRead(FILE_NAME))
                    using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    list = JsonSerializer.Deserialize<List<PlayerModel>>(json);
                }
            }
            catch { }
            return list;
        }

        public static void SavePlayers(List<PlayerModel> players)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(players, options);
                File.WriteAllText(FILE_NAME, json);
            }
            catch { }
        }
    }
}
