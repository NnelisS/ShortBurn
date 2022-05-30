using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    private List<PlayerInputStruct> playerInputRecord;

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
    }

    /// <summary>
    /// Make a new dictionary and replace the old one
    /// </summary>
    public void ClearHistory()
    {
        playerInputRecord = new List<PlayerInputStruct>();
    }

    /// <summary>
    /// Returns the inputStruct at current timeStamp(in)
    /// </summary>
    public PlayerInputStruct GetRecordedInputs(float _timeStamp)
    {
        PlayerInputStruct value;
        for (int i = 0; i < playerInputRecord.Count; i++)
        {
            if (playerInputRecord[i].DeltaTime < _timeStamp)
                continue;

            return playerInputRecord[i];
        }

        return playerInputRecord[playerInputRecord.Count - 1];
    }
}