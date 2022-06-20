using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPointManager checkPointManager;
    [SerializeField] private Transform spawnPos;

    private void Start()
    {
        checkPointManager = FindObjectOfType<CheckPointManager>();
    }

    private void Update()
    {
        if (checkPointManager.CheckPoint != this.spawnPos)
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
