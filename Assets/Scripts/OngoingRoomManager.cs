using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class OngoingRoomManager : MonoBehaviourPunCallbacks {

    [SerializeField] private GameObject roomDetail;
    [SerializeField] private PlayerListItem playerListItemPrefab;
    [SerializeField] private Transform playerListTransform;
    [SerializeField] private TMP_Text roomCodeText;
    private void Start() {
        roomCodeText.text = "RoomCode: " + PhotonNetwork.CurrentRoom.Name;
        Player[] players = PhotonNetwork.PlayerList;

        for (int i = 0; i < players.Length; i++) {
            Instantiate(playerListItemPrefab, playerListTransform).Setup(players[i]);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Instantiate(playerListItemPrefab, playerListTransform).Setup(newPlayer);
    }

    private void Update() {
        if (Keyboard.current.tabKey.wasPressedThisFrame) {
            roomDetail.SetActive(!roomDetail.activeSelf);
        }
    }
}
