using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    //This class should include all the potential inputs that the player makes
    private float previousRotation;

    public void SetPreviousRotation(float _rotation)
    {
        previousRotation = _rotation;
    }

    /// <summary>
    /// Get PlayerInputStruct with corrisponding input
    /// </summary>
    public PlayerInputStruct CreateInputStruct(float _timeStamp = 0)
    {
        Vector3 positionDelta = Vector3.forward * Input.GetAxis("Vertical") -
                                Vector3.left * Input.GetAxis("Horizontal");
        float rotationDelta = transform.eulerAngles.y - previousRotation;

        bool triggerJump = Input.GetKeyDown(KeyCode.Space);

        PlayerInputStruct _playerInputs = new PlayerInputStruct(positionDelta, rotationDelta, triggerJump, _timeStamp);
        return _playerInputs;
    }
}