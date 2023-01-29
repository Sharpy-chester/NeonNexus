using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce;
    [SerializeField] int bulletDamage;
    [SerializeField] Transform fireTransform;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, fireTransform);
            bullet.transform.parent = null;
            Bullet b = bullet.GetComponent<Bullet>();
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (b && rb)
            {
                b.bulletDamage = bulletDamage;
                rb.AddForce(bullet.transform.forward * bulletForce, ForceMode.Impulse);
            }
        }

    }
}
