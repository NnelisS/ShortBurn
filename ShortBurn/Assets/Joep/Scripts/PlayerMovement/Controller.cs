using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public UnityEvent OnRecord;

    public UnityEvent OnClone;

    public UnityEvent OnSave;

    public ActorObject SelectedPlayer;

    public Slider RecordSlider;

    [Header("Clone Info")]
    [SerializeField] private int maxClones = 1;
    [SerializeField] private GameObject clonePrefab;

    public float PropTimer { get; private set; }

    private int currentClones;
    [HideInInspector] public GameObject clone = null;
    private bool isRecording = false;
    private Pickup pickup;

    private void Start()
    {
        pickup = SelectedPlayer.gameObject.GetComponentInChildren<Pickup>();
    }

    private void Update()
    {
        if (isRecording)
        {
            Timer();

            if (PropTimer >= 5)
                SafeState();
        }

        if (Input.GetKeyDown(KeyCode.R) && pickup.heldObject == null)
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

            StartPlayback();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartPlayback();
        }
    }

    public void startRecording()
    {
        ResetPlayer();
        OnRecord?.Invoke();
        SelectedPlayer.Recording();
    }

    public void StartPlayback()
    {
        ResetPlayer();
        OnClone?.Invoke();
        SelectedPlayer.Playback();
    }

    public void ResetPlayer()
    {
        SelectedPlayer.Reset();
    }

    public void DestroyClone()
    {
        ResetPlayer();
        clone.SetActive(false);
    }

    private void Timer()
    {
        PropTimer += Time.deltaTime;

        if (RecordSlider != null)
            RecordSlider.value = PropTimer;
    }

    private void SafeState()
    {
        OnSave?.Invoke();
        ResetPlayer();
        PropTimer = 0;
        isRecording = false;
    }
}
