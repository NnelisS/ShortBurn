using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPointManager checkPointManager;
    public Transform spawnPos;

    private void Start()
    {
        spawnPos = GetComponentInChildren<Transform>();
        checkPointManager = FindObjectOfType<CheckPointManager>();
    }

    private void Update()
    {
        if (checkPointManager.spawnPoint != this.spawnPos)
            GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkPointManager.AddCheckPoint(spawnPos);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
