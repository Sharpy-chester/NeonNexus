using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;
    internal bool canJump = true;
    [SerializeField] float jumpForce;
    [SerializeField] float groundedDist = 1.1f;

    public delegate void OnGrounded();
    public event OnGrounded onGrounded;

    bool grounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Grounded check for events
        if (Grounded())
        {
            if (!grounded)
            {
                grounded = true;
                onGrounded?.Invoke();
            }
        }
        else
        {
            if (grounded)
            {
                grounded = false;
            }
        }

        //Jump
        if (Input.GetButtonDown("Jump") && grounded && canJump)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    public bool Grounded()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, groundedDist))
        {
            return true;
        }
        else
        {
            return false;
        } 
    }
}
