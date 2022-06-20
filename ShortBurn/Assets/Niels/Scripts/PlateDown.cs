using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateDown : MonoBehaviour
{
    private Vector3 upPos;
    private Vector3 downPos;

    public bool On = false;

    void Start()
    {
        upPos = transform.position;
        downPos = transform.position -= new Vector3(0, 0.1f, 0);
    }

    void Update()
    {
        if (On)
            transform.position = Vector3.Lerp(transform.position, downPos, 1 * Time.deltaTime);
        else if (On == false)
            transform.position = Vector3.Lerp(transform.position, upPos, 1 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EffectManager.instance.ScreenShake(1.3f, 4f, .5f);
            AudioManager.instance.Play("PressurePlate");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
        {
            AudioManager.instance.Play("PressurePlate");
            On = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Clone") || other.gameObject.CompareTag("CubeNormal"))
            On = false;
    }
}
