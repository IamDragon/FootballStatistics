using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballStatistics
{
    internal class PlayerDataAccess
    {
        private const string ConnectionString = "mongodb://user:pass@localhost:27017/";
        private const string DatabaseName = "fooballstats";
        private const string PlayerCollection = "players";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task AddPlayerAsync(PlayerModel newPlayer)
        {
            try
            {
                var players = ConnectToMongo<PlayerModel>(PlayerCollection);
                await players.InsertOneAsync(newPlayer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding player: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task<List<PlayerModel>> GetAllPlayersAsync()
        {
            try
            {
                var players = ConnectToMongo<PlayerModel>(PlayerCollection);
                var results = await players.FindAsync(_ => true);
                return results.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving all players: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<PlayerModel>();
            }
        }

        public async Task<PlayerModel> GetPlayerAsync(string playerID)
        {
            try
            {
                var players = ConnectToMongo<PlayerModel>(PlayerCollection);
                var result = await players.FindAsync<PlayerModel>(p => p.PlayerID == playerID);
                var list = result.ToList<PlayerModel>();
                return list.FirstOrDefault();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while retrieving player by ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }


        }

        public async Task<List<PlayerModel>> SearchPlayersAsync(string searchString)
        {
            try
            {
                var players = ConnectToMongo<PlayerModel>(PlayerCollection);
                var playerFilter = Builders<PlayerModel>.Filter.Text(searchString);
                var playerQuery = await players.Aggregate().Match(playerFilter).ToListAsync();

                return playerQuery;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while searching for players: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

    }
}
