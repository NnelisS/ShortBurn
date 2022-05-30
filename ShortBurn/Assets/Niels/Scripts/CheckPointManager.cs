using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CheckPointManager : MonoBehaviour
{
    public Transform checkPoint;

    [SerializeField] private CharacterController characterCont;
    [SerializeField] private UnityEngine.CharacterController characterController;

    [SerializeField] private GameObject player;
    [SerializeField] private Animator fade;
    [SerializeField] private Transform cam;
    [SerializeField] private CinemachineVirtualCamera vCam;
    [SerializeField] private Transform camPos;

    private bool kill = false;

    private void Update()
    {
        if (kill)
        {
            vCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value = 90;
            vCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = 0;
            cam.position = Vector3.Lerp(cam.position, new Vector3(cam.position.x, cam.position.y + 5, cam.position.z), 0.3f * Time.deltaTime);
        }
    }

    public void Respawn()
    {
        StartCoroutine(RespawnAtCheckPoint(camPos));
    }

    public void AddCheckPoint(Transform _checkPointPos)
    {
        checkPoint = _checkPointPos;
    }

    private IEnumerator RespawnAtCheckPoint(Transform _oldPos)
    {
        kill = true;
        characterCont.enabled = false;
        characterController.enabled = false;
        fade.Play("Eyes");
        yield return new WaitForSeconds(1);
        kill = false;
        cam.position = _oldPos.position;
        vCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value = 0;
        player.transform.position = checkPoint.position;
        yield return new WaitForSeconds(1);
        characterCont.enabled = true;
        characterController.enabled = true;
    }
}
