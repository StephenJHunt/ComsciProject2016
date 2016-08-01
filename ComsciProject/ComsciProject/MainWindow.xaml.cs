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
        Thread renderThread;
        public MainWindow()
        {
            InitializeComponent();
            instance = this;
            KeyDown += MainWindow_KeyDown;
            SnakeGame.StartGame();
            renderThread = new Thread(Render);
            renderThread.Start();
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    {
                        SnakeGame.Input(0);
                        break;
                    }
                case Key.Up:
                    {
                        SnakeGame.Input(1);
                        break;
                    }
                case Key.Right:
                    {
                        SnakeGame.Input(2);
                        break;
                    }
                case Key.Down:
                    {
                        SnakeGame.Input(3);
                        break;
                    }
            }
        }
        public static MainWindow instance;

        public void Render()
        {
            GameWindow.Content = SnakeGame.screen;
            //Thread.Sleep(1000 / SnakeGame.updateRate);
        }
    }
}
