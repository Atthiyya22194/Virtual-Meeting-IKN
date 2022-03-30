using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class BottomIconClick : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject chatbox;
    private bool chatboxToggle;

    public GameObject micButton, chatboxButton, shareButton;

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
        clickAnimation(micButton);
    }

    public void OnPressChatboxBottomButton() {
        chatboxToggle = !chatboxToggle;
        clickAnimation(chatboxButton);
    }

    public void OnPressChatboxCloseButton() {
        chatboxToggle = false;
    }

    public void OnPressShareButton() {
        clickAnimation(shareButton);
    }

    public void OnPressExitButton() {
        PhotonNetwork.LeaveRoom();        
    }

    public void clickAnimation(GameObject button) {
        LeanTween.scale(button, new Vector3(0.4f, 0.4f, 0.4f), 0.2f);
        LeanTween.scale(button, new Vector3(1f, 1f, 1f), 0.2f);
    }

    public override void OnLeftRoom() {
        PhotonNetwork.LoadLevel(0);
    }
}
