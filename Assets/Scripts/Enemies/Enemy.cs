using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{

    public float seeRange;
    public float attackRange;
    public float moveSpeed;
    public float acceleration;
    public Transform eyeTransform;
    internal int layerMask;
    internal bool canSeePlayer = false;

    internal GameObject player;
    internal NavMeshAgent navAgent;
    internal Animator animator;

    public enum PlayerState
    {
        Idle,
        Running,
        Attacking
    }

    public PlayerState currentState = PlayerState.Idle;

    public void InitVariables()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        layerMask = 1 << (LayerMask.NameToLayer("Player")); //Filter out enemy layer
        animator = GetComponent<Animator>();
    }

    public float DistToPlayer()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }

    public Vector3 DirToPlayer()
    {
        return (player.transform.position - eyeTransform.position).normalized;
    }
}
