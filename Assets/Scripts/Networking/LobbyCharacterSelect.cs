using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyCharacterSelect : MonoBehaviourPunCallbacks
{
    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    
    [SerializeField] RawImage playerAvatar;
    [SerializeField] RenderTexture[] renderTextureAvatars;

    
    public void OnPrevButton_Clicked() {
        if ((int)playerProperties["playerAvatar"] == 0) {
            playerProperties["playerAvatar"] = renderTextureAvatars.Length - 1;
        }
        else {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }
        
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);        
    }

    public void OnNextButton_Clicked() {
        if ((int)playerProperties["playerAvatar"] == renderTextureAvatars.Length - 1) {
            playerProperties["playerAvatar"] = 0;
        }
        else {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        }

        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public void OnMasukButton_Clicked() {
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps) {
        if (targetPlayer == PhotonNetwork.LocalPlayer) {
            UpdatePlayerAvatar(); 
        }
    }

    public void UpdatePlayerAvatar() {
        playerProperties = PhotonNetwork.LocalPlayer.CustomProperties;
        playerAvatar.texture = renderTextureAvatars[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
    }
}
