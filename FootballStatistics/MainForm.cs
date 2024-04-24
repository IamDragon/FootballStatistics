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
        private string userID; //logged in userID - Login Form changes this and will have a reference
        public MainForm()
        {
            InitializeComponent();
            userDataAccess = new UserDataAccess();
            playerDataAccess = new PlayerDataAccess();
        }

        private async void Search()
        {
            //Search for players
            var playerSearch = await playerDataAccess.SearchPlayersAsync(searctxtBox.Text);

            if (playerSearch == null)
            {
                return;
            }

            foreach (var doc in playerSearch)
            {
                playersSearchResultsBox.Items.Add($"Name: {doc.FullName} | Nationality: {doc.Nationality} | Position: {doc.Position}");
                playerSearchResults.Add(doc);
            }

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
                ShowPlayer showplayerForm = new ShowPlayer(playerSearchResults[index].PlayerID);
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
        }
    }
}
