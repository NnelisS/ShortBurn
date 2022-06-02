using UnityEngine;

public class Controller : MonoBehaviour
{
    public ActorObject SelectedPlayer;

    [Header("Clone Info")]
    [SerializeField] private int maxClones = 1;
    private int currentClones;
    [SerializeField] private GameObject clonePrefab;

    private GameObject clone = null;

    //R Record 10 sec
    //F Save
    //C Clone

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentClones < maxClones)
            {
                currentClones++;
                SelectedPlayer.gameObject.GetComponent<CloneSpawn>().MakeClone(clonePrefab, SelectedPlayer.gameObject);

                clone = SelectedPlayer.gameObject.GetComponent<CloneSpawn>().SetClone();
            }
            else
            {
               SelectedPlayer.gameObject.GetComponent<CloneSpawn>().ResetClone();
            }

            startRecording();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SelectedPlayer.gameObject.GetComponent<CloneSpawn>().ResetClone();

            startPlayback();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
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
