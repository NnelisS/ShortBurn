using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public ActorObject SelectedPlayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            startRecording();
        if (Input.GetKeyDown(KeyCode.P))
            startPlayback();

    }

    public void startRecording()
    {
        //resetPlayer();
        print("Recording");
        SelectedPlayer.Recording();
    }

    public void startPlayback()
    {
        //resetPlayer();
        print("PlayBack");
        SelectedPlayer.Playback();
    }

    public void resetPlayer()
    {
        print("Reset");
        SelectedPlayer.Reset();
    }
}
