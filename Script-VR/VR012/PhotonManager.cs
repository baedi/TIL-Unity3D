using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class PhotonManager : MonoBehaviourPunCallbacks {
    
    // Var              


    // Initialize       
    private void Awake() {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1.0";
        PhotonNetwork.NickName = "Default";
        PhotonNetwork.ConnectUsingSettings();
    }

    // Connected Master. (+Refresh) 
    public override void OnConnectedToMaster() {
        base.OnConnectedToMaster();

        // Alerady in Lobby?        
        if (PhotonNetwork.InLobby) PhotonNetwork.LeaveLobby();

        // Join Lobby.              
        PhotonNetwork.JoinLobby();
    }


    // (Callback) Join Lobby        
    public override void OnJoinedLobby() {
        base.OnJoinedLobby();
        Debug.Log("Join Lobby");

        //PhotonNetwork.CreateRoom("helloworld", new RoomOptions() { MaxPlayers = 4, IsVisible = true });
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList) {
        base.OnRoomListUpdate(roomList);

        Debug.Log(roomList.Count);

        foreach(var roomItem in roomList) {
            Debug.Log("Room name : " + roomItem.Name);
            Debug.Log("Player : " + roomItem.PlayerCount);
            Debug.Log("Max Player : " + roomItem.MaxPlayers);
        }
    }

}
