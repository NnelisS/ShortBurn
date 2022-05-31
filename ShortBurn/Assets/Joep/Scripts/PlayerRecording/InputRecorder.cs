using System.Collections.Generic;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    private List<PlayerInputStruct> playerInputRecord;
    private float duration;

    void Start()
    {
        playerInputRecord = new List<PlayerInputStruct>();
    }

    /// <summary>
    /// Sets the _time playerInputs as the duration if bigger and ads the _inputs to the list
    /// </summary>
    public void AddToList(float _time, PlayerInputStruct _inputs)
    {
        playerInputRecord.Add(_inputs);
        duration = Mathf.Max(duration, _time);
    }

    /// <summary>
    /// Make a new list and replace the old one
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

    /// <summary>
    /// Returns true if the _timeStamp is bigger than the duration
    /// </summary>
    public bool IsCompleted(float _timeStamp)
    {
        return _timeStamp > duration;
    }
}