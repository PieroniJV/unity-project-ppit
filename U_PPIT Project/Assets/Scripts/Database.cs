using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using TMPro;

// This Database script is used to display data from the database and add values to the database
// When the Leaderboard scene is opened, this script accesses the database and display the values contained in the database to the leaderboard
// When the user finishes the gameplay, their name entered, the number of enemies killed and the time are stored and sent to the database
// The InsertData function is called in the DisplayScoreScript.cs that displays the values to the screen and sends them to the insert data function

public class Database : MonoBehaviour
{
    private static IDbConnection connection;
    private static IDbCommand command;
    private static IDataReader reader;
    private static string dbName = "myDatabase.db";
    private static string tableName = "game_stats";
    private TMP_Text textMeshPro;

    private void Awake()
    {
        textMeshPro = GameObject.Find("Scores").GetComponent<TMP_Text>();
        // Connection string for SQLite database
        StartConnection();
        // Function to read data from database
        DisplayData();
        // Close connection
        connection.Close();
    }

    private static void StartConnection()
    {
        string connectionString = "URI=file:" + Application.dataPath + dbName;
        // Create a database connection
        connection = new SqliteConnection(connectionString);
        // Open connection
        connection.Open();
        // Create a new database command
        command = connection.CreateCommand();
        reader = null;
    }

    private void DisplayData()
    {
        // SQL query to display db values
        command.CommandText = "SELECT * FROM " + tableName + ";";
        // Execute the query
        reader = command.ExecuteReader();
        // Initialize a variable to hold the results
        string results = "";
        // Loop through results
        while (reader.Read())
        {
            Debug.Log(
                reader.GetInt32(0)
                    + ", "
                    + reader.GetString(1)
                    + ", "
                    + reader.GetString(2)
                    + ", "
                    + reader.GetInt32(3)
            );

            string result =
                reader.GetInt32(0)
                + "\t "
                + reader.GetString(1)
                + "\t\t"
                + reader.GetString(2)
                + "\t\t\t"
                + reader.GetInt32(3);
            results += result + "\n";
        }
        // Set the text of the textMeshPro component to the results
        textMeshPro.text = results;

        // Clearing fields after use
        reader.Close();
        reader = null;
    }

    public static void InsertData(string playerName, string playerTime, int playerKillCount)
    {
        StartConnection();
        // SQL query to insert data into db
        command.CommandText =
            "INSERT INTO "
            + tableName
            + " (name, time, killCount) VALUES ('"
            + playerName
            + "', '"
            + playerTime
            + "', "
            + playerKillCount
            + ");";
        // Execute the query
        command.ExecuteNonQuery();
        // Close connection
        connection.Close();
        command.Dispose();
        command = null;
    }
}
