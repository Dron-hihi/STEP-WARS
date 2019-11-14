using MahApps.Metro.Controls;
using StepWars.Helpers.Extentions;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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
using WPF_User_Interface.RegistrationService;
using WPF_User_Interface.Views;

namespace UserInterface
{
    /// <summary>
    /// Логика взаимодействия для WPF_Selected_Ship.xaml
    /// </summary>
    public partial class ShipSelect : MetroWindow
    {
        private string playerNickName;
        private StarShipDTO selectedShip = new StarShipDTO();

        public List<ShipTemplate> Ships { get; set; }

        private RegistrationContractClient registrationService = new RegistrationContractClient();
        List<StarShipDTO> allShips;

        public ShipSelect(string PlayerNickName)
        {
            InitializeComponent();
            playerNickName = PlayerNickName;

            allShips = registrationService.GetAllShips().ToList();

            Ships = new List<ShipTemplate>();
            for (int i = 0; i < allShips.Count; i++)
            {
                Ships.Add(new ShipTemplate()
                {
                    ShipImage = allShips[i].Image.StringToImage(),
                    Damage = allShips[i].Damage,
                    Health = allShips[i].Health,
                    Speed = allShips[i].Speed,
                    ButtonTag = i
                });

                try
                {
                    string startupPath = System.IO.Directory.GetCurrentDirectory();
                    Ships[i].ImagePath += startupPath + "\\";
                    Ships[i].ImagePath += $"{Ships[i].ButtonTag}.jpeg";
                    Ships[i].ShipImage.Save(Ships[i].ImagePath, ImageFormat.Jpeg);
                }
                catch (Exception)
                {
                }

            }


            LBPresentation.Items.Clear();
            LBPresentation.ItemsSource = Ships;
        }

        private void Battle_Start(object sender, RoutedEventArgs e)
        {
            var currShip = Ships.FirstOrDefault(x => x.ButtonTag == Convert.ToInt16((sender as Button).Tag));
            selectedShip.Damage = currShip.Damage;
            selectedShip.Health = currShip.Health;
            selectedShip.Speed = currShip.Speed;
            selectedShip.Image = currShip.ShipImage.ImageToString();



            StepWars.BattleArena.Form1 form = new StepWars.BattleArena.Form1(new StepWars.BusinessLogic.Clasess.DTO.PlayerDTO
            {
                AdminRules = registrationService.RegisterNewPlayer(playerNickName, selectedShip).AdminRules,
                NickName = registrationService.RegisterNewPlayer(playerNickName, selectedShip).NickName,
                Score = registrationService.RegisterNewPlayer(playerNickName, selectedShip).Score,
                Ship = new StepWars.BusinessLogic.Clasess.DTO.StarShipDTO()
                {
                    Damage = registrationService.RegisterNewPlayer(playerNickName, selectedShip).Ship.Damage,
                    Health = registrationService.RegisterNewPlayer(playerNickName, selectedShip).Ship.Health,
                    Name = registrationService.RegisterNewPlayer(playerNickName, selectedShip).Ship.Name,
                    Speed = registrationService.RegisterNewPlayer(playerNickName, selectedShip).Ship.Speed,
                    Image = registrationService.RegisterNewPlayer(playerNickName, selectedShip).Ship.Image
                }
            });
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

    public class ShipTemplate
    {
        public System.Drawing.Image ShipImage { get; set; }
        public string ImagePath { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public int ButtonTag { get; set; }
    }

}
