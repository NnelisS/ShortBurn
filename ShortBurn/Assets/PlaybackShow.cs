using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackShow : MonoBehaviour
{
    public GameObject PlayBack;

    void Start()
    {
        PlayBack.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            PlayBack.SetActive(true);
    }
}
