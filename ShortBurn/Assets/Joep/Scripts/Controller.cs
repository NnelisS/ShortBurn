using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject selectedPlayer;

    public void startRecording()
    {
        //resetPlayer();
        selectedPlayer.GetComponent<ActorObject>().recording();
    }

    public void startPlayback()
    {
        //resetPlayer();
        selectedPlayer.GetComponent<ActorObject>().playback();
    }

    public void resetPlayer()
    {
        selectedPlayer.GetComponent<ActorObject>().reset();
    }
}
