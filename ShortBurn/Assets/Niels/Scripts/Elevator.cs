using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Elevator : MonoBehaviour
{
    public GameObject player;
    public Transform ElevatorPos;

    public UnityEngine.CharacterController CharacterCont;

    private Animator elevatorAnim;

    private CinemachineVirtualCamera vCam;

    private void Start()
    {
        vCam = FindObjectOfType<CinemachineVirtualCamera>();
        elevatorAnim = GetComponentInChildren<Animator>();
    }

    public IEnumerator ElevatorChange()
    {
        elevatorAnim.Play("ElevatorClose");
        yield return new WaitForSeconds(2);
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 10;
        CharacterCont.enabled = false;
        player.transform.SetParent(this.transform);
        yield return new WaitForSeconds(0.01f);
        if (ElevatorPos != null)
            transform.position = ElevatorPos.position;
        yield return new WaitForSeconds(0.01f);
        player.transform.SetParent(null);
        CharacterCont.enabled = true;
        yield return new WaitForSeconds(5);
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1;
        yield return new WaitForSeconds(1);
        elevatorAnim.Play("ElevatorOpen");
    }
}
