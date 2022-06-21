using System.Collections;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [HideInInspector] public Transform CheckPoint;

    [SerializeField] private CharacterController characterCont;
    private UnityEngine.CharacterController characterController;

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
        characterController = FindObjectOfType<UnityEngine.CharacterController>();
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
        CheckPoint = _checkPointPos;
    }

    private IEnumerator RespawnAtCheckPoint(Transform _OldPos)
    {
        kill = true;
        playerL.enabled = false;
        cam.transform.localRotation = Quaternion.Euler(0, transform.localRotation.y, transform.localRotation.z);
        dialogue.PlayRandomDialogue();
        characterCont.enabled = false;
        characterController.enabled = false;
        fade.Play("Eyes");
        yield return new WaitForSeconds(2);
        kill = false;
        cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
        player.transform.position = CheckPoint.position;
        cam.position = _OldPos.position;
        yield return new WaitForSeconds(1);
        playerL.enabled = true;
        characterCont.enabled = true;
        characterController.enabled = true;
    }
}
