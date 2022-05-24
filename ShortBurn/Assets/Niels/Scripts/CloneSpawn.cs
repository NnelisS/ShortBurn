using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawn : MonoBehaviour
{
    private GameObject clone;

    public void MakeClone(GameObject _clone)
    {
        clone = Instantiate(_clone, transform.position, transform.rotation);
        GetComponent<ActorObject>().NewController = clone.GetComponent<CharacterController>();

        InitializeClone();
    }

    private void InitializeClone()
    {
        clone.GetComponent<MeshRenderer>().enabled = false;
    }

    public GameObject SetClone()
    {
        return clone;
    }

    public void ResetClone()
    {
        clone.gameObject.SetActive(false);

        //doesnt look good yet
        clone.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        clone.transform.rotation = transform.rotation;

        clone.gameObject.SetActive(true);
    }
}
