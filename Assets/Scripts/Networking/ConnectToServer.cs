using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks {

    public GameObject roomGameObject;
    public GameObject lobbyGameObject;

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
    }

    public override void OnJoinedLobby() {
        roomGameObject.SetActive(false);
        lobbyGameObject.SetActive(true);
    }
}
