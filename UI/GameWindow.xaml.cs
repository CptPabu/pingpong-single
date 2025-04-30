using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Timers;
using UI.DTOs;




namespace UI
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        Game game;
        Timer timer = new Timer(500);
        Timer collisonTimer = new Timer(100);

        public GameWindow(Game game)
        {
            this.game = game;
            DataContext = new MyContext(game);
            InitializeComponent();
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }


        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            // Check if the pressed key is Left or Right
            if (e.Key == Key.Left)
            {
                ((MyContext) DataContext).BatPositionLeft -= 10;
            }
            else if (e.Key == Key.Right)
            {
                ((MyContext)DataContext).BatPositionLeft += 10;
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                ((MyContext)DataContext).BallPositionLeft += game.BallSpeedLeft;
                ((MyContext)DataContext).BallPositionTop += game.BallSpeedTop;
            });



            
        }





        /*
        public bool CollisionCheck()
        {
            MyContext context = (MyContext)DataContext;
            int ballTopPosition = context.BallTopPosition;
            int ballLeftPosition = context.BallTopPosition;
            int paddleLeftPosition = context.PaddleLeftPosition;

            if (ballTopPosition < paddleTopPosition)
            {

            }
            return false;
        }
        */
    }
}
