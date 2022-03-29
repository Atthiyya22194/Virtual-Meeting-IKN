using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostweepGames.VoicePro;

public class SoundInput : MonoBehaviour
{
    public Recorder recorder;
    public Listener listener;
    public bool isRecording;

    void Update() {
        if (Input.GetKeyDown(KeyCode.R) && !isRecording) {
            StartRecord();
            isRecording = true;
        } else if (Input.GetKeyUp(KeyCode.R) && isRecording) {
            StopRecord();
            isRecording = false;
        }
    }

    public void StartRecord() {
        recorder.StartRecord();
    }

    public void StopRecord() {
        recorder.StopRecord();
    }
}
