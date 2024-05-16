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
    public partial class AdminPage : Form
    {
        private PlayerDataAccess playerDataAccess;
        private TeamDataAccess teamDataAccess;
        private AdminDataAccess adminDataAccess;
        private string adminID;
        public AdminPage()
        {
            InitializeComponent();
            playerDataAccess = new PlayerDataAccess();
            teamDataAccess = new TeamDataAccess();
            adminDataAccess = new AdminDataAccess();
        }

        private void addPlayerBtn_Click(object sender, EventArgs e)
        {
            AddPlayerPage addPlayerPage = new AddPlayerPage();
            addPlayerPage.Show();
        }

        private void addTeamBtn_Click(object sender, EventArgs e)
        {
            AddTeamPage addTeamPage = new AddTeamPage();
            addTeamPage.Show();
        }

        private void addMatchBtn_Click(object sender, EventArgs e)
        {
            AddMatchPage addMatchPage = new AddMatchPage();
            addMatchPage.Show();
        }

        private async void playerIDUpdateBtn_Click(object sender, EventArgs e)
        {
            PlayerModel player = await playerDataAccess.GetPlayerByIDAsync(playerIDUpdateTxt.Text);
            if(player != null)
            {
                UpdatePlayerPage updatePlayerPage = new UpdatePlayerPage(player.PlayerID);
                updatePlayerPage.Show();
            }
            
        }

        private async void teamIDUpdateBtn_Click(object sender, EventArgs e)
        {
            TeamModel team = await teamDataAccess.GetTeamByIdAsync(teamIDUpdateTxt.Text);
            if(team != null)
            {
                UpdateTeamPage updateTeamPage = new UpdateTeamPage(teamIDUpdateTxt.Text);
                updateTeamPage.Show();
            }
            
        }

        private void matchIDUpdateBtn_Click(object sender, EventArgs e)
        {

        }

        private async void playerIDDeleteBtn_Click(object sender, EventArgs e)
        {
            bool success = await playerDataAccess.RemovePlayerByIdAsync(playerIDDeleteTxt.Text);
            if (success)
            {
                playerIDDeleteTxt.Text = "";
                MessageBox.Show("Player Successfully Deleted");
            }
        }

        private async void teamIDDeleteBtn_Click(object sender, EventArgs e)
        {
            bool success = await teamDataAccess.RemoveTeamByIdAsync(playerIDDeleteTxt.Text);
            if (success)
            {
                playerIDDeleteTxt.Text = "";
                MessageBox.Show("Player Successfully Deleted");
            }
        }

        private void matchIDDeleteBtn_Click(object sender, EventArgs e)
        {
            //bool success = await playerDataAccess.RemovePlayerByIdAsync(playerIDDeleteTxt.Text);
            //if (success)
            //{
            //    playerIDDeleteTxt.Text = "";
            //    MessageBox.Show("Match Successfully Deleted");
            //}

        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Try loggin in");
            string adminID = await adminDataAccess.AuthenticateAdminAsync(usernametxt.Text, passwordtxt.Text);
            if(!string.IsNullOrEmpty(adminID))
            {
                Console.WriteLine($"Log in success");
                deletePnl.Show();
                updatePnl.Show();
                addPnl.Show();
                loginPnl.Hide();
                this.adminID = adminID;
            }
            //keep in case we need to add admin later on
            //else
            //{
            //    bool success = await adminDataAccess.AddAdminAsync(new AdminModel { Username = "admin", Password = "pass" });
            //    if (success)
            //        Console.WriteLine("Successfulyl added admin");
            //    else
            //    { Console.WriteLine("Error"); }
            //}
        }
    }
}
