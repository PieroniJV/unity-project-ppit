using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using TMPro;

public class Database : MonoBehaviour
{
    private IDbConnection connection;
    private IDbCommand command;
    private IDataReader reader;
    private string dbName = "myDatabase.db";
    private string tableName = "game_stats";

    private TMP_Text textMeshPro;

    private void Start()
    {
        textMeshPro = GameObject.Find("Scores").GetComponent<TMP_Text>();
        // Connection string for SQLite database
        string connectionString = "URI=file:" + Application.dataPath + dbName;
        // Create a database connection
        connection = new SqliteConnection(connectionString);
        // Open connection
        connection.Open();
        // Function to read data from database
        DisplayData();
        // Close connection
        connection.Close();
    }

    private void DisplayData()
    {
        // Create a new database command
        command = connection.CreateCommand();
        // SQL query to display db values
        command.CommandText = "SELECT * FROM " + tableName + ";";
        // Execute the query
        reader = command.ExecuteReader();
        // Loop through results
        while (reader.Read())
        {
            Debug.Log(
                reader.GetInt32(0)
                    + ", "
                    + reader.GetString(1)
                    + ", "
                    + reader.GetInt32(2)
                    + ", "
                    + reader.GetInt32(3)
            );

            string result =
                reader.GetInt32(0)
                + "\t "
                + reader.GetString(1)
                + "\t\t"
                + reader.GetInt32(2)
                + "\t\t\t"
                + reader.GetInt32(3);
            textMeshPro.text = result;

        }

        // Clearing fields after use
        reader.Close();
        reader = null;
        command.Dispose();
        command = null;
    }

    private void InsertData()
    {
        // To do
        // implement method to insert into db
        // take values from parameters and pass it to the query to insert into table
    }
}
