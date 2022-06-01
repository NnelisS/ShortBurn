using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public bool BatteryIn = false;
    public BoxCollider childCol;
    private Pickup pickup;

    public Transform[] AnimationCell;

    private bool one = false;
    private bool two = false;
    private bool three = false;

    private void Start()
    {
        pickup = FindObjectOfType<Pickup>();
    }

    private void Update()
    {
        if (one)
        {
            transform.position = Vector3.MoveTowards(transform.position, AnimationCell[0].transform.position, 1 * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, AnimationCell[0].transform.rotation, 2 * Time.deltaTime);
        }
        if (two)
        {
            transform.position = Vector3.MoveTowards(transform.position, AnimationCell[1].transform.position, 1 * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, AnimationCell[1].transform.rotation, 2 * Time.deltaTime);
        }
        if (three)
        {
            transform.position = Vector3.MoveTowards(transform.position, AnimationCell[2].transform.position, 1 * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, AnimationCell[2].transform.rotation, 2 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BatteryHolder"))
        {
            pickup.RotateEnabled = false;
            pickup.DropObj();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            GetComponent<MeshCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;

            if (childCol != null)
                childCol.enabled = false;

            StartCoroutine(BatteryInCell());
        }
    }

    private IEnumerator BatteryInCell()
    {
        one = true;
        yield return new WaitForSeconds(1);
        one = false;
        two = true;
        yield return new WaitForSeconds(1);
        two = false;
        three = true;
        yield return new WaitForSeconds(1);
        BatteryIn = true;
    }
}
