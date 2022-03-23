using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatars : MonoBehaviour
{
    private static PlayerAvatars _instance;
    public static PlayerAvatars Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<PlayerAvatars>();
            }
            return _instance;
        }
    }
    [SerializeField]

    private List<GameObject> playerAvatars = new List<GameObject>();
    

    public string GetPlayerAvatarsName(int index) {
        return playerAvatars[index].name;
    }
}
