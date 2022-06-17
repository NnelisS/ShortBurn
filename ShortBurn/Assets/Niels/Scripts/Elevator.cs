using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Elevator : MonoBehaviour
{
    public GameObject player;
    public Transform ElevatorPos;

    private UnityEngine.CharacterController characterCont;

    private Animator elevatorAnim;

    private CinemachineVirtualCamera vCam;

    private void Start()
    {
        vCam = FindObjectOfType<CinemachineVirtualCamera>();
        characterCont = FindObjectOfType<UnityEngine.CharacterController>();
        elevatorAnim = GetComponentInChildren<Animator>();
    }

    public IEnumerator ElevatorChange()
    {
        //Close Door
        elevatorAnim.Play("ElevatorClose");
        yield return new WaitForSeconds(2);
        //Play Music
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 6;
        characterCont.enabled = false;
        player.transform.SetParent(this.transform);
        yield return new WaitForSeconds(0.01f);
        if (ElevatorPos != null)
        {
            transform.position = ElevatorPos.position;
            transform.rotation = ElevatorPos.rotation;
        }
        yield return new WaitForSeconds(0.01f);
        player.transform.SetParent(null);
        characterCont.enabled = true;
        yield return new WaitForSeconds(10);
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1;
        yield return new WaitForSeconds(1);
        //OpenDoor
        elevatorAnim.Play("ElevatorOpen");
    }
}
