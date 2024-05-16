using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
        private MatchDataAccess matchDataAccess;

        private List<MatchModel> upcomingMatches = new List<MatchModel>();
        private List<MatchModel> playedMatches = new List<MatchModel>();

        public ShowTeam(string teamID, string userID = "")
        {
            this.teamID = teamID;
            teamDataAccess = new TeamDataAccess();
            userDataAccess = new UserDataAccess();
            matchDataAccess = new MatchDataAccess();

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

            upcomingMatches = await GetUpcomingMatchesAsync();

            if (upcomingMatches != null)
            {
                foreach (var match in upcomingMatches)
                {
                    var teamA = await teamDataAccess.GetTeamByIdAsync(match.TeamA.ToString());
                    var teamB = await teamDataAccess.GetTeamByIdAsync(match.TeamB.ToString());

                    upcomingMatchesListBox.Items.Add($"{teamA.TeamName} vs {teamB.TeamName}. Scheduled for {match.MatchDate.Date.ToString("yyyy-MM-dd")}");
                }
            }

            playedMatches = await GetPlayedMatchesAsync();

            if (playedMatches != null)
            {
                foreach (var match in playedMatches)
                {
                    var teamA = await teamDataAccess.GetTeamByIdAsync(match.TeamA.ToString());
                    var teamB = await teamDataAccess.GetTeamByIdAsync(match.TeamB.ToString());

                    playedMatchesListBox.Items.Add($"{teamA.TeamName} vs {teamB.TeamName}  {match.TeamAGoals} - {match.TeamBGoals}    {match.MatchDate.Date.ToString("yyyy-MM-dd")}");
                }
            }
        }
        private async Task<List<MatchModel>> GetUpcomingMatchesAsync()
        {
            return await matchDataAccess.SearchUpcomingMatchesByTeamIDAsync(ObjectId.Parse(teamID));
        }

        private async Task<List<MatchModel>> GetPlayedMatchesAsync()
        {
            return await matchDataAccess.SearchPlayedMatchesByTeamIDAsync(ObjectId.Parse(teamID));
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

        private void playedMatchesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.playedMatchesListBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                ShowMatchPage showMatchForm = new ShowMatchPage(playedMatches[index], userID);
                showMatchForm.Show();
            }
        }

        private void upcomingMatchesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.upcomingMatchesListBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                ShowMatchPage showMatchForm = new ShowMatchPage(upcomingMatches[index], userID);
                showMatchForm.Show();
            }
        }
    }
}
