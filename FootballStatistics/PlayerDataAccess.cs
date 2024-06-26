﻿using MongoDB.Driver;
using MongoDB.Driver.Core.Connections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballStatistics
{
    internal class PlayerDataAccess
    {
        string ConnectionString = "mongodb://user:pass@localhost:27017/";
        //private string ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        private const string DatabaseName = "fooballstats";
        private const string PlayerCollection = "players";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task AddPlayerAsync(PlayerModel newPlayer)
        {
            try
            {
                var players = ConnectToMongo<PlayerModel>(PlayerCollection);
                await players.InsertOneAsync(newPlayer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding player: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public async Task<ReplaceOneResult> UpdatePlayerById(PlayerModel updatedPlayer)
        {
            try
            {
                var players = ConnectToMongo<PlayerModel>(PlayerCollection);
                var resutls = await players.ReplaceOneAsync(p => p.PlayerID == updatedPlayer.PlayerID, updatedPlayer, new ReplaceOptions { IsUpsert = false });
                return resutls;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating player: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private async Task<List<PlayerModel>> GetAllPlayersAsync()
        {
            try
            {
                var players = ConnectToMongo<PlayerModel>(PlayerCollection);
                var results = await players.FindAsync(_ => true);
                return results.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving all players: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<PlayerModel>();
            }
        }

        public async Task<PlayerModel> GetPlayerByIDAsync(string playerID)
        {
            try
            {
                var players = ConnectToMongo<PlayerModel>(PlayerCollection);
                var result = await players.FindAsync<PlayerModel>(p => p.PlayerID == playerID);
                var list = result.ToList<PlayerModel>();
                if (list.Count > 0)
                    return list.FirstOrDefault();
                else
                    return null;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while retrieving player by ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
        }

        public async Task<List<PlayerModel>> SearchPlayersAsync(string searchString)
        {
            try
            {
                var players = ConnectToMongo<PlayerModel>(PlayerCollection);
                var playerFilter = Builders<PlayerModel>.Filter.Text(searchString);
                var playerQuery = await players.Aggregate().Match(playerFilter).ToListAsync();

                return playerQuery;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while searching for players: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public async Task<bool> RemovePlayerByIdAsync(string playerID)
        {
            try
            {
                var players = ConnectToMongo<PlayerModel>(PlayerCollection);
                var result = await players.DeleteOneAsync(p => p.PlayerID == playerID);
                if (result.DeletedCount >= 1)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching for players: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<List<PlayerModel>> GetPlayersByTeamId(string teamID)
        {
            try
            {
                var players = ConnectToMongo<PlayerModel>(PlayerCollection);
                var result = await players.FindAsync(p => p.TeamID == teamID);
                var list = result.ToList();
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving players by team ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; 
            }
        }
    }
}
