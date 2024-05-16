using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatistics
{
    public class VoteModel
    {
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; }
        public ObjectId MatchId { get; set; }
        public ObjectId? VotedTeamId { get; set; }
    }
}
