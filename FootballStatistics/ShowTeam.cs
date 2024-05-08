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
    public partial class ShowTeam : Form
    {
        private string teamID;
        private string userID;
        TeamDataAccess teamDataAccess;
        private UserDataAccess userDataAccess;

        public ShowTeam(string teamID, string userID = "")
        {
            this.teamID = teamID;
            teamDataAccess = new TeamDataAccess();
            userDataAccess = new UserDataAccess();
            InitializeComponent();

            LoadValuesAsync();
            this.userID = userID;

            if (this.userID != "")
            {
                favoriteBtn.Visible = true;
            }
        }

        private void ShowTeam_Load(object sender, EventArgs e)
        {

        }

        private async void LoadValuesAsync()
        {
            TeamModel team = await teamDataAccess.GetTeamByIdAsync(teamID);

            teamNamelblChange.Text = team.TeamName;
            countrylblChange.Text = team.Country;
            winslblChange.Text = team.Wins.ToString();
            losseslblChange.Text = team.Losses.ToString();
            gameslblChange.Text = team.Games.ToString();
            goalslblChange.Text = team.Goals.ToString();
        }

        private async void favoriteBtn_Click(object sender, EventArgs e)
        {
            UserModel currentUser = await userDataAccess.GetUserByIDAsync(userID);
            if (currentUser == null)
                return;
            currentUser.FavoriteTeam = teamID;
            var results = await userDataAccess.UpdateUserById(currentUser);

            if (results.MatchedCount == 0)
                MessageBox.Show("No Matches found");
            else
            {
                MessageBox.Show("Succesfully updated favorite team");
            }
            
        }
    }
}
