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
        public DateTime MatchDate { get; set; }
        public ObjectId? Winner { get; set; }
        public ObjectId TeamA { get; set; }
        public ObjectId TeamB { get; set; }

        public ObjectId? TeamAMVP { get; set; }
        public ObjectId? TeamBMVP { get; set; }
        public int? TeamAGoals { get; set; }
        public int? TeamBGoals { get; set; }

        public int? teamAVotes { get; set; }
        public int? teamBVotes { get; set; }
    }
}
