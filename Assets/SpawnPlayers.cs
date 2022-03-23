using UnityEngine;
using Photon.Pun;
using Cinemachine;
public class SpawnPlayers : MonoBehaviour {    

    public float maxX;
    public float maxY;
    public float minX;
    public float minY;

    void Start() {
        Vector2 randomPosition = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minY, maxY));

        string prefabName = PlayerAvatars.Instance.GetPlayerAvatarsName((int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]);

        PhotonNetwork.Instantiate(prefabName, randomPosition, Quaternion.identity);
    }

    private void OnPlayerSpawned() {
        
    }


}
