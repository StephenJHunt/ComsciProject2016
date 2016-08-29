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
            Engine.Engine.currentLevel = new ExampleLevel();
            Engine.Engine.Initialize();
        }
    }
}
