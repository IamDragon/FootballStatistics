using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballStatistics
{
    public class UserDataAccess
    {
        string ConnectionString = "mongodb://user:pass@localhost:27017/";
        //private string ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        private const string DatabaseName = "fooballstats";
        private const string UserCollection = "users";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task<bool> AddUserAsync(UserModel newUser)
        {
            try
            {
                var users = ConnectToMongo<UserModel>(UserCollection);
                if (await UsernameExistsAsync(newUser.Username))
                    return false;
                await users.InsertOneAsync(newUser);
                return true;
            }
            catch (Exception ex)
            {

           
                MessageBox.Show($"An error occurred while adding a user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        public async Task<ReplaceOneResult> UpdateUserById(UserModel existingUser)
        {
            try
            {
                var players = ConnectToMongo<UserModel>(UserCollection);
                var resutls = await players.ReplaceOneAsync(u => u.UserID == existingUser.UserID, existingUser, new ReplaceOptions { IsUpsert = false });
                return resutls;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<UserModel> GetUserByIDAsync(string userID)
        {
            try
            {
                var players = ConnectToMongo<UserModel>(UserCollection);
                var result = await players.FindAsync<UserModel>(u => u.UserID == userID);
                var list = result.ToList<UserModel>();
                if (list.Count > 0)
                    return list.FirstOrDefault();
                else
                    return null;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while retrieving user by ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
        }

        private async Task<List<UserModel>> GetAllUsersAsync()
        {
            try
            {
                var users = ConnectToMongo<UserModel>(UserCollection);
                var results = await users.FindAsync(_ => true);
                return results.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving all users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<UserModel>();
            }
          
        }

        private async Task<bool> UsernameExistsAsync(string username)
        {
            var users = ConnectToMongo<UserModel>(UserCollection);
            var existingUser = await users.Find(u => u.Username == username).ToListAsync();
            if (existingUser.Count > 0)
                return true;
            return false;
        }

        //bad user authentication but thats not the main purpose of this project
        public async Task<string> AuthenticateUserAsync(string user, string pass)
        {
            try
            {
                var users = ConnectToMongo<UserModel>(UserCollection);
                var results = await users.Find(u => u.Username == user && u.Password == pass).FirstOrDefaultAsync();
                if (results != null)
                {
                    return results.UserID;
                }

                // If no user found, return an empty string
                return "";
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while authenticating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return "";
            }
        }

    }
    
}

