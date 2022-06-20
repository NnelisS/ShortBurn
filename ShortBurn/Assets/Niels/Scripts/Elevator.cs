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

    CinemachineVirtualCamera vCam;

    private void Start()
    {
        vCam = FindObjectOfType<PlayerRecorder>().gameObject.GetComponentInChildren<CinemachineVirtualCamera>();
        characterCont = FindObjectOfType<UnityEngine.CharacterController>();
        elevatorAnim = GetComponentInChildren<Animator>();
    }

    public IEnumerator ElevatorChange()
    {
        AudioManager.instance.Play("ElevatorOpen");
        elevatorAnim.Play("ElevatorClose");
        yield return new WaitForSeconds(2);
        AudioManager.instance.Play("ElevatorMusic");
<<<<<<< HEAD
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 6;
=======
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 8;
>>>>>>> main
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
        AudioManager.instance.Play("ElevatorEnd");
        elevatorAnim.Play("ElevatorOpen");
    }
}
