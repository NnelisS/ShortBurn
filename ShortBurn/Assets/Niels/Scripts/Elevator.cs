using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject player;
    public Transform ElevatorPos;

    public UnityEngine.CharacterController CharacterCont;

    public bool ElevatorUse = false;

    private void Update()
    {
        if (ElevatorUse)
            StartCoroutine(ElevatorChange());
    }

    private IEnumerator ElevatorChange()
    {
        CharacterCont.enabled = false;
        player.transform.SetParent(this.transform);
        yield return new WaitForSeconds(0.01f);
        transform.position = ElevatorPos.position;
        yield return new WaitForSeconds(0.01f);
        player.transform.SetParent(null);
        CharacterCont.enabled = true;
    }
}
