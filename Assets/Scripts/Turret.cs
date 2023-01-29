using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] int bulletDamage;
    [SerializeField] float bulletForce;
    [SerializeField] float bulletCooldown;
    [SerializeField] float range;
    bool canSeePlayer = false;
    float currentCooldown = 0.0f;
    Vector3 dirToPlayer;

    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        if(!player)
        {
            return;
        }
        dirToPlayer = (player.transform.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, player.transform.position) < range && Physics.Raycast(transform.position, dirToPlayer, out RaycastHit hit))
        {
            if(hit.transform.gameObject == player)
            {
                canSeePlayer = true;
                transform.LookAt(player.transform);
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else
        {
            canSeePlayer = false;
        }

        currentCooldown += Time.deltaTime;
        if(currentCooldown > bulletCooldown && canSeePlayer)
        {
            currentCooldown = 0.0f;
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint);
        bullet.transform.parent = null;
        Bullet b = bullet.GetComponent<Bullet>();
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if(b && rb)
        {
            b.bulletDamage = bulletDamage;
            rb.AddForce(bullet.transform.forward * bulletForce, ForceMode.Impulse);
        }
        
    }
}
