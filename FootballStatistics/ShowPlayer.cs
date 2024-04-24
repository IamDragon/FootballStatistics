using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballStatistics
{
    public partial class ShowPlayer : Form
    {
        string playerID;
        PlayerDataAccess playerDataAccess;
        public ShowPlayer(string playerID)
        {
            InitializeComponent();
            playerDataAccess = new PlayerDataAccess();
            this.playerID = playerID;
            LoadValues();
        }

        private void LoadValues()
        {
            PlayerModel player = playerDataAccess.GetPlayer(playerID);
            fullnamnelblChange.Text = player.FullName;
            nationalitylblChange.Text = player.Nationality;
            goalslblChange.Text = player.Goals.ToString();
            shotstakenlblChange.Text = player.ShotsTaken.ToString();
            assistslblChange.Text = player.Assists.ToString();
            positionlblChange.Text = player.Position;
        }

        private void ShowPlayer_Load(object sender, EventArgs e)
        {

        }
    }
}
