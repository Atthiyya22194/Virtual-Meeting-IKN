using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MasterNetworkManager : MonoBehaviourPunCallbacks {

    [SerializeField] GameEvent OnJoinLobby;
    [SerializeField] GameEvent OnCharacterSelect;

    public List<RoomInfo> roomInfos = new List<RoomInfo>();

    private static MasterNetworkManager _instance;
    public static MasterNetworkManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<MasterNetworkManager>();
            }
            return _instance;
        }
    }

    private void Awake() {
    #if !UNITY_EDITOR && UNITY_WEBGL
        WebGLInput.captureAllKeyboardInput = true;
    #endif
    }

    private void Start() {
        if (!PhotonNetwork.IsConnected) {
            PhotonNetwork.OfflineMode = false;
            PhotonNetwork.GameVersion = Application.version;
            PhotonNetwork.ConnectUsingSettings();

        } else {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster() {        
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.NickName = UserManager.Instance.Name;
        PhotonNetwork.JoinLobby(TypedLobby.Default);

        if (PlayerPrefs.HasKey("PlayerAvatar")) {
            UserManager.Instance.playerProperties["playerAvatar"] = PlayerPrefs.GetInt("PlayerAvatar");
        }
        else {
            UserManager.Instance.playerProperties["playerAvatar"] = 0;
        }

        PhotonNetwork.SetPlayerCustomProperties(UserManager.Instance.playerProperties);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList) {        
        roomInfos = roomList;
    }

    public override void OnJoinedLobby() {
        OnJoinLobby.Raise();
    }

    public override void OnJoinedRoom() {
        //PhotonNetwork.LoadLevel("MeetingRoom");
        PhotonNetwork.LoadLevel(1);
    }

    public void Response_MasukButtonClicked() {        
        if (CreateJoinRoom.Instance.lobbyState == LobbyState.Create) {
            CreateJoinRoom.Instance.CreateRoom();
        } else {
            string roomName = CreateJoinRoom.Instance.roomNameInputField.text;
            PhotonNetwork.JoinRoom(roomName);
        }
    }

    public void Response_BackToLobby() {
        //PhotonNetwork.LeaveRoom();
    }
}
