using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FootballStatistics
{
    public class TeamModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TeamID { get; set; }
        public string TeamName { get; set; }
        public string Country { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Games { get; set; }
        public int Goals { get; set; }
    }
}
