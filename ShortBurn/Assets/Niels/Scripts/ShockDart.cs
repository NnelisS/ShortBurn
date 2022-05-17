using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockDart : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float cooldown;

    [Header("Gun Info")]
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private Transform shootPoint;

    void Update()
    {
        Shoot();
    }

    /// <summary>
    /// shoots shock bullet forward
    /// /// </summary>
    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(bulletPref, shootPoint.position, shootPoint.rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(shootPoint.transform.up * bulletSpeed);
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
