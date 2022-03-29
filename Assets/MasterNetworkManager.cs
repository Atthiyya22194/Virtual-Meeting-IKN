using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MasterNetworkManager : MonoBehaviourPunCallbacks {

    [SerializeField] GameEvent OnJoinLobby;
    [SerializeField] GameEvent OnCharacterSelect;

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

    public override void OnJoinedLobby() {
        OnJoinLobby.Raise();
    }

    public override void OnJoinedRoom() {
        OnCharacterSelect.Raise();
    }

    public void Response_MasukButtonClicked() {
        //PhotonNetwork.LoadLevel("MeetingRoom");
        PhotonNetwork.LoadLevel(1);
    }
}
