// Ignore Spelling: Admin

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballStatistics
{
    public class AdminDataAccess
    {
        private const string ConnectionString = "mongodb://user:pass@localhost:27017/";
        private const string DatabaseName = "fooballstats";
        private const string AdminCollection = "admins";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task<bool> AddAdminAsync(AdminModel newAdmin)
        {
            try
            {
                var admins = ConnectToMongo<AdminModel>(AdminCollection);
                if (await UsernameExistsAsync(newAdmin.Username))
                    return false;
                await admins.InsertOneAsync(newAdmin);
                return true;
            }
            catch (Exception ex)
            {


                MessageBox.Show($"An error occurred while adding an admin: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        private async Task<bool> UsernameExistsAsync(string username)
        {
            var admins = ConnectToMongo<AdminModel>(AdminCollection);
            var existingAdmin = await admins.Find(a => a.Username == username).ToListAsync();
            if (existingAdmin.Count > 0)
                return true;
            return false;
        }

        //bad authentication but thats not the main purpose of this project
        public async Task<string> AuthenticateAdminAsync(string user, string pass)
        {
            try
            {
                var admins = ConnectToMongo<AdminModel>(AdminCollection);
                var results = await admins.Find(a => a.Username == user && a.Password == pass).FirstOrDefaultAsync();
                if (results != null)
                {
                    return results.AdminID;
                }

                // If no Admin found, return an empty string
                return "";
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while authenticating Admin: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return "";
            }
        }
    }
}
