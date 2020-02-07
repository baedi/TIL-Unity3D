using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;


public class PhotonManager : MonoBehaviourPunCallbacks {

    // Var              
    public GameObject[] roomGameObject = new GameObject[4];

    private GameObject createRoomUI;
    private GameObject keyboardUI;


    // Initialize       
    private void Awake() {

        // Object Enable Settings.  
        createRoomUI = GameObject.Find("CreateRoomUI");
        createRoomUI.SetActive(false);

        keyboardUI = GameObject.Find("KeyboardCanvas");
        keyboardUI.SetActive(false);


        // Photon Network Settings. 
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


    // (Callback) Room Update       
    public override void OnRoomListUpdate(List<RoomInfo> roomList) {
        base.OnRoomListUpdate(roomList);

        Debug.Log("Room Count : " + roomList.Count);

        for (int count = 0; count < roomGameObject.Length; count++) {

            // Room Avaliable.      
            if (count < roomList.Count) {
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



    /*******************************/
    /*** Button Click Event List ***/
    /*******************************/

    // Room Button Click Event          
    public void OnRoomButtonClick() {

        string roomname = GameObject.Find("CreateRoomInputButton").GetComponentInChildren<Text>().text;
        if (roomname.Length <= 0) return;

        // Get Room Info (Name)     
        GameObject temp = new GameObject();
        GameObject temp2 = new GameObject();
        temp.name = roomname;
        temp2.name = "CreateRoom_";
        temp.transform.parent = temp2.transform;

        DontDestroyOnLoad(temp);
        DontDestroyOnLoad(temp2);

        PhotonNetwork.LeaveLobby();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("GameScene2");
    }


    // Join Room Button Click Event         
    public void OnJoinRoomButtonClick(GameObject clickObject) {

        GameObject temp = new GameObject();
        GameObject temp2 = new GameObject();
        temp.name = clickObject.GetComponent<PhotonRoomInfo>().RoomName;
        temp2.name = "JoinRoom_";
        temp.transform.parent = temp2.transform;

        DontDestroyOnLoad(temp);
        DontDestroyOnLoad(temp2);

        PhotonNetwork.LeaveLobby();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("GameScene2");
    }


    // Room Create Button Click Event   
    public void OnCreateRoomButtonClick() {

        // Visible CreateRoom UI Interface  
        if (createRoomUI.activeInHierarchy) {
            createRoomUI.SetActive(false);

            if (keyboardUI.activeInHierarchy)
                keyboardUI.SetActive(false);
        }
        else createRoomUI.SetActive(true);
    }


    // Keyboard Active Event.           
    public void OnKeyboardActiveEvent(GameObject target) {

        // IF Keyboard state is already active  
        if (keyboardUI.activeInHierarchy) {
            keyboardUI.SetActive(false);
            return;
        }

        // Keyboard state is not active.        
        keyboardUI.SetActive(true);

        for (int count = 0; count < keyboardUI.GetComponentsInChildren<ButtonKey>().Length; count++)
            keyboardUI.GetComponentsInChildren<ButtonKey>()[count].setTargetTextObject(target.GetComponentInChildren<Text>().gameObject);
    }
}
