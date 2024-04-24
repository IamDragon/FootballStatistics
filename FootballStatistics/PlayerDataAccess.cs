using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddUser(PlayerModel newPlayer)
        {
            var players = ConnectToMongo<PlayerModel>(PlayerCollection);
            players.InsertOne(newPlayer);
        }

        private List<PlayerModel> GettAllPlayers()
        {
            var players = ConnectToMongo<PlayerModel>(PlayerCollection);
            var results = players.Find(_ => true);
            return results.ToList();
        }

        public PlayerModel GetPlayer(string playerID)
        {
            var players = ConnectToMongo<PlayerModel>(PlayerCollection);
            var result = players.Find<PlayerModel>(p => p.PlayerID == playerID);
            var list = result.ToList<PlayerModel>();
            return list.FirstOrDefault();
        }

        public List<PlayerModel> SearchPlayers(string searchString)
        {
            var players = ConnectToMongo<PlayerModel>(PlayerCollection);
            var playerFilter = Builders<PlayerModel>.Filter.Text(searchString);
            var playerQuery = players.Aggregate().Match(playerFilter);

            return playerQuery.ToList();
        }

    }
}
