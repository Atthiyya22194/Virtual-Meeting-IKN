using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class CreateJoinRoom : MonoBehaviourPunCallbacks {

    private static CreateJoinRoom _instance;
    public static CreateJoinRoom Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<CreateJoinRoom>();
            }
            return _instance;
        }
    }    

    public TMP_InputField roomNameInputField;
    public GameEvent CharacterSelect;

    public LobbyState lobbyState;

    private string tempName;

    public void CreateRoom() {
        string roomName = Random.Range(1000, 9999).ToString();
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 0,
            BroadcastPropsChangeToAll = true,
        };
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }
    
    public void OnCreateRoomButton_Clicked() {
        UserManager.Instance.SetName(tempName);
        PhotonNetwork.NickName = tempName;

        lobbyState = LobbyState.Create;

        CharacterSelect.Raise();        
    }

    public void OnJoinRoomButton_Clicked() {
        UserManager.Instance.SetName(tempName);
        PhotonNetwork.NickName = tempName;

        lobbyState = LobbyState.Join;

        RoomInfo room = MasterNetworkManager.Instance.roomInfos.FirstOrDefault(r => r.Name == roomNameInputField.text);

        if (room != null) {
            CharacterSelect.Raise();
        } else {
            Debug.Log("Room Doesnt exist");
        }
    }

    public void SetTempName(TMP_InputField inputField) {
        tempName = inputField.text;        
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList) {
        base.OnRoomListUpdate(roomList);
    }
}

public enum LobbyState {
    Create,
    Join,
}
