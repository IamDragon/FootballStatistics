using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace FootballStatistics
{
    internal class MatchModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MatchID { get; set; }
        public int? Winner { get; set; }
        public int TeamA { get; set; }
        public int TeamB { get; set; }

        public int? TeamAMVP { get; set; }
        public int? TeamBMVP { get; set; }
        public int? TeamAGoals { get; set; }
        public int? TeamBGoals { get; set; }

        public int? teamAVoats { get; set; }
        public int? teamBVoats { get; set; }
    }
}
