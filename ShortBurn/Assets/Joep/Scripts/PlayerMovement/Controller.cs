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
    [SerializeField] private ParticleSystem cloneExplosion;

    public float PropTimer { get; private set; }
    public float MaxRecordTime;

    private int currentClones;
    [HideInInspector] public GameObject clone = null;
    private bool isRecording = false, isCloning = false;
    private Pickup pickup;
    private float oldTime;
    private bool canClone = false;
    public bool canRecord = false;

    private void Start()
    {
        if (RecordSlider != null)
            RecordSlider.maxValue = MaxRecordTime;
        pickup = SelectedPlayer.gameObject.GetComponentInChildren<Pickup>();
    }

    private void Update()
    {
        PropTimer = Mathf.Clamp(PropTimer, 0, MaxRecordTime);

        if (isRecording)
        {
            Timer(false);

            if (PropTimer >= MaxRecordTime)
                SafeState();
        }
        if (isCloning)
        {
            Timer(true);
            if (PropTimer <= 0)
                isCloning = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && pickup.heldObject == null && canRecord)
        {
            if (!isRecording)
            {
                PropTimer = 0;
                oldTime = 0;
                isRecording = true;
                canClone = true;

                if (currentClones < maxClones)
                {
                    currentClones++;
                    SelectedPlayer.gameObject.GetComponent<CloneSpawn>().MakeClone(clonePrefab, SelectedPlayer.gameObject);

                    clone = SelectedPlayer.gameObject.GetComponent<CloneSpawn>().SetClone();
                }

                startRecording();
            }
            else
            {
                OnSave?.Invoke();
                SafeState();
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!canClone)
            {
                AudioManager.instance.Play("CantPlay");
                return;
            }

            if (clone != null)
            {
                SelectedPlayer.gameObject.GetComponent<CloneSpawn>().ResetClone();
            }

            isCloning = true;
            SafeState();
            StartPlayback();
        }
        else if (Input.GetKeyDown(KeyCode.P) && !isCloning)
        {
            if (!canClone)
            {
                AudioManager.instance.Play("CantPlay");
                return;
            }

            if (oldTime != 0)
                PropTimer = oldTime;

            isCloning = true;
            SafeState();
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
        if (clone != null)
        {
            clone.SetActive(false);
            AudioManager.instance.Play("Electricity");
            cloneExplosion.transform.position = clone.transform.position;
            cloneExplosion.Play();
        }
    }

    private void Timer(bool revert)
    {
        if (!revert)
            PropTimer += Time.deltaTime;
        else
            PropTimer -= Time.deltaTime;

        if (RecordSlider != null)
            RecordSlider.value = PropTimer;
    }

    private void SafeState()
    {
        ResetPlayer();
        isRecording = false;
        oldTime = PropTimer;
    }
}
