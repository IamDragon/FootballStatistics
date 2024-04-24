using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatistics
{
    public class UserDataAccess
    {
        private const string ConnectionString = "mongodb://user:pass@localhost:27017/";
        private const string DatabaseName = "fooballstats";
        private const string UserCollection = "users";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public bool AddUser(UserModel newUser)
        {
            var users = ConnectToMongo<UserModel>(UserCollection);
            if (UsernameExists(newUser.Username))
                return false;
            users.InsertOne(newUser);
            return UsernameExists(newUser.Username);
        }

        private List<UserModel> GettAllUsers()
        {
            var users = ConnectToMongo<UserModel>(UserCollection);
            var results = users.Find(_ => true);
            return results.ToList();
        }

        private bool UsernameExists(string username)
        {
            var users = ConnectToMongo<UserModel>(UserCollection);
            var resuluts = users.Find(u => u.Username == username);
            if (resuluts.ToList().Count > 0)
                return true;
            return false;
        }

        //bad user authentication but thats not the main purpose of this project
        public string AuthenticateUser(string user, string pass)
        {
            var users = ConnectToMongo<UserModel>(UserCollection);
            var resuluts = users.Find(u => u.Username == user && u.Password == pass);
            if (resuluts.ToList().Count < 0)
                return "";
            return resuluts.ToList()[0].UserID;
        }
    }
}
