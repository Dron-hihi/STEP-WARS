using StepWars.BusinessLogic.Clasess.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepWars.GameEngine
{
    public partial class StepWars : Form
    {
        PlayerDTO currentPlayer;

        

        public StepWars(PlayerDTO player)
        {
            InitializeComponent();


            var context = new InstanceContext(new RedrawHandler());
            var server = new GameService.GameControllerContractClient();

            currentPlayer = player;
            MessageBox.Show(player.NickName);
            MessageBox.Show(player.Ship.Name);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ExitGame(object sender, EventArgs e)
        {
            
        }
    }
}
