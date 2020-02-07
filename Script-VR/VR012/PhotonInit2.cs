using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

using Mono.Data.Sqlite;


public class PhotonInit2 : MonoBehaviourPunCallbacks
{

    // Var              
    public string gameVer = "1.0";
    public string nickName = "default";

    private SqliteConnection connect;
    private SqliteCommand command;
    private string dbName = @"\user.db";
    private string dbPath;


    // Initialize       
    private void Awake() {

        // DB Setting.      
        if (Application.platform == RuntimePlatform.Android)
            dbPath = Application.persistentDataPath + dbName;

        else
            dbPath = Application.dataPath + dbName;

        connect = new SqliteConnection("Data Source=" + dbPath + ";Version=3;");
        connect.Open();

        command = new SqliteCommand("SELECT * FROM userdata;", connect);
        SqliteDataReader reader = command.ExecuteReader();
        if (reader.Read()) nickName = reader["nickname"].ToString();
        reader.Close();
        connect.Close();

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start() {
        OnLogin();
    }


    // Login Network        
    private void OnLogin() {
        PhotonNetwork.GameVersion = gameVer;
        PhotonNetwork.NickName = nickName;
        PhotonNetwork.ConnectUsingSettings();
    }


    // Override Method.     
    public override void OnConnectedToMaster() {
        base.OnConnectedToMaster();

        Debug.Log("Connect player : " + nickName);

        // Join Room        

        GameObject hostUserCheck = GameObject.Find("CreateRoom_");

        // Host User.       
        if(hostUserCheck != null) {
            Debug.Log(hostUserCheck.name);
            string hostname = hostUserCheck.transform.GetChild(0).name;
            Debug.Log(hostname);
            PhotonNetwork.CreateRoom(hostname, new RoomOptions { MaxPlayers = 4, IsVisible = true });
            Destroy(hostUserCheck);
            Debug.Log("Create Success!!!");
        }

        // Other User.      
        else {
            hostUserCheck = GameObject.Find("JoinRoom_");
            string roomname = hostUserCheck.transform.GetChild(0).name;
            PhotonNetwork.JoinRoom(roomname);
            Destroy(hostUserCheck);
        }
    }


    // Failed Join Room (Create Room)   
    public override void OnJoinRandomFailed(short returnCode, string message) {
        SceneManager.LoadScene("LobbyScene");
    }

    // Join Room (My or Other Player's Room)  
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("Join Room");
        GameObject tempObj = PhotonNetwork.Instantiate("Player", GameObject.Find("SpawnPoint").transform.position, Quaternion.identity);
        tempObj.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        GameObject.Find("OVRCameraRig").transform.parent = tempObj.transform;
        GameObject.Find("OVRCameraRig").transform.localPosition = new Vector3(0, 0.8f, 0);
    }


    // Another player entered room function.    
    public override void OnPlayerEnteredRoom(Player newPlayer) {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("!");
    }

    // Another player leave room function.      
    public override void OnPlayerLeftRoom(Player otherPlayer) {
        base.OnPlayerLeftRoom(otherPlayer);
    }

}
