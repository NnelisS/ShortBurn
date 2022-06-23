using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    public VideoPlayer VidStart;
    public GameObject screen;

    public Material White;

    private void Start()
    {
        VidStart.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            VidStart.enabled = true;
            screen.GetComponent<MeshRenderer>().material = White;
        }
    }
}
