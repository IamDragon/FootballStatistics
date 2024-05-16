using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using FootballStatistics;

internal static class Program
{

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        //Connect to db
        string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        string databaseName = "fooballstats";
        string PlayersCollection = "players";
        string TeamsCollection = "teams";
        string MatchCollection = "matches";
        //string matches = "matches";

        var client = new MongoClient(connectionString);
        var db = client.GetDatabase(databaseName);
        var players = db.GetCollection<PlayerModel>(PlayersCollection);
        var teams = db.GetCollection<TeamModel>(TeamsCollection);
        var matches = db.GetCollection<MatchModel>(MatchCollection);

        //Create index for searching
        var playerName = Builders<PlayerModel>.IndexKeys.Text(player => player.FullName);
        var playerNationality = Builders<PlayerModel>.IndexKeys.Text(player => player.Nationality);
        var playerPosition = Builders<PlayerModel>.IndexKeys.Text(player => player.Position);
        var playerIndexDef = Builders<PlayerModel>.IndexKeys.Combine(playerName, playerNationality, playerPosition);
        var playerIndexModel = new CreateIndexModel<PlayerModel>(playerIndexDef);
        players.Indexes.CreateOne(playerIndexModel);

        var teamName = Builders<TeamModel>.IndexKeys.Text(team => team.TeamName);
        var teamCountry = Builders<TeamModel>.IndexKeys.Text(team=> team.Country);
        var teamIndexDef = Builders<TeamModel>.IndexKeys.Combine(teamName, teamCountry);
        var teamIndexModel = new CreateIndexModel<TeamModel>(teamIndexDef);
        teams.Indexes.CreateOne(teamIndexModel);

        var matchDateIndex = Builders<MatchModel>.IndexKeys.Descending(match => match.MatchDate); // Index for sorting by match date
        var teamAIndex = Builders<MatchModel>.IndexKeys.Ascending(match => match.TeamA); // Index for searching matches by TeamA
        var teamBIndex = Builders<MatchModel>.IndexKeys.Ascending(match => match.TeamB); // Index for searching matches by TeamB
        var winnerIndex = Builders<MatchModel>.IndexKeys.Ascending(match => match.Winner); // Index for searching matches by Winner
        var matchIndexDef = Builders<MatchModel>.IndexKeys.Combine(matchDateIndex, teamAIndex, teamBIndex, winnerIndex);
        var matchIndexModel = new CreateIndexModel<MatchModel>(matchIndexDef);
        matches.Indexes.CreateOne(matchIndexModel);



        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new AddPlayerPage());
        //Application.Run(new AddTeamPage());
        //Application.Run(new ShowPlayer("6627c76f8a2e481468fcf5e6"));

        AdminDataAccess adminDataAccess = new AdminDataAccess();

        MatchDataAccess matchDataAccess = new MatchDataAccess();

        //Application.Run(new AddMatchPage());
        Application.Run(new MainForm());

        //Application.Run(new PlayerComparison(new List<string> { "662fb2b58b52cf1a95d76489", "662e27013216bb3fac1e8804" }));
    }
}
