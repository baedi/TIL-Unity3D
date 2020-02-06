using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonRoomInfo : MonoBehaviour {

    // Property.        
    public string RoomName { get; set; }
    public string RoomPass { get; set; }
    public int RoomPlayer { get; set; }
    public int RoomMaxPlayer { get; set; }
    public bool IsPrivateRoom { get; set; }

    public void RoomInfoTextChange() {
        GetComponentInChildren<Text>().text =
            "[" + RoomName + "]" + "\n\n" +
            "Player : " + RoomPlayer + " / " + RoomMaxPlayer + "\n\n" +
            "Permission : " + "Public Room" + "\n\n";
    }
}
