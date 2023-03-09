using UnityEngine;
using UnityEngine.AI;
using Enemies;

public abstract class Enemy : MonoBehaviour
{

    public float seeRange;
    public float attackRange;
    public float moveSpeed;
    public float acceleration;
    public int moneyGiven = 25;
    public Transform eyeTransform;
    public Transform head;
    internal int layerMask;
    internal bool canSeePlayer = false;
    internal bool alive = true;
    Health health;

    internal GameObject player;
    internal NavMeshAgent navAgent;
    internal Animator animator;
    internal Vector3 pos;

    public enum PlayerState
    {
        Idle,
        Running,
        Attacking
    }

    public PlayerState currentState = PlayerState.Idle;

    public void InitVariables()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        layerMask = 1 << (LayerMask.NameToLayer("Player")); //Filter out enemy layer
        animator = GetComponent<Animator>();
        EnemyManager.Instance.AddEnemy(this);
        health = GetComponent<Health>();
        health.onDeath += Die;
    }

    public float DistToPlayer()
    {
        return gameObject.activeSelf ? Vector3.Distance(player.transform.position, transform.position) : Vector3.Distance(player.transform.position, pos);
    }

    public Vector3 DirToPlayer()
    {
        return (player.transform.position - eyeTransform.position).normalized;
    }

    public void Die()
    {
        FindObjectOfType<GameManager>().AddMoney(moneyGiven);
        alive = false;
        EnemyManager.Instance.enemies.Remove(this);
        animator.SetTrigger("Die");
        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<Rigidbody>());
        navAgent.isStopped = true;
        Destroy(gameObject, 5f);
    }

    private void OnDisable()
    {
        pos = transform.position;
    }
}
