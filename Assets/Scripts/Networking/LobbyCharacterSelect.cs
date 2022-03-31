using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyCharacterSelect : MonoBehaviourPunCallbacks
{
    ExitGames.Client.Photon.Hashtable playerProperties;
    
    [SerializeField] RawImage playerAvatar;
    [SerializeField] RenderTexture[] renderTextureAvatars;

    private void Awake() {
        playerProperties = PhotonNetwork.LocalPlayer.CustomProperties;
    }

    public void OnPrevButton_Clicked() {
        if ((int)playerProperties["playerAvatar"] == 0) {
            playerProperties["playerAvatar"] = renderTextureAvatars.Length - 1;
        }
        else {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }
        
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        UpdatePlayerAvatar();
    }

    public void OnNextButton_Clicked() {
        if ((int)playerProperties["playerAvatar"] == renderTextureAvatars.Length - 1) {
            playerProperties["playerAvatar"] = 0;
        }
        else {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        }

        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        UpdatePlayerAvatar();
    }

    public void OnMasukButton_Clicked() {
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps) {
        Debug.Log(playerProperties["playerAvatar"]);
        if (targetPlayer == PhotonNetwork.LocalPlayer) {
            UpdatePlayerAvatar(); 
        }
    }

    public void UpdatePlayerAvatar() {
        playerAvatar.texture = renderTextureAvatars[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
    }
}
