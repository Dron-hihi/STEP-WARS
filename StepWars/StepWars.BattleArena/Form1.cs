﻿using StepWars.BattleArena.GameService;
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

namespace StepWars.BattleArena
{
    public partial class Form1 : Form
    {
        PlayerDTO player;

        public Form1(PlayerDTO Player)
        {
            InitializeComponent();

            player = Player;

            var context = new InstanceContext(new RedrawHandler());
            var server = new GameService.GameControllerContractClient();

            MessageBox.Show(player.NickName);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
