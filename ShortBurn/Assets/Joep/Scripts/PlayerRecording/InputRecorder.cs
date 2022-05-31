using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    private List<PlayerInputStruct> playerInputRecord;
    private float duration;

    void Start()
    {
        //Intialize the queue that will be used to record inputs
        playerInputRecord = new List<PlayerInputStruct>();
    }

    /// <summary>
    /// Adds the timeStamp and playerInputs into the dictionary
    /// </summary>
    public void AddToDictionary(float _time, PlayerInputStruct _inputs)
    {
        playerInputRecord.Add(_inputs);
        duration = Mathf.Max(duration, _time);
    }

    /// <summary>
    /// Make a new dictionary and replace the old one
    /// </summary>
    public void ClearHistory()
    {
        playerInputRecord = new List<PlayerInputStruct>();
        duration = 0;
    }

    /// <summary>
    /// Returns the inputStruct at current timeStamp(in)
    /// </summary>
    public PlayerInputStruct GetRecordedInputs(float _timeStamp)
    {
        for (int i = 0; i < playerInputRecord.Count; i++)
        {
            if (playerInputRecord[i].TimeStamp < _timeStamp)
                continue;

            return playerInputRecord[i];
        }

        return playerInputRecord[playerInputRecord.Count - 1];
    }

    public bool IsCompleted(float _timeStamp)
    {
        return _timeStamp > duration;
    }
}