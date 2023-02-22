 using UnityEngine;
 using System;
 using System.Data;
 using System.Text;
 
 using System.Collections;
 using System.Collections.Generic;
 using MySql.Data;
 using MySql.Data.MySqlClient;

public class DatabaseManager : MonoBehaviour
{
    private MySqlConnection connection;
    // Server ip
    private string server;
    // Database name
    private string database;
    // Sql id
    private string uid;
    // Sql password
    private string password;

    // Start is called before the first frame update
    void Start()
    {
        server = "localhost";
        database = "unitygame";
        uid = "root";
        password = "";

        string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
        OpenConnection();

        //Executing the MySql queries
        MySqlCommand command = new MySqlCommand("SELECT * FROM game_stats;", connection);
        MySqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            Debug.Log("Player Name: " + dataReader["name"] + ", Time spent: " + dataReader["time_spent"] + ", Number of Attempts: " + dataReader["num_of_attempts"]);
        }

        CloseConnection();

    }

    private void OpenConnection()
    {
        if (connection.State == System.Data.ConnectionState.Closed)
        {
            connection.Open();
        }
    }

    private void CloseConnection()
    {
        if (connection.State == System.Data.ConnectionState.Open)
        {
            connection.Close();
        }
    }

    void OnApplicationQuit() 
    {
        CloseConnection();
    }

}
