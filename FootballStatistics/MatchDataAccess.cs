using MongoDB.Driver;
using MongoDB.Driver.Core.Connections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballStatistics
{
    internal class MatchDataAccess
    {
        private string ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        private const string DatabaseName = "fooballstats";
        private const string MatchCollection = "matches";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task AddMatchAsync(MatchModel match)
        {
            try
            {
                var matches = ConnectToMongo<MatchModel>(MatchCollection);
                await matches.InsertOneAsync(match);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding a match: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public async Task<ReplaceOneResult> UpdateMatchById(MatchModel updatedMatch)
        {
            try
            {
                var matches = ConnectToMongo<MatchModel>(MatchCollection);
                var resutls = await matches.ReplaceOneAsync(m => m.MatchID == updatedMatch.MatchID, updatedMatch, new ReplaceOptions { IsUpsert = false });
                return resutls;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating match by ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private async Task<List<MatchModel>> GetAllMatchesAsync()
        {
            try
            {
                var matches = ConnectToMongo<MatchModel>(MatchCollection);
                var results = await matches.FindAsync(_ => true);
                return results.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving all matches: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<MatchModel>();
            }
        }

        public async Task<List<MatchModel>> SearchMatchesAsync(string searchString)
        {
            try
            {
                var matches = ConnectToMongo<MatchModel>(MatchCollection);
                var matchFilter = Builders<MatchModel>.Filter.Text(searchString);
                var matchQuery = await matches.Aggregate().Match(matchFilter).ToListAsync();

                return matchQuery;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while searching for matches: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
    }
}
