using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beginning : MonoBehaviour
{    
    public GameObject UI;
    public Pause Pauser;
    public Transform CamRot;

    private UnityEngine.CharacterController charCont;
    private CharacterController charController;
    private PlayerLook playerL;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        CamRot.localRotation = Quaternion.Euler(0, 0, 0);

        UI.SetActive(false);
        Pauser.enabled = false;
        charCont = FindObjectOfType<UnityEngine.CharacterController>();
        charController = FindObjectOfType<CharacterController>();
        playerL = FindObjectOfType<PlayerLook>();

        charCont.enabled = false;
        charController.enabled = false;
        playerL.enabled = false;
    }

    public void TurnOnComponents()
    {
        charCont.enabled = true;
        charController.enabled = true;
        playerL.enabled = true;
        UI.SetActive(true);
        Pauser.enabled = true;
        charController.SoundOn = true;
    }
}
