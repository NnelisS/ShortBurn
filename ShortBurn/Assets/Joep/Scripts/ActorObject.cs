using System.Collections;
using System.Collections.Generic;
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

    //UI Timer
    public Text TimerText;

    void Start()
    {
        //initialize the variables
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

    private void PlayingState()
    {
        timer = timer + Time.deltaTime;
        TimerText.text = timer.ToString("F2");
        playerInput.GetInputs();
        PlayerInputStruct userInput = playerInput.GetInputStruct();
        inputRec.AddToDictionary(timer, userInput);
        objectController.GivenInputs(userInput);
        objectController.Move();
        playerInput.ResetInput();
    }

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
        TimerText.text = playbackTimer.ToString("F2");
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

    private void ResetState()
    {
        if (!IsClone)
            MoveAgent();
        timer = 0;
        TimerText.text = "0.00";
    }

    private void NoneState()
    {
        if (!IsClone)
        MoveAgent();
    }

    private void MoveAgent()
    {
        playerInput.GetInputs();
        PlayerInputStruct userInput = playerInput.GetInputStruct();
        objectController.GivenInputs(userInput);
        objectController.Move();
        playerInput.ResetInput();
    }

    #endregion

    public void Recording()
    {
        timer = 0;
        inputRec.ClearHistory();
        CurrentState = State.Playing;
    }


    public void Playback()
    {
        newPlayback = true;
        CurrentState = State.Playback;
    }

    public void Reset()
    {
        objectController.Reset();
        CurrentState = State.Reset;
        playerInput.ResetInput();
    }
}