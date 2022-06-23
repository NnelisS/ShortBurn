using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterController : Mover
{
    public bool IsClone;
    public bool IsCrouched = false;
    public bool CrouchUsable = true;
    public bool InCrouch = false;
    public bool SoundOn = false;

    [HideInInspector] public GameObject Player;

    [SerializeField] private Transform playerHeight;
    private CinemachineVirtualCamera vCam;

    private Gravity gravity;
    private Pickup pickupScript;

    private void Start()
    {
        gravity = GetComponent<Gravity>();
        vCam = GetComponentInChildren<CinemachineVirtualCamera>();
        pickupScript = GetComponentInChildren<Pickup>();
    }

    /// <summary>
    /// Use the character controller to move the player by getting the rotation and motion
    /// </summary>
    public void Move(PlayerInputStruct _inputs)
    {
        if (!IsClone && SoundOn)
            PlayerAudio();

        if (IsClone)
        {
            if (GetComponent<MeshRenderer>().enabled == false)
            {
                GetComponent<MeshRenderer>().enabled = true;

                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }

        /*if (_inputs.TriggerJump)
        {
            gravity.TriggerJump();
            Debug.Log("The Jump press has been received");
        }*/

        //Character rotation
        if (IsClone)
        {
            transform.rotation *= Quaternion.Euler(0, Mathf.Lerp(_inputs.RotationDelta, _inputs.RotationDelta, _inputs.TimeStamp), 0);

            Vector3 rotated = transform.rotation * Vector3.Lerp(_inputs.positionDelta, _inputs.positionDelta, _inputs.TimeStamp);

            _charCont.Move(rotated * PlayerMovement.MoveSpeed);

            return;
        }

        //Character Movement
        _charCont.Move(transform.rotation * _inputs.positionDelta * PlayerMovement.MoveSpeed);
    }

    private void PlayerAudio()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            AudioManager.instance.Play("Walk");
        else
            AudioManager.instance.Stop("Walk");
    }

    /*private void Crouch()
    {
        if (CrouchUsable)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                IsCrouched = true;
                if (pickupScript.IsThrowing == false)
                    vCam.m_Lens.FieldOfView = Mathf.MoveTowards(vCam.m_Lens.FieldOfView, 52, 4 * Time.maximumDeltaTime);

                _charCont.height = Mathf.MoveTowards(_charCont.height, 0.4f, 4 * Time.deltaTime);
                playerHeight.transform.localPosition = Vector3.MoveTowards(playerHeight.transform.localPosition, new Vector3(playerHeight.transform.localPosition.x, 0.5f, playerHeight.transform.localPosition.z), 14 * Time.deltaTime);
                PlayerMovement.MoveSpeed = 0.01f;
            }
            else
            {
                if (InCrouch == false)
                {
                    IsCrouched = false;
                    _charCont.height = Mathf.Lerp(_charCont.height, 1.43f, 4 * Time.deltaTime);
                    playerHeight.transform.localPosition = Vector3.MoveTowards(playerHeight.transform.localPosition, new Vector3(playerHeight.transform.localPosition.x, 0.8f, playerHeight.transform.localPosition.z), 14 * Time.deltaTime);
                    if (pickupScript.IsThrowing == false)
                    {
                        vCam.m_Lens.FieldOfView = Mathf.MoveTowards(vCam.m_Lens.FieldOfView, 60, 4 * Time.maximumDeltaTime);
                        PlayerMovement.MoveSpeed = 0.03f;
                    }
                }
            }
        }
    }*/

    /// <summary>
    /// Reset input and enable charactercontroller
    /// </summary>
    public void Reset()
    {
        _charCont.enabled = true;
    }

    /*public void GoCrouch()
    {
        IsCrouched = true;
        if (pickupScript.IsThrowing == false)
            vCam.m_Lens.FieldOfView = Mathf.MoveTowards(vCam.m_Lens.FieldOfView, 52, 4 * Time.maximumDeltaTime);

        _charCont.height = Mathf.MoveTowards(_charCont.height, 0.4f, 4 * Time.deltaTime);
        playerHeight.transform.localPosition = Vector3.MoveTowards(playerHeight.transform.localPosition, new Vector3(playerHeight.transform.localPosition.x, 0.5f, playerHeight.transform.localPosition.z), 14 * Time.deltaTime);
        PlayerMovement.MoveSpeed = 0.01f;
    }

    public void OutCrouch()
    {
        IsCrouched = false;
        _charCont.height = Mathf.Lerp(_charCont.height, 1.43f, 4 * Time.deltaTime);
        playerHeight.transform.localPosition = Vector3.MoveTowards(playerHeight.transform.localPosition, new Vector3(playerHeight.transform.localPosition.x, 0.8f, playerHeight.transform.localPosition.z), 14 * Time.deltaTime);
        if (pickupScript.IsThrowing == false)
        {
            vCam.m_Lens.FieldOfView = Mathf.MoveTowards(vCam.m_Lens.FieldOfView, 60, 4 * Time.maximumDeltaTime);
            PlayerMovement.MoveSpeed = 0.03f;
        }
    }*/
}
