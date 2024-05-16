using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballStatistics
{
    internal class VoteDataAccess
    {
        private readonly string ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        private const string DatabaseName = "footballstats";
        private const string VoteCollection = "votes";


        private IMongoCollection<T> ConnectToMongo<T>(string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task<IClientSessionHandle> StartSessionAsync()
        {
            var client = new MongoClient(ConnectionString);
            var session = await client.StartSessionAsync();
            session.StartTransaction();
            return session;
        }

        public async Task<bool> HasUserAlreadyVotedAsync(ObjectId userId, ObjectId matchId)
        {
            var votes = ConnectToMongo<VoteModel>(VoteCollection);
            var existingVote = await votes.Find(vote => vote.UserId == userId && vote.MatchId == matchId).FirstOrDefaultAsync();
            return existingVote != null;
        }

        public async Task InsertVoteAsync(IClientSessionHandle session, ObjectId userId, ObjectId matchId, ObjectId votedTeamId)
        {
            var votes = ConnectToMongo<VoteModel>(VoteCollection);
            var newVote = new VoteModel
            {
                UserId = userId,
                MatchId = matchId,
                VotedTeamId = votedTeamId
            };
            await votes.InsertOneAsync(session, newVote);
        }

        public async Task<VoteModel> GetVoteByUserAndMatchAsync(ObjectId userId, ObjectId matchId)
        {
            try
            {
                var votes = ConnectToMongo<VoteModel>(VoteCollection);
                var result = await votes.Find(vote => vote.UserId == userId && vote.MatchId == matchId).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while Getting vote by user and match: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
           
        }
    }
}
