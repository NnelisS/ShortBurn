using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawn : MonoBehaviour
{
    [Header("Clone Info")]
    [SerializeField] private int maxClones = 1;
    [SerializeField] private int currentClones;
    [SerializeField] private GameObject clonePrefab;

    void Update()
    {
        if (currentClones < maxClones)
            if (Input.GetKeyDown(KeyCode.C))
                MakeClone(clonePrefab);
    }

    private void MakeClone(GameObject clone)
    {
        Instantiate(clone, transform.position, transform.rotation);
    }
}
