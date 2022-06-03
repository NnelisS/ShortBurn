using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{
    public UnityEvent OnRecord;

    public UnityEvent OnClone;

    public UnityEvent OnSave;

    public ActorObject SelectedPlayer;

    [Header("Clone Info")]
    [SerializeField] private int maxClones = 1;
    private int currentClones;
    [SerializeField] private GameObject clonePrefab;

    private GameObject clone = null;

    private bool isRecording = false;
    public float PropTimer { get; private set; }

    private void Update()
    {
        Debug.Log(PropTimer);

        if (isRecording)
        {
            Timer();

            if (PropTimer >= 5)
                SafeState();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isRecording)
            {
                isRecording = true;

                if (currentClones < maxClones)
                {
                    currentClones++;
                    SelectedPlayer.gameObject.GetComponent<CloneSpawn>().MakeClone(clonePrefab, SelectedPlayer.gameObject);

                    clone = SelectedPlayer.gameObject.GetComponent<CloneSpawn>().SetClone();
                }

                startRecording();
            }
            else
                SafeState();
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

    private void Timer()
    {
        PropTimer += Time.deltaTime;
    }

    private void SafeState()
    {
        resetPlayer();
        PropTimer = 0;
        isRecording = false;
    }
}
