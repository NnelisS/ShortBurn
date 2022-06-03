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

        for (int i = 0; i < clone.transform.childCount; i++)
        {
            clone.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public GameObject SetClone()
    {
        return clone;
    }

    public void ResetClone()
    {
        clone.gameObject.SetActive(false);

        clone.transform.position = transform.position;
        clone.transform.rotation = transform.rotation;

        clone.gameObject.SetActive(true);
    }
}
