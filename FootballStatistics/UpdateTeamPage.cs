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
    public partial class UpdateTeamPage : Form
    {
        private TeamDataAccess teamDataAccess;
        private string teamID;
        public UpdateTeamPage(string teamID)
        {
            InitializeComponent();
            teamDataAccess = new TeamDataAccess();
            this.teamID = teamID;
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            UpdateTeamAsync();
        }
        private async void UpdateTeamAsync()
        {
            TeamModel existingTeam = await teamDataAccess.GetTeamByIdAsync(teamID);
            if (existingTeam == null)
            {
                MessageBox.Show("TeamID invalid");
                return;
            }


            existingTeam.TeamName = teamNametxt.Text != "" ? teamNametxt.Text : existingTeam.TeamName;
            existingTeam.Country = countrytxt.Text != "" ? countrytxt.Text : existingTeam.Country;
            existingTeam.Wins = winstxt.Text != "" && int.TryParse(winstxt.Text, out int shotsTaken) ? shotsTaken : existingTeam.Wins;
            existingTeam.Losses = lossestxt.Text != "" && int.TryParse(lossestxt.Text, out int assists) ? assists : existingTeam.Losses;
            existingTeam.Games = gamesPlayedtxt.Text != "" && int.TryParse(gamesPlayedtxt.Text, out int games) ? games : existingTeam.Games;
            existingTeam.Goals = goalstxt.Text != "" && int.TryParse(goalstxt.Text, out int goals) ? goals : existingTeam.Goals;

            var results = await teamDataAccess.UpdateTeamByIdAsync(existingTeam);
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
            teamNametxt.Text = string.Empty;
            countrytxt.Text = string.Empty;
            winstxt.Text = string.Empty;
            lossestxt.Text = string.Empty;
            gamesPlayedtxt.Text = string.Empty;
            goalstxt.Text = string.Empty;
        }

        private void updatePnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateTeamPage_Load(object sender, EventArgs e)
        {

        }
    }
}
