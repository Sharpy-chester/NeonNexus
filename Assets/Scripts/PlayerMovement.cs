using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    PlayerJump jump;

    [Tooltip("Normal speed the player runs at")]
    [SerializeField] float runSpeed = 10.0f;
    [Range(1, 10)]
    [SerializeField] float runDrag = 6.0f;
    [Range(0.1f, 1)]
    [SerializeField] float airDrag = 0.0f;
    [SerializeField] float airSpeed = 0.3f;

    Vector3 direction;
    float speed;
    internal bool canRun = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        speed = runSpeed;
        jump = GetComponent<PlayerJump>();
    }

    void Update()
    {
        if (canRun)
        {
            FindMoveDir();
        }
        else
        {
            direction = Vector3.zero;
        }

        if (jump)
        {
            rb.drag = jump.Grounded() ? runDrag : airDrag;
            speed = jump.Grounded() ? runSpeed : airSpeed;
        }
    }

    void FindMoveDir()
    {
        //Find the move direction by getting inputs
        direction = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        //Physics updates in fixed update so doing it in here makes it smoother
        //Normalised the direction so that it has a magnatude of 1. Otherwise, if the player is going 
        //diagonal, they go faster than the move speed
        rb.AddForce(direction.normalized * speed, ForceMode.Acceleration);
    }
}
