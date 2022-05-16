using UnityEngine;
using UnityEngine.UI;

public enum State
{
    Playing,
    Playback,
    Reset,
    None
}

public class ActorObject : MonoBehaviour
{
    //What do actor objects need?
    //List-----------------------
    //1. Player Input
    //   Need a player recorder class to record inputs that are being sent to character.
    //2. Object Controller
    //   This object controller needs to read inputs and apply them to object.
    //3. Recording System / Playback System
    //   Recording system will need to record inputs from the player and then be able to play it back to the object


    //1 
    private PlayerRecorder playerInput;

    //2
    private CharacterController objectController;
    public CharacterController NewController;

    //3
    private InputRecorder inputRec;

    public State CurrentState;

    //Booleans to check initial state changes
    public bool IsClone;
    private bool newPlayback = false;
    private float timer;
    private float playbackTimer;

    void Start()
    {
        //initialize the variables
        if (IsClone)
            CurrentState = State.Reset;
        else
            CurrentState = State.None;

        playerInput = GetComponent<PlayerRecorder>();
        objectController = GetComponent<CharacterController>();
        inputRec = GetComponent<InputRecorder>();
        timer = 0;
        playbackTimer = 0;
    }

    void Update()
    {
        playerInput.ListenForKeyPresses();
    }

    void FixedUpdate()
    {
        switch (CurrentState)
        {
            case State.Playing:
                PlayingState();
                break;
            case State.Playback:
                PlaybackState();
                break;
            case State.Reset:
                ResetState();
                break;
            case State.None:
                NoneState();
                break;
        }
    }

    #region States

    /// <summary>
    /// Increase timer and adds the time to the dictionary and moves the agent
    /// </summary>
    private void PlayingState()
    {
        timer = timer + Time.deltaTime;
        playerInput.GetInputs();
        PlayerInputStruct _userInput = playerInput.GetInputStruct();
        inputRec.AddToDictionary(timer, _userInput);
        objectController.GivenInputs(_userInput);
        objectController.Move();
        playerInput.ResetInput();
    }

    /// <summary>
    /// Get the player input and give it to the clone
    /// </summary>
    private void PlaybackState()
    {
        if (!IsClone)
            MoveAgent();

        if (newPlayback == true)
        {
            playbackTimer = 0;
            newPlayback = false;
        }

        playbackTimer = playbackTimer + Time.deltaTime;
        if (inputRec.KeyExists(playbackTimer))
        {
            PlayerInputStruct recordedInputs = inputRec.getRecordedInputs(playbackTimer);
            if (recordedInputs.buttonPressed == true)
            {
                Debug.Log("At" + playbackTimer + "the value of the button press is" + recordedInputs.buttonPressed);
            }
            NewController.GivenInputs(recordedInputs);
            NewController.Move();
        }
    }

    /// <summary>
    /// Resets the timer
    /// </summary>
    private void ResetState()
    {
        if (!IsClone)
            MoveAgent();
        timer = 0;
    }

    /// <summary>
    /// Do nothing unless its the player
    /// </summary>
    private void NoneState()
    {
        if (!IsClone)
        MoveAgent();
    }

    /// <summary>
    /// Move the agent 
    /// </summary>
    private void MoveAgent()
    {
        playerInput.GetInputs();
        PlayerInputStruct _userInput = playerInput.GetInputStruct();
        objectController.GivenInputs(_userInput);
        objectController.Move();
        playerInput.ResetInput();
    }

    #endregion

    /// <summary>
    /// Clear the recordings and start recording
    /// </summary>
    public void Recording()
    {
        timer = 0;
        inputRec.ClearHistory();
        CurrentState = State.Playing;
    }

    /// <summary>
    /// Set boolean true and change state
    /// </summary>
    public void Playback()
    {
        newPlayback = true;
        CurrentState = State.Playback;
    }

    /// <summary>
    /// Resets input, calls objectController.Reset and change state
    /// </summary>
    public void Reset()
    {
        objectController.Reset();
        CurrentState = State.Reset;
        playerInput.ResetInput();
    }
}