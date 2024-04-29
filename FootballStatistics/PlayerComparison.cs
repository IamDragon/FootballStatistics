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
    public partial class PlayerComparison : Form
    {
        List<PlayerModel> players;
        public PlayerComparison(List<PlayerModel> players)
        {
            InitializeComponent();
            this.players = players;
            LoadData();
        }

        private void LoadData()
        {
            foreach (PlayerModel player in this.players)
            {
                goalChart.Series["Goals"].Points.AddXY(player.FullName, player.Goals);
                goalChart.Series["Shots"].Points.AddXY(player.FullName, player.ShotsTaken);
                goalChart.Series["Assists"].Points.AddXY(player.FullName, player.Assists);
            }

        }

        private void PlayerComparison_Load(object sender, EventArgs e)
        {

        }
    }
}
