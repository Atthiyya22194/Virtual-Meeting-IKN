using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorStateChanger : MonoBehaviour, IPointerDownHandler
{
    GraphicRaycaster raycaster;

    private void Start() {
        raycaster = GetComponent<GraphicRaycaster>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        List<RaycastResult> results = new List<RaycastResult>();

        raycaster.Raycast(eventData, results);

        foreach (RaycastResult result in results) {
            if (result.gameObject == gameObject) {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

}
