using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject player;

    public float MoveUpValue;
    public float waitTime;

    private void OnMouseDown()
    {
        StartCoroutine(Teleport());
    }

    private IEnumerator Teleport()
    {
        player.GetComponent<UnityEngine.CharacterController>().enabled = false;

        yield return new WaitForSeconds(waitTime);

        player.transform.position = new Vector3(player.transform.position.x, MoveUpValue, player.transform.position.z);
        player.GetComponent<UnityEngine.CharacterController>().enabled = true;
    }
}
