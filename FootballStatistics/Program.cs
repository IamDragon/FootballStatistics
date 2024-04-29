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
        string connectionString = "mongodb://user:pass@localhost:27017/";
        string databaseName = "fooballstats";
        string PlayersCollection = "players";
        string TeamsCollection = "teams";
        //string matches = "matches";

        var client = new MongoClient(connectionString);
        var db = client.GetDatabase(databaseName);
        var players = db.GetCollection<PlayerModel>(PlayersCollection);
        var teams = db.GetCollection<TeamModel>(TeamsCollection);

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

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new AddPlayerPage());
        //Application.Run(new ShowPlayer("6627c76f8a2e481468fcf5e6"));
        Application.Run(new MainForm());
        //Application.Run(new PlayerComparison(new List<string> { "662fb2b58b52cf1a95d76489", "662e27013216bb3fac1e8804" }));
    }
}
