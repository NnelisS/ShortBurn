using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CloneTutorialPuzzle : MonoBehaviour
{
    public Transform Bridge;
    public Transform GoTo;
    public Transform GoToBack;
    public bool ClonePuzzle = false;

    private float timer = 2;
    private CinemachineVirtualCamera vCam;

    public bool Activated = false;

    private void Start()
    {
        vCam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (Activated)
        {
            timer -= Time.deltaTime;
            if (timer > 0.1f && ClonePuzzle == true)
            {
                vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 2;
                vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 25;
            }

            Bridge.transform.localPosition = Vector3.MoveTowards(Bridge.transform.localPosition, GoTo.transform.localPosition, 1 * Time.deltaTime);


            if (timer <= 0 && ClonePuzzle == true)
            {
                timer = 0;
                vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0.7f;
                vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0.5f;
            }
        }
        else if (Activated == false)
        {
            vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0.7f;
            vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0.5f;

            timer = 2;
            Bridge.transform.localPosition = Vector3.MoveTowards(Bridge.transform.localPosition, GoToBack.transform.localPosition, 1 * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Clone"))
            Activated = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone"))
            Activated = false;
    }
}
