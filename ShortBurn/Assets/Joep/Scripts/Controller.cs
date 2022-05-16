using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject SelectedPlayer;

    public void startRecording()
    {
        //resetPlayer();
        SelectedPlayer.GetComponent<ActorObject>().Recording();
    }

    public void startPlayback()
    {
        //resetPlayer();
        SelectedPlayer.GetComponent<ActorObject>().Playback();
    }

    public void resetPlayer()
    {
        SelectedPlayer.GetComponent<ActorObject>().Reset();
    }
}
