using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    private PlayerRecorder playerInputs;
    private Dictionary<float, PlayerInputStruct> playerInputRecord;

    void Start()
    {
        //Intialize the queue that will be used to record inputs
        playerInputRecord = new Dictionary<float, PlayerInputStruct>();
    }

    //Adds the timeStamp and playerInputs into the dictionary
    //The timeStamp is the key
    //The inputStruct (inputs) is the value of the key
    //This function is used by the actorObject script as the dictionary is private
    public void AddToDictionary(float _time, PlayerInputStruct _inputs)
    {
        playerInputRecord.Add(_time, _inputs);
    }

    /// <summary>
    /// Make a new dictionary and replace the old one
    /// </summary>
    public void ClearHistory()
    {
        playerInputRecord = new Dictionary<float, PlayerInputStruct>();
    }

    /// <summary>
    /// Check if key exists
    /// </summary>
    public bool KeyExists(float _key)
    {
        return playerInputRecord.ContainsKey(_key);
    }

    /// <summary>
    /// Returns the inputStruct at current timeStamp(in)
    /// </summary>
    public PlayerInputStruct getRecordedInputs(float _timeStamp)
    {
        return playerInputRecord[_timeStamp];
    }
}