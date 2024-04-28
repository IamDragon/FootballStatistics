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
        private PlayerDataAccess playerDataAccess;
        private UserDataAccess userDataAccess;
        public ShowPlayer(string playerID, string userID = "")
        {
            InitializeComponent();
            playerDataAccess = new PlayerDataAccess();
            userDataAccess = new UserDataAccess();
            this.playerID = playerID;
            this.userID = userID;
            LoadValuesAsync();
            if(userID != "")
                favoriteBtn.Visible = true;

        }

        private async void LoadValuesAsync()
        {
            PlayerModel player = await playerDataAccess.GetPlayerByIDAsync(playerID);
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
    }
}
