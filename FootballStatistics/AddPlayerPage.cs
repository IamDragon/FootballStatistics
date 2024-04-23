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
        string connectionString = "mongodb://user:pass@localhost:27017/";
        string databaseName = "fooballstats";
        public AddPlayerPage()
        {
            InitializeComponent();



        }

        private bool IsDataValid()
        {
            //parse string to int
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

            Console.WriteLine("Data valid Adding to db");

            //Connect to db
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<PlayerModel>("players");

            //Create and insert player
            var player = new PlayerModel { FullName = fullNametxt.Text, Nationality = nationalitytxt.Text, Goals = int.Parse(goalstxt.Text),
                ShotsTaken =  int.Parse(shotstakentxt.Text), Assists = int.Parse(assiststxt.Text), Position = positiontxt.Text};
            collection.InsertOne(player);

            fullNametxt.Text = "";
        }

    }
}
