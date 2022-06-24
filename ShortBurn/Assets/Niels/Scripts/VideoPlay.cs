using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    public VideoPlayer VidStart;
    public GameObject screen;

    public Material White;

    public GameObject Recordin;
    public GameObject CloneSpawn;

    private void Start()
    {
        VidStart.enabled = false;

        if (Recordin != isActiveAndEnabled && CloneSpawn != isActiveAndEnabled)
        {
            Recordin.SetActive(false);
            CloneSpawn.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            VidStart.enabled = true;
            screen.GetComponent<MeshRenderer>().material = White;

            if (Recordin != isActiveAndEnabled && CloneSpawn != isActiveAndEnabled)
            {
                Recordin.SetActive(true);
                CloneSpawn.SetActive(true);
            }
        }
    }
}
