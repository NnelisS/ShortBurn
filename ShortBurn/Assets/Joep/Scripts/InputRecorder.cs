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
    public void AddToDictionary(float time, PlayerInputStruct inputs)
    {
        playerInputRecord.Add(time, inputs);
    }

    public void ClearHistory()
    {
        playerInputRecord = new Dictionary<float, PlayerInputStruct>();
    }

    //Check if key exists
    public bool KeyExists(float key)
    {
        return playerInputRecord.ContainsKey(key);
    }

    //Returns the inputStruct at current timeStamp(in)
    public PlayerInputStruct getRecordedInputs(float timeStamp)
    {
        return playerInputRecord[timeStamp];
    }
}