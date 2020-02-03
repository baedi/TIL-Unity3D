using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;



public class CreateDB : MonoBehaviour {

    private string dbPath;
    private string databaseName = @"\user.db";
    private SqliteConnection connection;
    private SqliteCommand command;
    private Text connectCheckText;
    private Text nicknameText;


    // Initialize       
    private void Start() {

        // Get Text Component.      
        connectCheckText = GameObject.Find("ConnectText").GetComponent<Text>();
        nicknameText = GameObject.Find("NicknameText").GetComponent<Text>();

        // Android Platform.        
        if(Application.platform == RuntimePlatform.Android) {
            Debug.Log("Android");
            dbPath = Application.persistentDataPath + databaseName;
        }

        // PC or Other Platform.    
        else {
            Debug.Log("No Android");
            dbPath = Application.dataPath + databaseName;
        }


        // Create Database if not exist DB. 
        if (!File.Exists(dbPath)) {
            Debug.Log(dbPath);
            SqliteConnection.CreateFile(dbPath);
            connection = new SqliteConnection("Data Source=" + dbPath + ";Version=3;");
            connection.Open();

            command = new SqliteCommand("CREATE TABLE userdata (nickname VARCHAR(16));", connection);
            command.ExecuteNonQuery();
            connection.Close();
            Debug.Log("Create Database");

            connectCheckText.text = "[Create Database Path] \n" + dbPath;

            CreateDefaultNickname();
        }


        // Connect Database                 
        connection = new SqliteConnection("Data Source=" + dbPath + ";Version=3;");

        try {
            connection.Open();
            connection.Close();
            connectCheckText.text = "Connect OK";

        } catch (SqliteException) { connectCheckText.text = "Connect fail..."; };

    }


    // Create Default nickname (DB Create only) 
    private void CreateDefaultNickname() {
        Debug.Log("Path : " + dbPath);

        connection.Open();
        command = new SqliteCommand("INSERT INTO userdata (nickname) VALUES ('Default');", connection);
        command.ExecuteNonQuery();
        connection.Close();
    }


    // Update nickname info,                    
    public void UpdateNickname() {
        Debug.Log("Path : " + dbPath);

        if (!(nicknameText.text.Length > 0)) {
            connectCheckText.text = "Input nickname!!!";
            return;
        }

        connection.Open();
        command = new SqliteCommand($"UPDATE userdata SET nickname = '{nicknameText.text}';", connection);
        command.ExecuteNonQuery();
        connection.Close();

        connectCheckText.text = "Updated nickname";
    }


    // Check nickname info,                     
    public void CheckNickname() {
        Debug.Log("Path : " + dbPath);

        connection.Open();
        command = new SqliteCommand("SELECT * FROM userdata;", connection);
        SqliteDataReader reader = command.ExecuteReader();

        if (reader.Read()) {
            connectCheckText.text = reader["nickname"].ToString();
        }

        reader.Close();
        connection.Close();
    }
}
