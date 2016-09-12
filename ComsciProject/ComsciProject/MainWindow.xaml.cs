using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace ComsciProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer;
        public MainWindow()
        {
            InitializeComponent();
            instance = this;
            KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.Key)
            //{
            //    case Key.Left:
            //        {
            //            SnakeGame.Input(0);
            //            break;
            //        }
            //    case Key.Up:
            //        {
            //            SnakeGame.Input(1);
            //            break;
            //        }
            //    case Key.Right:
            //        {
            //            SnakeGame.Input(2);
            //            break;
            //        }
            //    case Key.Down:
            //        {
            //            SnakeGame.Input(3);
            //            break;
            //        }
            //}
        }
        public static MainWindow instance;//FOR TETRIS: use left mouse for left rotation, right mouse for right rotation, middle to speed up
        private static SnakeGameDisplay display;
        private void Snek_Click(object sender, RoutedEventArgs e)
        {
            display = new SnakeGameDisplay();
            display.Show();
            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Interval = TimeSpan.FromMilliseconds(1000 / Engine.Engine.maxUpdateRate);//this blocks our game thread, must be changed to suit the game frame rate
            Timer.IsEnabled = true;
            Timer.Tick += dispatcherTimer_Tick;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            display.Display.Content = Engine.Engine.LastFrame;
            Engine.Engine.renderComplete = true;
        }



        private void PacMan_Click(object sender, RoutedEventArgs e)
        {
            display = new SnakeGameDisplay();
            display.Show();
            Timer = new System.Windows.Threading.DispatcherTimer();
            Engine.Engine.maxUpdateRate = 5;
            Timer.Interval = TimeSpan.FromMilliseconds(1000 / Engine.Engine.maxUpdateRate);//this blocks our game thread, must be changed to suit the game frame rate
            Timer.IsEnabled = true;
            Timer.Tick += PacManDispatcherTimer_Tick;
        }

        private void PacManDispatcherTimer_Tick(object sender, EventArgs e)
        {
            display.Display.Content = Engine.Engine.LastFrame;
            Engine.Engine.renderComplete = true;
        }
    }
}
