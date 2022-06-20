using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beginning : MonoBehaviour
{    
    public bool On = false;
    public bool IsFinnished = false;

    public GameObject UI;
    public Pause Pauser;
    public Transform CamRot;

    private UnityEngine.CharacterController charCont;
    private CharacterController charController;
    private PlayerLook playerL;


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
        if (IsFinnished)
        {
            CamRot.rotation = Quaternion.Euler(0, 0, 0);
            charCont.enabled = true;
            charController.enabled = true;
            playerL.enabled = true;
            UI.SetActive(true);
            Pauser.enabled = true;
            IsFinnished = true;
        }
        else if (On == false)
        {
            charCont.enabled = false;
            charController.enabled = false;
            playerL.enabled = false;
        }
       
    }
}
