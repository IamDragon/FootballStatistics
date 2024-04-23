using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FootballStatistics
{
    public class AdminModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AdminID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
