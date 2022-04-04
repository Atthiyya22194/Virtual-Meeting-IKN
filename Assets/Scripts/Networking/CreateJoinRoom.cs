using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Sprite[] rumahAdatPreviewImages;
    public Image previewImage;

    public TMP_InputField roomNameInputField;
    public GameEvent CharacterSelect;

    public LobbyState lobbyState;

    private string tempName;
    private int selectedRumahIndex = 0;

    ExitGames.Client.Photon.Hashtable roomProperties = new ExitGames.Client.Photon.Hashtable();

    public void CreateRoom() {
        string roomName = Random.Range(1000, 9999).ToString();

        roomProperties["roomPlace"] = selectedRumahIndex;

        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 0,
            BroadcastPropsChangeToAll = true,
            CustomRoomProperties = roomProperties
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

    public void OnNextPreviewRoomButton_Clicked() {
        if (selectedRumahIndex == rumahAdatPreviewImages.Length - 1) {
            selectedRumahIndex = 0;
        } else {
            selectedRumahIndex = selectedRumahIndex + 1;
        }

        UpdatePreview();
    }

    public void OnPreviousPreviewButton_Clicked() {
        if (selectedRumahIndex == 0) {
            selectedRumahIndex = rumahAdatPreviewImages.Length - 1;
        } else {
            selectedRumahIndex = selectedRumahIndex - 1;
        }

        UpdatePreview();
    }

    public void UpdatePreview() {
        previewImage.sprite = rumahAdatPreviewImages[selectedRumahIndex];
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
