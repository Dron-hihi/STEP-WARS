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
using MahApps.Metro.Controls;
using StepWars.Helpers.Extentions;
using WPF_User_Interface.AddItemService;

namespace UserInterface
{
    /// <summary>
    /// Логика взаимодействия для WPF_Admin_Window.xaml
    /// </summary>
    public partial class AdminPanel : MetroWindow
    {
        private string ShipName;
        private System.Drawing.Image Ico;
        private int DMG;
        private int HP;
        private int SPE;

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void TB_NameShip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TB_NameShip.Text == "")
                MessageBox.Show("Enter Name Ship");
            else
                ShipName = (sender as TextBox).Text;
        }

        private void ADDShip_Ico_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ADDShip_Ico.Text == "")
                MessageBox.Show("Write the path to the icon");
            else
                Ico = System.Drawing.Image.FromFile((sender as TextBox).Text);
        }

        private void Slid_Dmg_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DMG = Convert.ToInt32((sender as Slider).Value);
        }

        private void Slid_HP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            HP = Convert.ToInt32((sender as Slider).Value);
        }

        private void Slid_Speed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SPE = Convert.ToInt32((sender as Slider).Value);
        }

        private void Add_Ship()
        {
            StarShipDTO ship = new StarShipDTO();

            ship.Name = ShipName;
            ship.Damage = DMG;
            ship.Health = HP;
            ship.Speed = SPE;
            ship.Image = Ico.ImageToString();

            WPF_User_Interface.AddItemService.AddItemContractClient client = new AddItemContractClient();
            client.AddNewStarShip(ship);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_Ship();
        }
    }
}
