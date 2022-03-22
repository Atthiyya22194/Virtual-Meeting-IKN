using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;
    public string Name { get; private set; }    

    private void Awake() {
        DontDestroyOnLoad(this);
        Instance = this;

        Name = "User#" + Random.Range(1000, 9999);
    }

    public void SetName(string name) {
        Name = name;
    }
}
