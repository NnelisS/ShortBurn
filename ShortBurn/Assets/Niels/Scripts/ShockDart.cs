using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockDart : MonoBehaviour
{
    [Header("Gun Settings")]
    public float BulletSpeed;
    public float Cooldown;

    [Header("Gun Info")]
    public GameObject BulletPref;
    public Transform ShootPoint;

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(BulletPref, ShootPoint.position, ShootPoint.rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(ShootPoint.transform.up * BulletSpeed);
            StartCoroutine(BulletShoot(Bullet));
        }
    }

    // shoot bullet and ignore player collision
    private IEnumerator BulletShoot(GameObject bullet)
    {
        Physics.IgnoreCollision(bullet.GetComponent<CapsuleCollider>(), GetComponentInParent<CapsuleCollider>());
        yield return new WaitForSeconds(10f);
        Destroy(bullet);
    }
}
