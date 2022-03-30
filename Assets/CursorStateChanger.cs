using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorStateChanger : MonoBehaviour
{
    private void Update() {
        if (Keyboard.current.escapeKey.wasReleasedThisFrame && Cursor.lockState == CursorLockMode.Locked) {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void LockCursor() {        
        Cursor.lockState = CursorLockMode.Locked;
    }

}
