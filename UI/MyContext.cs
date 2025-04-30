using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using UI.DTOs;




namespace UI
{
    public class MyContext : INotifyPropertyChanged
    {
        private Game game;


        public MyContext(Game game)
        {
            this.game = game;
        }


        public int BallPositionTop
        {
            get
            {
                return game.BallPositionTop;
            }
            set
            {
                game.BallPositionTop = value;
                OnPropertyChanged();
            }
        }
        public int BallPositionLeft
        {
            get
            {
                return game.BallPositionLeft;
            }
            set
            {
                game.BallPositionLeft = value;
                OnPropertyChanged();
            }
        }
        public int BatPositionLeft
        {
            get
            {
                return game.BatPositionLeft;
            }
            set
            {
                game.BatPositionLeft = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
