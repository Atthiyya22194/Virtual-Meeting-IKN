using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;
using TMPro;
using Photon.Pun;

public class ChatManager : MonoBehaviour
{
    private PhotonView photonView;
    private List<string> messages = new List<string>();
    private float buildDelay = 0f;
    private int maximumMessages = 14;
}
