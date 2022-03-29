using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateJoinRoom : MonoBehaviourPunCallbacks {
    
    public TMP_InputField roomNameInputField;    

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
        CreateRoom();
    }

    public void OnJoinRoomButton_Clicked() {
        UserManager.Instance.SetName(tempName);
        PhotonNetwork.NickName = tempName;

        string roomName = roomNameInputField.text;
        PhotonNetwork.JoinRoom(roomName);
    }

    public void SetTempName(TMP_InputField inputField) {
        tempName = inputField.text;        
    }
    
}
