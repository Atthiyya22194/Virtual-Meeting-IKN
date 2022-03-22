using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class UserRoomPanel : MonoBehaviour
{
    public TMP_Text nameText;

    public Player Player { get; private set; }

    public void SetPlayer(Player player) {
        Player = player;
        nameText.text = player.NickName;
    }

    public void SetNameTextUI(string name) {
        nameText.text = name;
    }
}
