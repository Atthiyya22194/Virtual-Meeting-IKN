using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public void OnPressChatboxBottomButton() {
        chatboxToggle = !chatboxToggle;
    }

    public void OnPressChatboxCloseButton() {
        chatboxToggle = false;
    }
}
