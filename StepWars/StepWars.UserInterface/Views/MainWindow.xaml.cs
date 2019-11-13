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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserInterface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        WPF_User_Interface.RegistrationService.RegistrationContractClient registrationService = new WPF_User_Interface.RegistrationService.RegistrationContractClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Gamer_Admin(object sender, RoutedEventArgs e)
        {
            if (RB_Gamer.IsChecked == true)
            {
                if (TB_NickName.Text != "")
                {
                    Login();

                    ShipSelect SelectedShip = new ShipSelect();
                    SelectedShip.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Enter your NICK NAME");
                }
            }
            else if (RB_Admin.IsChecked == true)
            {
                if (TB_NickName.Text != "")
                {
                    AdminLogin PasswordWindow = new AdminLogin();
                    PasswordWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Enter your NICK NAME");
                }
            }
            else
            {
                MessageBox.Show("Визначiться Ви iгрок чи адмiнiстратор");
            }

        }

        private void Login()
        {
            //registrationService.CheckToUserExist(TB_NickName)
        }

        private bool CheckToExist(string nickname)
        {
            return true;
        }

        
    }
}
