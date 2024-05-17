using MongoDB.Bson;
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
    public partial class ShowMatchPage : Form
    {

        private MatchDataAccess matchDataAccess;
        private TeamDataAccess teamDataAccess;
        private PlayerDataAccess playerDataAccess;
        private VoteDataAccess voteDataAccess;

        private MatchModel match;

        private TeamModel teamA;
        private TeamModel teamB;
        private PlayerModel teamAMVP;
        private PlayerModel teamBMVP;
        private string userID;

        public ShowMatchPage(MatchModel match, string userID = "")
        {
            InitializeComponent();
            matchDataAccess = new MatchDataAccess();
            teamDataAccess = new TeamDataAccess();
            playerDataAccess = new PlayerDataAccess();
            voteDataAccess = new VoteDataAccess();

            this.match = match;

            LoadValues();

            this.userID = userID;

            if (userID != "")
            {
                CheckIfUserHasVoted();
            }
        }

        private async void CheckIfUserHasVoted()
        {
            if (await voteDataAccess.HasUserAlreadyVotedAsync(ObjectId.Parse(userID), match.MatchID))
            {
                var vote = await voteDataAccess.GetVoteByUserAndMatchAsync(ObjectId.Parse(userID), match.MatchID);

                ObjectId? votedTeamID = vote.VotedTeamId;

                TeamModel votedTeam = await teamDataAccess.GetTeamByIdAsync(votedTeamID.ToString());

                voteExistLabel.Text = $"You have voted in favor of {votedTeam.TeamName}";
                voteExistLabel.Visible = true;
                return;                 
            }

            Console.WriteLine($"Current DateTime: {DateTime.Now.Date}");
            Console.WriteLine($"Match DateTime: {match.MatchDate.Date}");

            if (match.MatchDate.Date >= DateTime.Today.Date)
            {
              
                votePanel.Visible = true;
            }
        }

        private void ShowMatchPage_Load(object sender, EventArgs e)
        {

        }

        private async void LoadValues()
        {
            teamA = await teamDataAccess.GetTeamByIdAsync(match.TeamA.ToString());
            teamB = await teamDataAccess.GetTeamByIdAsync(match.TeamB.ToString());
           

            teamALinkLabel.Text = teamA.TeamName;
            teamBLinkLabel.Text = teamB.TeamName;
                       
            matchDateLabel.Text = match.MatchDate.Date.ToString("yyyy-MM-dd");
            teamAVotesLabel.Text = (match.teamAVotes ?? 0).ToString();
            teamBVotesLabel.Text = (match.teamBVotes ?? 0).ToString();

            voteAButton.Text = $"Vote for {teamA.TeamName}";
            voteBButton.Text = $"Vote for {teamB.TeamName}";

            if (match.Winner != null) // if this is null the values needed below is not set
            {
                Console.WriteLine(match.TeamAMVP.ToString());
                teamAMVP = await playerDataAccess.GetPlayerByIDAsync(match.TeamAMVP.ToString());
                teamBMVP = await playerDataAccess.GetPlayerByIDAsync(match.TeamBMVP.ToString());

                teamAMVPLinkLabel.Text = teamAMVP.FullName;
                teamBMVPLinkLabel.Text = teamBMVP.FullName;

                teamAScoreLabel.Text = match.TeamAGoals.ToString();
                teamBScoreLabel.Text = match.TeamBGoals.ToString();

                matchPlayedPanel.Visible = true;
            }

          
        }

        private void teamAMVPLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPlayer showPlayer = new ShowPlayer(teamAMVP.PlayerID.ToString(), userID);
            showPlayer.Show();
        }

        private void teamBMVPLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPlayer showPlayer = new ShowPlayer(teamBMVP.PlayerID.ToString(), userID);
            showPlayer.Show();
        }

        private void teamALinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowTeam showTeam = new ShowTeam(teamA.TeamID.ToString(), userID);
            showTeam.Show();
        }

        private void teamBLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowTeam showTeam = new ShowTeam(teamB.TeamID.ToString(), userID);
            showTeam.Show();
        }

        private async void voteAButton_Click(object sender, EventArgs e)
        {
            var result = await matchDataAccess.VoteForMatchAsync(ObjectId.Parse(userID), match.MatchID, teamA.TeamID);
            if (result)
            {
                ShowVoteSuccess();
            }

        }

        private async void voteBButton_Click(object sender, EventArgs e)
        {
            var result = await matchDataAccess.VoteForMatchAsync(ObjectId.Parse(userID), match.MatchID, teamB.TeamID);
            if (result)
            {
                ShowVoteSuccess();
            }
            
        }

        private void ShowVoteSuccess()
        {
            voteSuccessLabel.Visible = true;
        }
    }
}
