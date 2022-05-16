using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public ActorObject SelectedPlayer;

    public void startRecording()
    {
        //resetPlayer();
        SelectedPlayer.Recording();
    }

    public void startPlayback()
    {
        //resetPlayer();
        SelectedPlayer.Playback();
    }

    public void resetPlayer()
    {
        SelectedPlayer.Reset();
    }
}
