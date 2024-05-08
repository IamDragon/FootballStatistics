using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;

namespace FootballStatistics
{
    public partial class AddMatchPage : Form
    {
        private bool upcomingMatch;
        private MatchDataAccess matchDataAccess;
        private TeamDataAccess teamDataAccess;
        private PlayerDataAccess playerDataAccess;

        private List<TeamModel> teamSearchResults = new List<TeamModel>();
        private List<PlayerModel> teamAplayers = new List<PlayerModel>();
        private List<PlayerModel> teamBplayers = new List<PlayerModel>();


        public AddMatchPage()
        {
            InitializeComponent();
            matchDataAccess = new MatchDataAccess();
            teamDataAccess = new TeamDataAccess();
            playerDataAccess = new PlayerDataAccess();
        }

        private void TeamWinnerCheckboxChanged(CheckBox checkBox)
        {
            if (checkBox == teamAWinCheckbox) 
            {
                teamBWinCheckbox.Checked = false;
            }
            else
            {
                teamAWinCheckbox.Checked = false;
            }
        }

        private void teamBWinCheckbox_Click(object sender, EventArgs e)
        {
            TeamWinnerCheckboxChanged(teamBWinCheckbox);
        }

        private void teamAWinCheckbox_Click(object sender, EventArgs e)
        {
            TeamWinnerCheckboxChanged(teamAWinCheckbox);
        }

        private void AddMatchPage_Load(object sender, EventArgs e)
        {

        }

        private async void AddMatchButton_Click(object sender, EventArgs e)
        {
            if (!IsDataValid()) // data not in right format don't input into db{
            {
                Console.WriteLine("Data invalid");
                return;
            }

            if (!await IsTeamsIdValidAsync())
            {
                return;
            }

            AddMatchAsync();


        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            Search();
        }

        private async void Search()
        {
            successLbl.Visible = false;

            SetNoResultTextVisibility(false);


            teamSearchResults.Clear();
            teamSearchResultsBox.Items.Clear();

            bool noResults = true;

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

        private void SetNoResultTextVisibility(bool visible)
        {
            noResultslbl.Visible = visible;
        }


        private void SetUpcomingMatchPanelsVisibility(bool visibility)
        {
            teamApanel2.Visible = visibility;
            teamBpanel2.Visible = visibility;
            playerPanel.Visible = visibility;
        }


        private bool IsDataValid()
        {

            //Check if all text fields have text

            if (!upcomingMatch)
            {
                if (teamAmvpIDlbl.Text == "ID" || teamAGoalstextBox.Text == "" ||
                 teamAVotesTextbox.Text == "" || teamBmvpIDlbl.Text == "ID" ||
                 teamBGoalsTextBox.Text == "" || teamBVotesTextBox.Text == "" || !teamAWinCheckbox.Checked && !teamBWinCheckbox.Checked)
                {
                    return false;
                }
            }

            //Check if values are ints

            if (!upcomingMatch)
            {
                bool aGoals = int.TryParse(teamAGoalstextBox.Text, out int _);
                bool bGoals = int.TryParse(teamBGoalsTextBox.Text, out int _);

                bool aVotes = int.TryParse(teamAVotesTextbox.Text, out int _);
                bool bVotes = int.TryParse(teamBVotesTextBox.Text, out int _);

                return aGoals & bGoals & aVotes & bVotes;

            }

            return true;
        }

        private async Task<bool> IsTeamsIdValidAsync()
        {

            if (await teamDataAccess.GetTeamByIdAsync(teamAIdLbl.Text) == null || await teamDataAccess.GetTeamByIdAsync(teamBIdLbl.Text) == null)
            {
                return false;
            }

            if (teamAIdLbl.Text == teamBIdLbl.Text)
            {
                return false;
            }

            return true;
        }

        private void matchDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // If the match date is in the future, it's an upcoming match, otherwise the match has already happened

            upcomingMatch = matchDateTimePicker.Value.Date <= DateTime.Today ? false : true;

            SetUpcomingMatchPanelsVisibility(!upcomingMatch); // Make the panel visible if the match has happened
        }

        private async void AddMatchAsync()
        {
            if (upcomingMatch)
            {
                await matchDataAccess.AddMatchAsync(new MatchModel
                {
                    TeamA = ObjectId.Parse(teamAIdLbl.Text),
                    TeamB = ObjectId.Parse(teamBIdLbl.Text),
                    MatchDate = matchDateTimePicker.Value.Date,
                });
            }
            else
            {
                ObjectId winner;
                if (teamAWinCheckbox.Checked)
                {
                    winner = ObjectId.Parse(teamAIdLbl.Text);
                }
                else
                {
                    winner = ObjectId.Parse(teamBIdLbl.Text);
                }

                await matchDataAccess.AddMatchAsync(new MatchModel
                {
                    Winner = winner,
                    TeamA = ObjectId.Parse(teamAIdLbl.Text),
                    TeamB = ObjectId.Parse(teamBIdLbl.Text),
                    MatchDate = matchDateTimePicker.Value.Date,
                    TeamAMVP = ObjectId.Parse(teamAmvpIDlbl.Text),
                    TeamBMVP = ObjectId.Parse(teamBmvpIDlbl.Text),
                    TeamAGoals = int.Parse(teamAGoalstextBox.Text),
                    TeamBGoals = int.Parse(teamBGoalsTextBox.Text),
                    teamAVotes = int.Parse(teamAVotesTextbox.Text),
                    teamBVotes = int.Parse(teamBVotesTextBox.Text)
                });
            }

            successLbl.Visible = true;

            Reset();
          


        }

        private void Reset()
        {
            teamAIdLbl.Text = "ID";
            teamBIdLbl.Text = "ID";
            teamAmvpIDlbl.Text = "ID";
            teamBmvpIDlbl.Text = "ID";
            teamAGoalstextBox.Text = string.Empty;
            teamBGoalsTextBox.Text = string.Empty;
            teamAVotesTextbox.Text = string.Empty;
            teamBVotesTextBox.Text = string.Empty;

            teamSearchResultsBox.Items.Clear();
            TeamAPlayersBox.Items.Clear();
            TeamBPlayersBox.Items.Clear();

            teamAWinCheckbox.Checked = false;
            teamBWinCheckbox.Checked = false;
        }

        private void AddTeamAbtn_Click(object sender, EventArgs e)
        {
            int index = teamSearchResultsBox.SelectedIndex;

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                teamAIdLbl.Text = teamSearchResults[index].TeamID;
                ShowTeamAPlayers();
            }
        }

        private void AddTeamBbtn_Click(object sender, EventArgs e)
        {
            int index = teamSearchResultsBox.SelectedIndex;

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                teamBIdLbl.Text = teamSearchResults[index].TeamID;
                ShowTeamBPlayers();
            }
        }

        private async void ShowTeamAPlayers()
        {
            TeamAPlayersBox.Items.Clear();
            teamAplayers = await playerDataAccess.GetPlayersByTeamId(teamAIdLbl.Text);

            if (teamAplayers != null)
            {
                foreach (var player in teamAplayers)
                {
                    TeamAPlayersBox.Items.Add($"Name: {player.FullName} | Nationality: {player.Nationality} | Position: {player.Position}");
                }
            }

        }

        private async void ShowTeamBPlayers()
        {
            TeamBPlayersBox.Items.Clear();

            teamBplayers = await playerDataAccess.GetPlayersByTeamId(teamBIdLbl.Text);

            if (teamBplayers != null)
            {
                foreach (var player in teamBplayers)
                {
                    TeamBPlayersBox.Items.Add($"Name: {player.FullName} | Nationality: {player.Nationality} | Position: {player.Position}");
                }
            }
        }

        private void AddTeamAmvpBtn_Click(object sender, EventArgs e)
        {
            int index = TeamAPlayersBox.SelectedIndex;

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                teamAmvpIDlbl.Text = teamAplayers[index].TeamID;
            }
        }

        private void AddTeamBmvpBtn_Click(object sender, EventArgs e)
        {
            int index = TeamBPlayersBox.SelectedIndex;

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                teamBmvpIDlbl.Text = teamBplayers[index].TeamID;
            }
        }
    }
}
