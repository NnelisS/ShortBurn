using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public ActorObject SelectedPlayer;

    [Header("Clone Info")]
    [SerializeField] private int maxClones = 1;
    private int currentClones;
    [SerializeField] private GameObject clonePrefab;

    private GameObject clone = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentClones < maxClones)
            {
                currentClones++;
                SelectedPlayer.gameObject.GetComponent<CloneSpawn>().MakeClone(clonePrefab);

                clone = SelectedPlayer.gameObject.GetComponent<CloneSpawn>().SetClone();
            }
            else
            {
                SelectedPlayer.gameObject.GetComponent<CloneSpawn>().ResetClone();
            }

            startRecording();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            //reset pos change later
            SelectedPlayer.gameObject.GetComponent<CloneSpawn>().ResetClone();

            startPlayback();
        }
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
