using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameObject UI;
    public Pause Pauser;
    public Animator anim;
    public GameObject player;
    public GameObject Cam;

    private UnityEngine.CharacterController charCont;
    private CharacterController charController;
    private PlayerLook playerL;

    public bool on = false;

    private float time = 34;

    private void Start()
    {
        charCont = FindObjectOfType<UnityEngine.CharacterController>();
        charController = FindObjectOfType<CharacterController>();
        playerL = FindObjectOfType<PlayerLook>();
    }

    private void Update()
    {
        if (on)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
            }

            charCont.enabled = false;
            charController.enabled = false;
            playerL.enabled = false;
            Cam.SetActive(true);
            player.SetActive(false);
            anim.enabled = true;
            UI.SetActive(false);
            Pauser.enabled = false;
            charController.SoundOn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            on = true;
        }
    }
}
