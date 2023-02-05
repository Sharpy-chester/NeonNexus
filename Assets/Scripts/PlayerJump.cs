using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;
    PlayerWallRun wallRun;
    internal bool canJump = true;
    internal bool hasJumped = false;
    [SerializeField] float jumpForce;
    [SerializeField] float wallRunJumpForce;
    [SerializeField] float groundedDist = 1.1f;

    public delegate void OnGrounded();
    public event OnGrounded onGrounded;

    bool grounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wallRun = GetComponent<PlayerWallRun>();
    }

    void Update()
    {
        //Grounded check for events
        if (Grounded())
        {
            if (!grounded)
            {
                grounded = true;
                hasJumped = false;
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

        if(Input.GetButtonDown("Jump") && canJump)
        {
            if(wallRun && wallRun.isWallRunning && !grounded) //wall run jump
            {
                switch (wallRun.wallRunDir)
                {
                    case PlayerWallRun.WallRunDirection.left:
                        rb.AddRelativeForce(new Vector3(wallRunJumpForce, jumpForce, 0), ForceMode.Impulse);
                        break;
                    case PlayerWallRun.WallRunDirection.right:
                        rb.AddRelativeForce(new Vector3(-wallRunJumpForce, jumpForce, 0), ForceMode.Impulse);
                        break;
                    case PlayerWallRun.WallRunDirection.none:
                        break;
                    default:
                        break;
                }
                wallRun.EndWallRun();
            }
            else if (grounded) //Normal Jump
            {
                hasJumped = true;
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
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
