using UnityEngine;

public class Laser : MonoBehaviour
{
    public Controller cont;

    private void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.CompareTag("Clone") && cont.clone.activeInHierarchy)
        {
            cont.DestroyClone();
        }
    }
}
