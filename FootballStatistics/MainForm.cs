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
using MongoDB.Driver.Linq;
using MongoDB.Bson;

namespace FootballStatistics
{
    public partial class MainForm : Form
    {
        string connectionString = "mongodb://user:pass@localhost:27017/";
        string databaseName = "fooballstats";

        //searchResults
        List<PlayerModel> playerSearchResults = new List<PlayerModel>();
        List<TeamModel> teamSearchResults = new List<TeamModel>();

        //DataAccess
        UserDataAccess userDataAccess;
        PlayerDataAccess playerDataAccess;
        TeamDataAccess teamDataAccess;
        private string userID; //logged in userID - Login Form changes this and will have a reference
        public MainForm()
        {
            InitializeComponent();
            userDataAccess = new UserDataAccess();
            playerDataAccess = new PlayerDataAccess();
            teamDataAccess = new TeamDataAccess();
        }

        private async void Search()
        {
            playerSearchResults.Clear();
            playersSearchResultsBox.Items.Clear();
            teamSearchResults.Clear();
            teamSearchResultsBox.Items.Clear();
            SetNoResultTextVisibility(false);

            bool noResults = true;

            //Search for players
            var playerSearch = await playerDataAccess.SearchPlayersAsync(searctxtBox.Text);

            if (playerSearch.Count > 0)
            {
                noResults = false;
                foreach (var player in playerSearch)
                {
                    playersSearchResultsBox.Items.Add($"Name: {player.FullName} | Nationality: {player.Nationality} | Position: {player.Position}");
                    playerSearchResults.Add(player);
                }
            }
   
            //Search for teams
            var teamSearch = await teamDataAccess.SearchTeamsAsync(searctxtBox.Text);

            if (teamSearch.Count > 0)
            {
                noResults = false;

                foreach (var team in teamSearch)
                {
                    teamSearchResultsBox.Items.Add($"TeamName: {team.TeamName} | country: {team.Country}");
                    teamSearchResults.Add(team);
                }
            }

            if (noResults)
            {
                SetNoResultTextVisibility(true);
            }
        }

        private void SetNoResultTextVisibility(bool show)
        {
         
            noResultslbl.Visible = show;
            
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void searchResultsBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.playersSearchResultsBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                ShowPlayer showplayerForm = new ShowPlayer(playerSearchResults[index].PlayerID, userID);
                showplayerForm.Show();
            }
        }

        private void teamSearchResultsBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.teamSearchResultsBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //ShowTeam showTeamForm = new ShowPlayer(teamSearchResults[index].TeamID);
                //showTeamForm.Show();
            }
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            SignUpForm signupForm = new SignUpForm();
            signupForm.Show();
        }

        private void loginBtn_Click_1(object sender, EventArgs e)
        {
            Login();
        }

        private async void Login()
        {
            string userID = await userDataAccess.AuthenticateUserAsync(usernametxt.Text, passwordtxt.Text);
            if (string.IsNullOrEmpty(userID))
            {
                MessageBox.Show("Username or Password is incorrect or user does not exist");
            }
            else
            {
                MessageBox.Show("Log in successful");
                this.userID = userID;
                usernametxt.Hide();
                usernametxt.Text = "";
                usernamelbl.Hide();
                passwordtxt.Hide();
                passwordtxt.Text = "";
                passwprdlbl.Hide();
                loginBtn.Hide();
                signupBtn.Hide();
                logoutbtn.Show();
                adminLogInBtn.Hide();
                favoritePnl.Show();
                LoadUserFavorites();
            }
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void LogOut()
        {
            userID = "";
            usernametxt.Show();
            usernamelbl.Show();
            passwordtxt.Show();
            passwprdlbl.Show();
            loginBtn.Show();
            signupBtn.Show();
            logoutbtn.Hide();
            adminLogInBtn.Show();
            favoritePnl.Hide();
        }

        private async void LoadUserFavorites()
        {
            UserModel user = await userDataAccess.GetUserByIDAsync(userID);
            PlayerModel player = await playerDataAccess.GetPlayerByIDAsync(user.FavoritePlayer);
            if(player != null)
                favoritePlayerBtn.Text = player.FullName;

            TeamModel team = await teamDataAccess.GetTeamByIdAsync(user.FavoritePlayer);
            if(team != null)
                favoriteTeamBtn.Text = team.TeamName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
        }

        private async void favoritePlayerBtn_Click(object sender, EventArgs e)
        {
            UserModel user = await userDataAccess.GetUserByIDAsync(userID);
            if (user.FavoritePlayer != null)
            {
                ShowPlayer showPlayer = new ShowPlayer(user.FavoritePlayer);
                showPlayer.Show();
            }
        }

        private void favoriteTeamBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
