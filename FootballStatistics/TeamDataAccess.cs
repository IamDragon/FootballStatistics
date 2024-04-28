using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballStatistics
{
    internal class TeamDataAccess
    {
        private const string ConnectionString = "mongodb://user:pass@localhost:27017/";
        private const string DatabaseName = "fooballstats";
        private const string TeamCollection = "teams";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task AddTeamAsync(TeamModel newTeam)
        {
            try
            {
                var teams = ConnectToMongo<TeamModel>(TeamCollection);
                await teams.InsertOneAsync(newTeam);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding team: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task<List<TeamModel>> GetAllTeamsAsync()
        {
            try
            {
                var teams = ConnectToMongo<TeamModel>(TeamCollection);
                var results = await teams.FindAsync(_ => true);
                return results.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving all teams: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<TeamModel>();
            }
        }

        public async Task<TeamModel> GetTeamByIdAsync(string teamID)
        {
            try
            {
                var teams = ConnectToMongo<TeamModel>(TeamCollection);
                var result = await teams.FindAsync<TeamModel>(p => p.TeamID == teamID);
                var list = result.ToList<TeamModel>();
                if (list.Count > 0)
                    return list.FirstOrDefault();
                else
                    return null;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while retrieving team by ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
        }

        public async Task<List<TeamModel>> SearchTeamsAsync(string searchString)
        {
            try
            {
                var teams = ConnectToMongo<TeamModel>(TeamCollection);
                var teamFilter = Builders<TeamModel>.Filter.Text(searchString);
                var teamQuery = await teams.Aggregate().Match(teamFilter).ToListAsync();

                return teamQuery;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while searching for teams: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public async Task<bool> RemoveTeamByIdAsync(string teamId)
        {
            try
            {
                var teams = ConnectToMongo<PlayerModel>(TeamCollection);
                var result = await teams.DeleteOneAsync(t => t.TeamID == teamId);
                if (result.DeletedCount >= 1)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching for players: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<ReplaceOneResult> UpdateTeamById(TeamModel existingTeam)
        {
            try
            {
                var teams = ConnectToMongo<TeamModel>(TeamCollection);
                var resutls = await teams.ReplaceOneAsync(t => t.TeamID == existingTeam.TeamID, existingTeam, new ReplaceOptions { IsUpsert = false });
                return resutls;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating player: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }

}

