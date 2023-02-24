using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//to fix perf, disable enemies when theyre far away

public class RangerEnemy : Enemy
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] int bulletDamage;
    [SerializeField] float bulletForce;
    [SerializeField] float fireRate = 1;
    float currentCooldown = 0;

    void Start()
    {
        InitVariables();
        navAgent = gameObject.AddComponent<NavMeshAgent>();
        navAgent.speed = moveSpeed;
        navAgent.acceleration = acceleration;
    }

    void Update()
    {
        currentCooldown += Time.deltaTime;
        if (!player)
        {
            return;
        }
        Ray ray = new(eyeTransform.position, DirToPlayer());        
        if (Physics.Raycast(ray, out RaycastHit hit, seeRange))
        {
            
            if (hit.transform.CompareTag("Player"))
            {
                

                canSeePlayer = true;
                if (DistToPlayer() < attackRange)
                {
                    if (currentCooldown > fireRate)
                    {
                        AttackPlayer();
                        currentCooldown = 0;
                    }
                }
                else
                {
                    RunTowardPlayer();
                }
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
    }

    void RunTowardPlayer()
    {
        navAgent.isStopped = false;
        currentState = PlayerState.Running;
        navAgent.SetDestination(player.transform.position);
        animator.SetTrigger("Run");
    }

    void AttackPlayer()
    {
        currentState = PlayerState.Attacking;
        transform.LookAt(player.transform, Vector3.up);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        animator.SetTrigger("Attack");
        navAgent.isStopped = true;
        ShootBullet();
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint);
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
