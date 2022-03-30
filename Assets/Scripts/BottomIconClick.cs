using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class BottomIconClick : MonoBehaviour
{
    [SerializeField]
    private GameObject chatbox;
    private bool chatboxToggle;

    void Awake() {
        chatboxToggle = false;
        chatbox.SetActive(false);
    }

    void Update() {
        if (chatboxToggle == true) {
            chatbox.SetActive(true);
        } else {
            chatbox.SetActive(false);
        }
    }

    public void OnPressMicButton() {

    }

    public void OnPressChatboxBottomButton() {
        chatboxToggle = !chatboxToggle;
    }

    public void OnPressChatboxCloseButton() {
        chatboxToggle = false;
    }

    public void OnPressShareButton() {

    }

    public void OnPressExitButton() {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(0);
    }
}
