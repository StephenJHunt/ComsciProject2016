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
using System.Windows.Shapes;
using ComsciProject.Engine.Example;
using ComsciProject.Engine.PacMan;
using ComsciProject.Engine;
namespace ComsciProject
{
    /// <summary>
    /// Interaction logic for SnakeGameDisplay.xaml
    /// </summary>
    public partial class SnakeGameDisplay : Window
    {
        public SnakeGameDisplay()
        {
            InitializeComponent();
            //change definition here to change games
            //Engine.Engine.currentLevel = new ExampleLevel();
            Engine.Engine.currentLevel = new PacManLevel();
            Engine.Engine.Initialize();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Engine.Engine.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Input.Initialize(SnakeWindow.KeyDown);
        }
    }
}
