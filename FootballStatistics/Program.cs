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
        //string connectionString = "mongodb://127.0.0.1:28017";
        //string databaseName = "fooballstats";
        //string collectionName = "players";

        //var client = new MongoClient(connectionString);
        //var db = client.GetDatabase(databaseName);
        //var collection = db.GetCollection<Player>(collectionName);
        
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new AddPlayerPage());
        Application.Run(new ShowPlayer("6627c76f8a2e481468fcf5e6"));
    }
}
