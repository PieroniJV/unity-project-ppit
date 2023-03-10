using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class Database : MonoBehaviour
{
    private string dbName;

    private void Start()
    {
        dbName = "URI=file:" + Application.dataPath + "/Database/ppitDB.db";
        DisplayData();
    }

    private void DisplayData()
    {
        using var connection = new SqliteConnection(dbName);
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "Select name from game_stats;";

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Debug.Log(reader["name"]);
                }
            }
        }
        connection.Close();
    }
}
