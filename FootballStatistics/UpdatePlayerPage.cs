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
    public partial class UpdatePlayerPage : Form
    {
        private PlayerDataAccess playerDataAccess;
        private string playerID;
        public UpdatePlayerPage(string playerID)
        {
            InitializeComponent();
            playerDataAccess = new PlayerDataAccess();
            this.playerID = playerID;
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            UpdatePlayerAsync();
        }

        private async void UpdatePlayerAsync()
        {
            PlayerModel existingPlayer = await playerDataAccess.GetPlayerByIDAsync(playerID); 
            if(existingPlayer == null)
            {
                MessageBox.Show("PlayerId invalid");
                return;
            }


            existingPlayer.FullName = fullNametxt.Text != "" ? fullNametxt.Text : existingPlayer.FullName;
            existingPlayer.TeamID = teamIDtxt.Text != "" ? teamIDtxt.Text : existingPlayer.TeamID;
            existingPlayer.Nationality = nationalitytxt.Text != "" ? nationalitytxt.Text : existingPlayer.Nationality;
            existingPlayer.Goals = goalstxt.Text != "" && int.TryParse(goalstxt.Text, out int goals) ? goals : existingPlayer.Goals;
            existingPlayer.ShotsTaken = shotstakentxt.Text != "" && int.TryParse(shotstakentxt.Text, out int shotsTaken) ? shotsTaken : existingPlayer.ShotsTaken;
            existingPlayer.Assists = assiststxt.Text != "" && int.TryParse(assiststxt.Text, out int assists) ? assists : existingPlayer.Assists;
            existingPlayer.Position = positiontxt.Text != "" ? positiontxt.Text : existingPlayer.Position;

            var results = await playerDataAccess.UpdatePlayerById(existingPlayer);
            if (results.MatchedCount == 0)
                MessageBox.Show("No Matches found");
            else
            {
                MessageBox.Show("Succesfully inserted value");
                ResetTextBoxes();
            }

        }

        private void ResetTextBoxes()
        {
            fullNametxt.Text = string.Empty;
            nationalitytxt.Text = string.Empty;
            goalstxt.Text = string.Empty;
            shotstakentxt.Text = string.Empty;
            assiststxt.Text = string.Empty;
            positiontxt.Text = string.Empty;
        }
    }
}
