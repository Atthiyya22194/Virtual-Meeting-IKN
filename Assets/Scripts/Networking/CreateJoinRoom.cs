using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateJoinRoom : MonoBehaviourPunCallbacks {

    public GameObject lobbyGameObject;
    public GameObject roomGameObject;
    public TMP_InputField roomNameInputField;

    public GameObject masterStartButton;    

    private Dictionary<Player, UserRoomPanel> userDisplayed = new Dictionary<Player, UserRoomPanel>();

    public Transform roomPanel;
    public UserRoomPanel userRoomPrefab;

    private string tempName;

    private void CleanUpRoom() {
        userDisplayed.Clear();
        foreach (Transform child in roomPanel) {
            Destroy(child.gameObject);
        }
    }

    public void CreateRoom() {
        string roomName = "tes";
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 4
        };
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    private void RefreshDisplayedUser() {
        var playerList = PhotonNetwork.PlayerList;
        Debug.Log(playerList.Length);
        for (int i = 0; i < playerList.Length; i++) {
            if (!userDisplayed.ContainsKey(playerList[i])) {
                UserRoomPanel userRoomPanel = Instantiate(userRoomPrefab, roomPanel);
                userRoomPanel.SetPlayer(playerList[i]);
                userDisplayed.Add(playerList[i], userRoomPanel);
            }
        }
    }

    public override void OnJoinedRoom() {
        CleanUpRoom();

        roomGameObject.SetActive(true);
        lobbyGameObject.SetActive(false);

        RefreshDisplayedUser();

        if (PhotonNetwork.IsMasterClient) {
            // show start button
            masterStartButton.SetActive(true);
            PhotonNetwork.AutomaticallySyncScene = true;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {
        UserRoomPanel userRoomPanel = Instantiate(userRoomPrefab, roomPanel);
        userRoomPanel.SetPlayer(newPlayer);
        userDisplayed.Add(newPlayer, userRoomPanel);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        Destroy(userDisplayed[otherPlayer].gameObject);
        userDisplayed.Remove(otherPlayer);
    }

    public override void OnMasterClientSwitched(Player newMasterClient) {
        if (newMasterClient == PhotonNetwork.LocalPlayer) {
            masterStartButton.SetActive(true);
        }
    }

    public void OnMasterPlayButton_Clicked() {
        //PhotonNetwork.LoadLevel("MeetingRoom");
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

    public void OnLeaveRoomButton_Clicked() {
        userDisplayed.Clear();
        masterStartButton.SetActive(false);
        PhotonNetwork.LeaveRoom();        
    }

    public void SetTempName(TMP_InputField inputField) {
        tempName = inputField.text;        
    }
    
}
