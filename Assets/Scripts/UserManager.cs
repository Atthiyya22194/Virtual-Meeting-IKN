using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;
    public string Name { get; private set; }
    public ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();

    private void Awake() {
        
        if (Instance == null) {
            Instance = FindObjectOfType<UserManager>();
            DontDestroyOnLoad(this);
        } else {
            Destroy(this);
        }

        Name = "User#" + Random.Range(1000, 9999);
        
    }

    public void SetName(string name) {
        Name = name;
    }
}
