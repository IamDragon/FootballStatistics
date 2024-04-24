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
        List<PlayerModel> playerSearchResults = new List<PlayerModel>();
        List<TeamModel> teamSearchResults = new List<TeamModel>();
        UserDataAccess userDataAccess;
        private  string userID; //logged in userID - Login Form changes this and will have a reference
        public MainForm()
        {
            InitializeComponent();
            userDataAccess = new UserDataAccess();
        }

        private void Search()
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var players = db.GetCollection<PlayerModel>("players");
            var teams = db.GetCollection<TeamModel>("teams");
            //var matches = db.GetCollection<PlayerModel>("matches");
            Console.WriteLine(userID);

            var searchRequest = new { Query = searctxtBox.Text };

            //Search for players
            var playerFilter = Builders<PlayerModel>.Filter.Text(searchRequest.Query);
            var playerQuery = players.Aggregate().Match(playerFilter);

            foreach (var doc in playerQuery.ToList())
            {
                playersSearchResultsBox.Items.Add($"Name: {doc.FullName} | Nationality: {doc.Nationality} | Position: {doc.Position}");
                playerSearchResults.Add(doc);
            }

            //search for teams
            //var teamFilter = Builders<TeamModel>.Filter.Text(searchRequest.Query);
            //var teamQuery = teams.Aggregate().Match(teamFilter);

            //foreach (var doc in teamQuery.ToList())
            //{
            //    playersSearchResultsBox.Items.Add($"TeamName: {doc.TeamName} | Country: {doc.Country}");
            //    teamSearchResults.Add(doc);
            //}

            //search for matches
            //var matchFilter = Builders<Match>.Filter.Text(searchRequest.Query);
            //var MatchQuery = players.Aggregate().Match(matchFilter);

            //foreach (var doc in MatchQuery.ToList())
            //{
            //    playersSearchResultsBox.Items.Add($"Name: {doc.FullName} | Nationality: {doc.Nationality} | Position: {doc.Position}");
            //    playerSearchResults.Add(doc);
            //}
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
            string userID = userDataAccess.AuthenticateUser(usernametxt.Text, passwordtxt.Text);
            if (userID == "")
            {
                MessageBox.Show("Username or Password is incorrect or user does not exist");

            }
            else
            {
                MessageBox.Show("Log in successful");
                this.userID = userID;
                usernametxt.Hide();
                usernamelbl.Hide();
                passwordtxt.Hide();
                passwprdlbl.Hide();
                loginBtn.Hide();
                signupBtn.Hide();
            }
        }
    }
}
