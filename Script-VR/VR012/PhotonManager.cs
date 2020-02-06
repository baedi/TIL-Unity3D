using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;


public class PhotonManager : MonoBehaviourPunCallbacks {

    // Var              
    public GameObject[] roomGameObject = new GameObject[4];

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

        Debug.Log("Room Count : " + roomList.Count);

        for(int count = 0; count < roomGameObject.Length; count++) {

            // Room Avaliable.      
            if(count < roomList.Count) {
                var roomItem = roomList[count];
                PhotonRoomInfo roominfo = roomGameObject[count].GetComponent<PhotonRoomInfo>();
                roominfo.RoomName = roomItem.Name;
                roominfo.RoomPlayer = roomItem.PlayerCount;
                roominfo.RoomMaxPlayer = roomItem.MaxPlayers;

                if (roominfo.RoomPlayer != 0)
                    roomGameObject[count].GetComponent<Button>().interactable = true;

                else 
                    roomGameObject[count].GetComponent<Button>().interactable = false;

                roominfo.RoomInfoTextChange();
            }

            else {
                roomGameObject[count].GetComponent<Button>().interactable = false;
                roomGameObject[count].GetComponentInChildren<Text>().text = "Empty";
            }

        }


    }

}
