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
        resetPlayer();
        SelectedPlayer.Recording();
    }

    public void startPlayback()
    {
        resetPlayer();
        SelectedPlayer.Playback();
    }

    public void resetPlayer()
    {
        SelectedPlayer.Reset();
    }
}
