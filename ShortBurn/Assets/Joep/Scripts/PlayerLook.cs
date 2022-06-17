using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Mouse Settings")]
    public float MouseSensitivity = 100;
    public GameObject cam;

    private PlayerRecorder playerRecorder;
    private float xRotation = 0;

    public bool movementOn = true;

    private void Awake()
    {
        cam.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Start()
    {
        playerRecorder = GetComponent<PlayerRecorder>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (movementOn)
        {
            float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerRecorder.SetPreviousRotation(transform.eulerAngles.y);

            cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.Rotate(Vector3.up, mouseX);
        }
        else
        {

        }
    }

    public void ChangeMovement()
    {
        movementOn = !movementOn;
    }
}
