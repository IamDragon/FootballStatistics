using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace FootballStatistics
{
    public partial class AddPlayerPage : Form
    {
        PlayerDataAccess playerDataAccess;
        public AddPlayerPage()
        {
            InitializeComponent();
            playerDataAccess = new PlayerDataAccess();
        }

        private bool IsDataValid()
        {
            //Check if all text fields have text
            if (fullNametxt.Text == "" || nationalitytxt.Text == "" || goalstxt.Text == "" ||
                shotstakentxt.Text == "" || assiststxt.Text == "" || positiontxt.Text == "")
                return false;

            //Check if values are ints
            bool goals = int.TryParse(goalstxt.Text, out int _);
            bool shotsTaken = int.TryParse(goalstxt.Text, out int _);
            bool assists = int.TryParse(goalstxt.Text, out int _);


            return goals & shotsTaken & assists;
        }

        private void AddPlayerPage_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (!IsDataValid()) // data not in right format don't input into db{
            {
                Console.WriteLine("Data invalid");
                return;
            }
            addUserAsync();

            Console.WriteLine("Data valid Adding to db");

            //Connect to db
           

            fullNametxt.Text = string.Empty;
            nationalitytxt.Text = string.Empty;
            goalstxt.Text = string.Empty;
            shotstakentxt.Text = string.Empty;
            assiststxt.Text = string.Empty;
            positiontxt.Text = string.Empty;
        }

        private async void addUserAsync()
        {
            await playerDataAccess.AddPlayerAsync(new PlayerModel
            {
                FullName = fullNametxt.Text,
                Nationality = nationalitytxt.Text,
                Goals = int.Parse(goalstxt.Text),
                ShotsTaken = int.Parse(shotstakentxt.Text),
                Assists = int.Parse(assiststxt.Text),
                Position = positiontxt.Text
            });
        }

    }
}
