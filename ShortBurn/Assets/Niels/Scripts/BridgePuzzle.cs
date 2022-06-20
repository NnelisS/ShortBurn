using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BridgePuzzle : MonoBehaviour
{
    public Transform Bridge;
    public Transform GoTo;
    public Transform GoToBack;

    public bool activated = false;
    public bool activateMusic = false;

    public AudioSource Ending;

    private void Update()
    {
        if (activated)
            Bridge.transform.localPosition = Vector3.MoveTowards(Bridge.transform.localPosition, GoTo.transform.localPosition, 0.3f * Time.deltaTime);

        if (activateMusic)
        {
            Ending.Play(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Clone"))
        {
            activated = true;
            Ending.Play(0);
        }
    }
}
