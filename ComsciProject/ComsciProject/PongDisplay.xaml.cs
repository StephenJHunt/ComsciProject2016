﻿using System;
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
using ComsciProject.Engine.Pong;
using ComsciProject.Engine;

namespace ComsciProject
{
    /// <summary>
    /// Interaction logic for PongDisplay.xaml
    /// </summary>
    public partial class PongDisplay : Window
    {
        public PongDisplay()
        {
            InitializeComponent();
            Engine.Engine.currentLevel = new PongLevel();
            Engine.Engine.maxUpdateRate = 10f;//10 updates per second are run
            Engine.Engine.Initialize();
        }
        
        private void Window_Closed_1(object sender, EventArgs e)
        {
            Engine.Engine.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ReceiveKey(e);
        }
    }
}
