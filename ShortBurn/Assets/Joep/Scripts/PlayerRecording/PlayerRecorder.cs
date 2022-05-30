using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    //This class should include all the potential inputs that the player makes

    private float previousRotation;

    private void Start()
    {
        previousRotation = transform.eulerAngles.y;
    }

    private void LateUpdate()
    {
        previousRotation = transform.eulerAngles.y;
    }

    /// <summary>
    /// Get PlayerInputStruct with corrisponding input
    /// </summary>
    public PlayerInputStruct GetInputStruct()
    {
        Vector3 positionDelta = Vector3.forward * Input.GetAxis("Vertical") -
                                Vector3.right * Input.GetAxis("Horizontal");
        float rotationDelta = transform.eulerAngles.y - previousRotation;

        bool triggerJump = Input.GetKeyDown(KeyCode.Space);

        PlayerInputStruct _playerInputs = new PlayerInputStruct(positionDelta, rotationDelta, triggerJump, Time.deltaTime);
        return _playerInputs;
    }
}