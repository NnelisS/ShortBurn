using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawn : MonoBehaviour
{
    private GameObject clone;

    public void MakeClone(GameObject _clone, GameObject _player)
    {
        clone = Instantiate(_clone, transform.position, transform.rotation);
        GetComponent<ActorObject>().NewController = clone.GetComponent<CharacterController>();

        InitializeClone(_player);
    }

    private void InitializeClone(GameObject _player)
    {
        clone.GetComponent<MeshRenderer>().enabled = false;
        clone.GetComponent<CharacterController>().Player = _player;
    }

    public GameObject SetClone()
    {
        return clone;
    }

    public void ResetClone()
    {
        clone.gameObject.SetActive(false);

        clone.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        clone.transform.rotation = transform.rotation;

        clone.gameObject.SetActive(true);
    }
}
