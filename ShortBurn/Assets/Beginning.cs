using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beginning : MonoBehaviour
{
    public GameObject UI;
    public Pause Pauser;
    public Transform camRot;

    private UnityEngine.CharacterController charCont;
    private CharacterController charController;
    private PlayerLook playerL;

    public bool on = false;

    void Start()
    {
        UI.SetActive(false);
        Pauser.enabled = false;
        charCont = FindObjectOfType<UnityEngine.CharacterController>();
        charController = FindObjectOfType<CharacterController>();
        playerL = FindObjectOfType<PlayerLook>();
    }

    void Update()
    {
        if (on == false)
        {
            charCont.enabled = false;
            charController.enabled = false;
            playerL.enabled = false;
        }
        else
        {
            camRot.rotation = Quaternion.Euler(0, 0, 0);
            charCont.enabled = true;
            charController.enabled = true;
            playerL.enabled = true;
            UI.SetActive(true);
            Pauser.enabled = true;
        }
    }
}
