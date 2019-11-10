using MahApps.Metro.Controls;
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

namespace UserInterface
{
    /// <summary>
    /// Логика взаимодействия для WPF_Admin_Password.xaml
    /// </summary>
    public partial class AdminLogin : MetroWindow
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void Confirm_Password(object sender, RoutedEventArgs e)
        {
            if (PB_Admin_Password.Password != "")
            {
                AdminPanel AdminWindow = new AdminPanel();
                AdminWindow.Show();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Password entered incorrectly");
                MainWindow MW = new MainWindow();
                MW.Show();
                this.Close();
            }
        }
    }
}
