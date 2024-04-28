using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FootballStatistics
{
    public class PlayerModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PlayerID{ get; set; }
        public string TeamID { get; set; }
        public string FullName{ get; set; }
        public string Nationality { get; set; }
        public int Goals { get; set; }
        public int ShotsTaken { get; set; }
        public int Assists { get; set; }
        public string Position { get; set; }
    }
}
