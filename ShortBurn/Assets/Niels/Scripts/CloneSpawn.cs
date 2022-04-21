using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawn : MonoBehaviour
{
    [Header("Clone Info")]
    public int maxClones = 1;
    public int currentClones;
    public GameObject clonePrefab;

    void Update()
    {
        if (currentClones < maxClones)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                MakeClone(clonePrefab);
            }
        }
    }

    private void MakeClone(GameObject clone)
    {
        Instantiate(clone, transform.position, transform.rotation);
    }
}
