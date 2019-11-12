using MahApps.Metro.Controls;
using StepWars.GameEngine;
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
using WPF_User_Interface.Views;

namespace UserInterface
{
    /// <summary>
    /// Логика взаимодействия для WPF_Selected_Ship.xaml
    /// </summary>
    public partial class ShipSelect : MetroWindow
    {
        public ShipSelect()
        {
            InitializeComponent();
        }

        private void Battle_Start(object sender, RoutedEventArgs e)
        {
            StepWars.GameEngine.StepWars form = new StepWars.GameEngine.StepWars();
            form.FormClosing += Form_FormClosing;
            form.ShowDialog();
            this.Close();
        }

        private void Form_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            ExitGameStatistic exitGameStatistic = new ExitGameStatistic();
            exitGameStatistic.Show();
        }
    }
}
