using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonCustomRoom : MonoBehaviourPunCallbacks {

    // 변수           
    public string roomname = "testroom";
    public string password = "12345";
    public string hostuser = "default";


    public override void OnConnectedToMaster() {
        base.OnConnectedToMaster();

        /** 커스텀 방 생성하기 **/

        // 방 옵션 설정      
        RoomOptions roomOpt = new RoomOptions()
        {
            MaxPlayers = 20,                // 최대 수용 인원               
            IsVisible = true,               // 방 보이기 여부               
            CleanupCacheOnLeave = false,    // 생성된 아이템 자동 제거 여부 (방 떠날 시)

            // 커스텀 설정       
            CustomRoomProperties =
                new ExitGames.Client.Photon.Hashtable() {
                    { "Password", password },
                    { "Hostuser", hostuser }
                },

            CustomRoomPropertiesForLobby =
                new string[] { "Password", "Hostuser" }
        };

        PhotonNetwork.CreateRoom(roomname, roomOpt);
    }
}
