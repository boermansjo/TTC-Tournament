using MainApp.Models;
using MainApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.ViewModels
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private readonly PlayerService _playerService;
        private List<Player> _playerList;

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

        public PlayerViewModel()
        {
            _playerService = new PlayerService("c:/");
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
    }
}
