using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostweepGames.VoicePro;

public class SoundInput : MonoBehaviour
{
    public Recorder recorder;
    public Listener listener;
    public bool isRecording;
    public bool buttonToggle;

    void Awake() {
        buttonToggle = false;
    }

    void Update() {
        if (buttonToggle == true && !isRecording) {
            StartRecord();
        } else if (buttonToggle == false && isRecording) {
            StopRecord();
        }
    }

    public void Record() {
        if (Input.GetKeyDown(KeyCode.R) && !isRecording) {
            StartRecord();
        } else if (Input.GetKeyUp(KeyCode.R) && isRecording) {
            StopRecord();
        }
    }

    public void StartRecord() {
        recorder.StartRecord();
        isRecording = true;
    }

    public void StopRecord() {
        recorder.StopRecord();
        isRecording = false;
    }
}
