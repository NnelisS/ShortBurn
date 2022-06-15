using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BridgePuzzle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isDoor = false;

    public Transform Bridge;
    public Transform GoTo;
    public Transform GoToBack;
    public bool ClonePuzzle = false;

    [SerializeField] private float timer = 2;
    private CinemachineVirtualCamera vCam;

    private bool activated = false;

    private void Start()
    {
        vCam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (activated)
        {
            if (timer > 0.1f && ClonePuzzle == true)
            {
                vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 2f;
                vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 25f;
            }
            if (isDoor && Bridge.transform.localPosition != GoTo.transform.localPosition)
                AudioManager.instance.Play("Big Door");
            
            Bridge.transform.localPosition = Vector3.MoveTowards(Bridge.transform.localPosition, GoTo.transform.localPosition, speed * Time.deltaTime);

            timer -= Time.deltaTime;
            if (timer <= 0 && ClonePuzzle == true)
            {
                timer = 0;
                vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0.7f;
                vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0.5f;
            }
        }
        else
            Bridge.transform.localPosition = Vector3.MoveTowards(Bridge.transform.localPosition, GoToBack.transform.localPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone"))
            AudioManager.instance.Play("Pressure plate");
    }

    private void OnTriggerStay(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone"))
            activated = true;
    }

    private void OnTriggerExit(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone"))
            activated = false;
    }
}
