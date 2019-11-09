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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WPF_User_Interface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
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
                    MessageBox.Show("Перехід у віндовс форму");
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
                    WPF_Admin_Password PasswordWindow = new WPF_Admin_Password();
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
    }
}
