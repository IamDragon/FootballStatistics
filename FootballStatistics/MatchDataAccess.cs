using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Connections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballStatistics
{
    internal class MatchDataAccess
    {
        string ConnectionString = "mongodb://user:pass@localhost:27017/";
        //private string ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        private const string DatabaseName = "fooballstats";
        private const string MatchCollection = "matches";
        private const string VoteCollection = "votes";


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

        public async Task<List<MatchModel>> SearchUpcomingMatchesByTeamIDAsync(ObjectId teamID)
        {
            try
            {
                var matches = ConnectToMongo<MatchModel>(MatchCollection);


                var matchFilter = Builders<MatchModel>.Filter.And(
                    Builders<MatchModel>.Filter.Or(
                        Builders<MatchModel>.Filter.Eq(match => match.TeamA, teamID),
                        Builders<MatchModel>.Filter.Eq(match => match.TeamB, teamID)),
                    Builders<MatchModel>.Filter.Gt(match => match.MatchDate, DateTime.Now.Date)
                );


                var sortDefinition = Builders<MatchModel>.Sort.Descending(match => match.MatchDate);


                var matchQuery = await matches.Find(matchFilter).Sort(sortDefinition).ToListAsync();

                return matchQuery;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while searching for matches by team ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<MatchModel> GetMatchByIDAsync(string matchID)
        {
            try
            {
                var matches = ConnectToMongo<MatchModel>(MatchCollection);
                var result = await matches.FindAsync<MatchModel>(p => p.MatchID.ToString() == matchID);
                var list = result.ToList<MatchModel>();
                if (list.Count > 0)
                    return list.FirstOrDefault();
                else
                    return null;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while retrieving match by ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
        }


        public async Task<List<MatchModel>> GetMatchesByDate(DateTime date)
        {
            try
            {
                var matches = ConnectToMongo<MatchModel>(MatchCollection);


                var startOfDayLocal = date.Date;
                var endOfDayLocal = startOfDayLocal.AddDays(1);

                var startOfDayUtc = startOfDayLocal.ToUniversalTime();
                var endOfDayUtc = endOfDayLocal.ToUniversalTime();

                Console.WriteLine("Start of day: " + startOfDayLocal);
                Console.WriteLine("End of day: " + endOfDayLocal);

                var dateFilter = Builders<MatchModel>.Filter.And(
                    Builders<MatchModel>.Filter.Gte(match => match.MatchDate, startOfDayLocal),
                    Builders<MatchModel>.Filter.Lte(match => match.MatchDate, endOfDayLocal)
           );



                var result = await matches.Find(dateFilter).ToListAsync();

                if (result.Count > 0)
                {
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while retrieving match by ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
        }

        public async Task<List<MatchModel>> SearchPlayedMatchesByTeamIDAsync(ObjectId teamID)
        {
            try
            {
                var matches = ConnectToMongo<MatchModel>(MatchCollection);

                var matchFilter = Builders<MatchModel>.Filter.And(
                    Builders<MatchModel>.Filter.Or(
                        Builders<MatchModel>.Filter.Eq(match => match.TeamA, teamID),
                        Builders<MatchModel>.Filter.Eq(match => match.TeamB, teamID)),
                    Builders<MatchModel>.Filter.Lt(match => match.MatchDate, DateTime.Now.Date)
                );


                var sortDefinition = Builders<MatchModel>.Sort.Descending(match => match.MatchDate);


                var matchQuery = await matches.Find(matchFilter).Sort(sortDefinition).ToListAsync();

                return matchQuery;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while searching for matches by team ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<List<MatchModel>> GetMatchesDescendingAsync()
        {
            try
            {
                var matches = ConnectToMongo<MatchModel>(MatchCollection);
                var sortDefinition = Builders<MatchModel>.Sort.Descending(match => match.MatchDate);

                var matchQuery = await matches.Find(Builders<MatchModel>.Filter.Empty).Sort(sortDefinition).ToListAsync();

                return matchQuery;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while retrieveing matches: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> VoteForMatchAsync(ObjectId userId, ObjectId matchId, ObjectId votedTeamId)
        {
            var voteDataAccess = new VoteDataAccess(); // Initialize VoteDataAccess
            using (var session = await voteDataAccess.StartSessionAsync())
            {
                try
                {
                    var matches = ConnectToMongo<MatchModel>(MatchCollection);

                    // Check if the user has already voted for this match
                    if (await voteDataAccess.HasUserAlreadyVotedAsync(userId, matchId))
                    {
                        MessageBox.Show("You have already voted for this match.", "Duplicate Vote", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    // Insert the new vote
                    await voteDataAccess.InsertVoteAsync(session, userId, matchId, votedTeamId);

                    // Retrieve the match to determine which team's vote count to increment
                    var match = await matches.Find(m => m.MatchID == matchId).FirstOrDefaultAsync();
                    if (match == null)
                    {
                        MessageBox.Show("Match not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        await session.AbortTransactionAsync();
                        return false;
                    }

                    // Determine the field to update based on the voted team ID
                    var fieldToUpdate = votedTeamId == match.TeamA ? nameof(MatchModel.teamAVotes) : nameof(MatchModel.teamBVotes);
                    var updateDefinition = Builders<MatchModel>.Update.Inc(fieldToUpdate, 1);

                    var updateResult = await matches.UpdateOneAsync(
                        session,
                        m => m.MatchID == matchId,
                        updateDefinition);

                    if (updateResult.ModifiedCount == 0)
                    {
                        MessageBox.Show("Failed to update the match vote count.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        await session.AbortTransactionAsync();
                        return false;
                    }

                    await session.CommitTransactionAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await session.AbortTransactionAsync();
                    MessageBox.Show($"An error occurred while voting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}
