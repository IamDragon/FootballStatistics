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
    public partial class AddTeamPage : Form
    {
        private TeamDataAccess teamDataAccess;
        public AddTeamPage()
        {
            InitializeComponent();

            teamDataAccess = new TeamDataAccess();
        }

        private void AddTeamPage_Load(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (!IsDataValid()) // data not in right format don't input into db{
            {
                Console.WriteLine("Data invalid");
                return;
            }

            AddTeamAsync();

            Console.WriteLine("Data valid Adding to db");

            //Connect to db

            ResetTextBoxes();
      
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

        private async void AddTeamAsync()
        {
            await teamDataAccess.AddTeamAsync(new TeamModel
            {
                TeamName = teamNametxt.Text,
                Country = countrytxt.Text,
                Wins = int.Parse(winstxt.Text),
                Losses = int.Parse(lossestxt.Text),
                Games = int.Parse(gamesPlayedtxt.Text),
                Goals = int.Parse(goalstxt.Text)
            });
        }

        private bool IsDataValid()
        {
            //Check if all text fields have text
            if (teamNametxt.Text == "" || countrytxt.Text == "" || winstxt.Text == "" ||
                lossestxt.Text == "" || gamesPlayedtxt.Text == "" || goalstxt.Text == "")
                return false;

            //Check if values are ints
            bool goals = int.TryParse(goalstxt.Text, out int _);
            bool wins = int.TryParse(winstxt.Text, out int _);
            bool losses = int.TryParse(lossestxt.Text, out int _);
            bool gamesPlayed = int.TryParse(gamesPlayedtxt.Text, out int _);


            return goals & wins & losses & gamesPlayed;
        }
    }
}
