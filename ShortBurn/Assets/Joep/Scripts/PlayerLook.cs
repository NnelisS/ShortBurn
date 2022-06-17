using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine(StarRotation());
    }

    private void Update()
    {
        if (!movementOn) return;

        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        playerRecorder.SetPreviousRotation(transform.eulerAngles.y);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up, mouseX);
    }

    private IEnumerator StarRotation()
    {
        movementOn = false;
        xRotation = 0;

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        yield return new WaitForSeconds(1f);
        movementOn = true;
    }

    public void ChangeMovement()
    {
        movementOn = !movementOn;
    }
}
