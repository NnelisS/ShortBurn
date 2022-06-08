using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CheckPointManager : MonoBehaviour
{
    public Transform checkPoint;

    [SerializeField] private CharacterController characterCont;
    [SerializeField] private UnityEngine.CharacterController characterController;

    [SerializeField] private PlayerLook playerL;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator fade;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform oldCam;
    [SerializeField] private DialogueSystem dialogue;

    private bool kill = false;

    private void Start()
    {
        cam.transform.localRotation = Quaternion.Euler(90, transform.localRotation.y, transform.localRotation.z);
    }
    private void Update()
    {
        if (kill)
            cam.position = Vector3.Lerp(cam.position, new Vector3(cam.position.x, cam.position.y + 5, cam.position.z), 0.3f * Time.deltaTime);
    }

    public void Respawn()
    {
        StartCoroutine(RespawnAtCheckPoint(oldCam));
    }

    public void AddCheckPoint(Transform _checkPointPos)
    {
        checkPoint = _checkPointPos;
    }

    private IEnumerator RespawnAtCheckPoint(Transform _OldPos)
    {
        Debug.Log("Co ON");
        kill = true;
        playerL.ChangeMovement();
        cam.transform.localRotation = Quaternion.Euler(90, transform.localRotation.y, transform.localRotation.z);
        dialogue.PlayRandomDialogue();
        characterCont.enabled = false;
        characterController.enabled = false;
        fade.Play("Eyes");
        yield return new WaitForSeconds(1);
        kill = false;
        cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
        playerL.ChangeMovement();
        player.transform.position = checkPoint.position;
        cam.position = _OldPos.position;
        yield return new WaitForSeconds(1);
        characterCont.enabled = true;
        characterController.enabled = true;
    }
}
