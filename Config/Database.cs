using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Space_Shooter_game.Config
{
    public static class Database
    {
        private const string file = "SpaceShooter.db";
        private static readonly string Connection = $"Data Source={file};Version=3;";

        #region Initialize
         
        public static void Initialize()
        {
            if (!File.Exists(file))
            {
                SQLiteConnection.CreateFile(file);
            }

            using (SQLiteConnection connection = new SQLiteConnection(Connection))
            {
                connection.Open();
                string playerTable =
                @"CREATE TABLE IF NOT EXISTS PlayerData
                (
                    Id INTEGER PRIMARY KEY,
                    Coins INTEGER NOT NULL,
                    HighScore INTEGER NOT NULL,
                    MusicEnabled INTEGER NOT NULL,
                    SfxEnabled INTEGER NOT NULL
                );";

                string shopTable =
                @"CREATE TABLE IF NOT EXISTS ShopItems
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Category TEXT NOT NULL,
                    Name TEXT NOT NULL,
                    Price INTEGER NOT NULL,
                    Owned INTEGER NOT NULL,
                    Selected INTEGER NOT NULL
                );";

                ExecuteNonQuery(playerTable);
                ExecuteNonQuery(shopTable);

                int count = ExecuteScalar<int>("SELECT COUNT(*) FROM PlayerData");

                if (count == 0)
                {
                    ExecuteNonQuery(@"INSERT INTO PlayerData VALUES(1, 0, 0, 1, 1)");
                }
            }
        }

        #endregion

        #region Base Methods

        public static void ExecuteNonQuery(string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Connection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static T ExecuteScalar<T>(string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Connection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameters);
                    object result = command.ExecuteScalar();
                    return (T)Convert.ChangeType(result, typeof(T));
                }
            }
        }

        public static List<Dictionary<string, object>> ExecuteReader(string sql, params SQLiteParameter[] parameters)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

            using (SQLiteConnection connection = new SQLiteConnection(Connection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameters);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, object> row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row.Add(reader.GetName(i), reader[i]);
                            }
                            rows.Add(row);
                        }
                    }
                }
            }
            return rows;
        }

        #endregion

        #region Coins

        public static int GetCoins()
        {
            return ExecuteScalar<int>("SELECT Coins FROM PlayerData WHERE Id = 1");
        }

        public static void SetCoins(int coins)
        {
            ExecuteNonQuery("UPDATE PlayerData SET Coins=@coins WHERE Id=1", new SQLiteParameter("@coins", coins));
        }

        public static void AddCoins(int amount)
        {
            SetCoins(GetCoins() + amount);
        }

        public static bool SpendCoins(int amount)
        {
            int coins = GetCoins();
            if (coins < amount)
                return false;
            SetCoins(coins - amount);
            return true;
        }

        #endregion

        #region High Score

        public static int GetHighScore()
        {
            return ExecuteScalar<int>("SELECT HighScore FROM PlayerData WHERE Id=1");
        }

        public static void SetHighScore(int score)
        {
            ExecuteNonQuery("UPDATE PlayerData SET HighScore=@score WHERE Id=1", new SQLiteParameter("@score", score));
        }

        #endregion

        #region Audio

        public static bool IsMusicEnabled()
        {
            return ExecuteScalar<int>("SELECT MusicEnabled FROM PlayerData WHERE Id=1") == 1;
        }

        public static void SetMusicEnabled(bool enabled)
        {
            ExecuteNonQuery("UPDATE PlayerData SET MusicEnabled=@v WHERE Id=1", new SQLiteParameter("@v", enabled ? 1 : 0));
        }

        public static bool IsSfxEnabled()
        {
            return ExecuteScalar<int>("SELECT SfxEnabled FROM PlayerData WHERE Id=1") == 1;
        }

        public static void SetSfxEnabled(bool enabled)
        {
            ExecuteNonQuery("UPDATE PlayerData SET SfxEnabled=@v WHERE Id=1", new SQLiteParameter("@v", enabled ? 1 : 0));
        }

        #endregion

        #region Shop

        public static void BuyItem(int id)
        {
            ExecuteNonQuery("UPDATE ShopItems SET Owned=1 WHERE Id=@id", new SQLiteParameter("@id", id));
        }

        public static bool IsOwned(int id)
        {
            return ExecuteScalar<int>("SELECT Owned FROM ShopItems WHERE Id=@id", new SQLiteParameter("@id", id)) == 1;
        }

        public static void SelectItem(int id)
        {
            string category = ExecuteScalar<string>("SELECT Category FROM ShopItems WHERE Id=@id", new SQLiteParameter("@id", id));
            ExecuteNonQuery("UPDATE ShopItems SET Selected=0 WHERE Category=@cat", new SQLiteParameter("@cat", category));
            ExecuteNonQuery("UPDATE ShopItems SET Selected=1 WHERE Id=@id", new SQLiteParameter("@id", id));
        }

        public static int GetSelectedItemId(string category)
        {
            return ExecuteScalar<int>("SELECT Id FROM ShopItems WHERE Category=@cat AND Selected=1", new SQLiteParameter("@cat", category));
        }

        public static List<Dictionary<string, object>> GetItems(string category)
        {
            return ExecuteReader("SELECT * FROM ShopItems WHERE Category=@cat", new SQLiteParameter("@cat", category));
        }

        #endregion
    }
}