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
        private string playerID;
        private string userID;
        private PlayerModel playerModel;
        private PlayerDataAccess playerDataAccess;
        private TeamDataAccess teamDataAccess;
        private UserDataAccess userDataAccess;
        public ShowPlayer(string playerID, string userID = "")
        {
            InitializeComponent();
            playerDataAccess = new PlayerDataAccess();
            userDataAccess = new UserDataAccess();
            teamDataAccess = new TeamDataAccess();
            this.playerID = playerID;
            this.userID = userID;
            LoadValuesAsync();
            if(userID != "")
                favoriteBtn.Visible = true;

        }

        private async void LoadValuesAsync()
        {
            playerModel = await playerDataAccess.GetPlayerByIDAsync(playerID);
            TeamModel team = await teamDataAccess.GetTeamByIdAsync(playerModel.TeamID); 

            fullnamnelblChange.Text = playerModel.FullName;
            nationalitylblChange.Text = playerModel.Nationality;
            goalslblChange.Text = playerModel.Goals.ToString();
            shotstakenlblChange.Text = playerModel.ShotsTaken.ToString();
            assistslblChange.Text = playerModel.Assists.ToString();
            positionlblChange.Text = playerModel.Position;
            teamLinkLabel.Text = team.TeamName;
           

        }

        private void ShowPlayer_Load(object sender, EventArgs e)
        {

        }

        private async void favoriteBtn_Click(object sender, EventArgs e)
        {
            UserModel currentUser = await userDataAccess.GetUserByIDAsync(userID);
            if (currentUser == null)
                return;
            currentUser.FavoritePlayer = playerID;
            var results = await userDataAccess.UpdateUserById(currentUser);

            if (results.MatchedCount == 0)
                MessageBox.Show("No Matches found");
            else
            {
                MessageBox.Show("Succesfully updated favorite");
            }
        }

        private void teamLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowTeam showTeamPage = new ShowTeam(playerModel.TeamID, userID);

            showTeamPage.Show();
        }
    }
}
