using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Dj_application.Controller
{

    public class MusicBpmDatabase
    {
        private const string DatabaseFileName = "bdd.db";
        private const string TableName = "music_bpm";
        private const string FilePathColumnName = "file_path";
        private const string BpmColumnName = "bpm";

        private static SQLiteConnection connection;
        private static readonly object lockObject = new object();

        private static MusicBpmDatabase instance;

        public static MusicBpmDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new MusicBpmDatabase();
                        }
                    }
                }
                return instance;
            }
        }

        private MusicBpmDatabase()
        {
            // Vérifier si la base de données existe déjà
            bool databaseExists = System.IO.File.Exists(DatabaseFileName);

            // Créer la connexion à la base de données
            connection = new SQLiteConnection($"Data Source={DatabaseFileName};Version=3;");

            // Si la base de données n'existe pas encore, la créer et initialiser la table
            if (!databaseExists)
            {
                connection.Open();
                CreateMusicBpmTable();
                connection.Close();
            }
        }

        public void InsertBpm(string filePath, int bpm)
        {
            try
            {
                lock (lockObject)
                {
                    connection.Open();

                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO {TableName} ({FilePathColumnName}, {BpmColumnName}) VALUES (@filePath, @bpm)";
                        command.Parameters.AddWithValue("@filePath", filePath);
                        command.Parameters.AddWithValue("@bpm", bpm);
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        public int GetBpm(string filePath)
        {
            lock (lockObject)
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT {BpmColumnName} FROM {TableName} WHERE {FilePathColumnName} = @filePath";
                    command.Parameters.AddWithValue("@filePath", filePath);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        connection.Close();
                        return Convert.ToInt32(result);
                    }
                }

                connection.Close();
                return -1; // Retourne -1 si le chemin de fichier n'existe pas dans la base de données
            }
        }

        private void CreateMusicBpmTable()
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = $"CREATE TABLE {TableName} ({FilePathColumnName} TEXT PRIMARY KEY, {BpmColumnName} INTEGER)";
                command.ExecuteNonQuery();
            }
        }
    }

}
