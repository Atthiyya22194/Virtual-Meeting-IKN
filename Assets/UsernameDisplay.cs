using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class UsernameDisplay : MonoBehaviour
{
    [SerializeField] PhotonView _photonView;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text roomText;
    [SerializeField] TMP_Text currentUsers;

    void Start()
    {
        if (_photonView.IsMine) {
            gameObject.SetActive(false);
        }

        nameText.text = _photonView.Owner.NickName;

        if (_photonView.IsMine)
        {
            gameObject.SetActive(true);
        }
        roomText.text = "Room Code: " + PhotonNetwork.CurrentRoom.Name;
        currentUsers.text = "Currently users in this room:" + PhotonNetwork.PlayerList;
    }
    
}
