using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class RangerEnemy : Enemy
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] Transform bulletSpawnPoint;
        [SerializeField] int bulletDamage;
        [SerializeField] float bulletForce;
        [SerializeField] float fireRate = 1;
        float currentCooldown = 0;
        int shootLayerMask;

        void Start()
        {
            InitVariables();
            shootLayerMask = ~(1 << LayerMask.NameToLayer("Bullet") | 1 << LayerMask.NameToLayer("Enemy"));
            navAgent = gameObject.AddComponent<NavMeshAgent>();
            navAgent.speed = moveSpeed;
            navAgent.acceleration = acceleration;
            Idle();
        }

        /*void OnEnable()
        {
            Idle();
            canSeePlayer = false;
        }*/

        void Update()
        {
        
            if (!player || !alive)
            {
                return;
            }
            Ray ray = new(eyeTransform.position, DirToPlayer());        
            if (Physics.Raycast(ray, out RaycastHit hit, seeRange, shootLayerMask))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    canSeePlayer = true;
                    if (DistToPlayer() < attackRange)
                    {
                        transform.LookAt(player.transform, Vector3.up);
                        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                        currentCooldown += Time.deltaTime;
                        if (currentCooldown > fireRate)
                        {
                            AttackPlayer();
                            currentCooldown = 0;
                        }
                    }
                    else if (DistToPlayer() < seeRange)
                    {
                        currentCooldown = 0;
                        RunTowardPlayer();
                    }
                    else
                    {
                        Idle();
                        canSeePlayer = false;
                    }
                }
                else
                {
                    Idle();
                    canSeePlayer = false;
                }
            }
            else
            {
                Idle();
                canSeePlayer = false;
            }
        }

        void RunTowardPlayer()
        {
            navAgent.isStopped = false;
            currentState = PlayerState.Running;
            animator.SetTrigger("Run");
            navAgent.SetDestination(player.transform.position);
        }

        void AttackPlayer()
        {
            currentState = PlayerState.Attacking;
            animator.SetTrigger("Attack");
            navAgent.isStopped = true;
            ShootBullet();
        }

        void Idle()
        {
            currentState = PlayerState.Idle;
            if (navAgent)
            {
                navAgent.isStopped = true;
            }
            if(animator)
            {
                animator.SetTrigger("Idle");
            }
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
                b.transform.LookAt(player.transform);
                rb.AddForce(bullet.transform.forward * bulletForce, ForceMode.Impulse);
            }
        }
    }
}

