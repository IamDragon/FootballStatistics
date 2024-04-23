using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FootballStatistics
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserID { get; set; }
        public string Username{ get; set; }
        public string Password { get; set; }
        public string FavoritePlayer{ get; set; }
        public string FavoriteTeam { get; set; }

    }
}
