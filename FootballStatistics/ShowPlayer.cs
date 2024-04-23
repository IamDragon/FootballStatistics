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

namespace FootballStatistics
{
    public partial class ShowPlayer : Form
    {
        string playerId;
        string connectionString = "mongodb://user:pass@localhost:27017/";
        string databaseName = "fooballstats";
        public ShowPlayer(string playerID)
        {
            playerId = playerID;
            InitializeComponent();
            LoadValues();
        }

        private void LoadValues()
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<PlayerModel>("players");

            var result = collection.Find<PlayerModel>(p => p.PlayerID == playerId);
            var list = result.ToList<PlayerModel>();
            PlayerModel player = list[0]; //only 1 will exist since PlayerID is unique
            fullnamnelblChange.Text = player.FullName;
            nationalitylblChange.Text = player.Nationality;
            goalslblChange.Text = player.Goals.ToString();
            shotstakenlblChange.Text = player.ShotsTaken.ToString();
            assistslblChange.Text = player.Assists.ToString();
            positionlblChange.Text = player.Position;
        }

        private void ShowPlayer_Load(object sender, EventArgs e)
        {

        }
    }
}
