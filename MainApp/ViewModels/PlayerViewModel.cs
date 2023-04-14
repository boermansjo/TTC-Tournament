using MainApp.Models;
using MainApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainApp.ViewModels
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private readonly PlayerService _playerService;

        public Command AddPlayerCommand { get; }

        private List<Player> _playerList;
        public string NewPlayerName { get; private set; }
        public string NewPlayerSurname { get; private set; }
        public string ErrorMessage { get; private set; }
        public string NewPlayerRank { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        

        public List<Player> Players
        {
            get { return _playerList; }
            set
            {
                _playerList = value;
                OnPropertyChanged(nameof(Players));
            }
        }

        public void AddPlayer(Player player)
        {
            _playerService.AddPlayer(player);
            LoadPlayers();
        }

        public PlayerViewModel()
        {
            _playerService = new PlayerService("c:/");
            NewPlayerName = "";
            NewPlayerRank = "";
            NewPlayerSurname = "";
            ErrorMessage = "";

            AddPlayerCommand = new Command(AddNewPlayer);
            LoadPlayers();
        }

        public PlayerViewModel(PlayerService playerService)
        {
            _playerService = playerService;
            LoadPlayers();
        }

        private void LoadPlayers()
        {
            Players = _playerService.GetPlayers();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddNewPlayer()
        {
            if (string.IsNullOrWhiteSpace(NewPlayerName))
            {
                ErrorMessage = "Name is required.";
                return;
            }

            if (string.IsNullOrWhiteSpace(NewPlayerRank))
            {
                ErrorMessage = "Rank is required.";
                return;
            }

            if (string.IsNullOrWhiteSpace(NewPlayerSurname))
            {
                ErrorMessage = "Surname is required.";
                return;
            }

            Player newPlayer = new Player();
            newPlayer.Surname = NewPlayerSurname;
            newPlayer.Name = NewPlayerName;
            newPlayer.Rank = NewPlayerRank;

            AddPlayer(newPlayer);
            NewPlayerName = "";
            NewPlayerSurname = "";
            NewPlayerRank = "";
        }
    }
}
