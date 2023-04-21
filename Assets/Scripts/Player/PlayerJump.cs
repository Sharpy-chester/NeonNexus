using UnityEngine;

namespace Player
{
    public class PlayerJump : MonoBehaviour
    {
        Rigidbody rb;
        PlayerWallRun wallRun;
        public bool canJump = true;
        public bool hasJumped = false;
        public float jumpForce;
        [SerializeField] float wallRunJumpForce;
        [SerializeField] float groundedDist = 1.1f;

        public delegate void OnGrounded();
        public event OnGrounded onGrounded;

        public delegate void OnNotGrounded();
        public event OnNotGrounded onNotGrounded;

        bool grounded = true;
        [SerializeField] float playerGroundedWidth = 0.5f;

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
                    onNotGrounded?.Invoke();
                }
            }

            if (Input.GetButtonDown("Jump") && canJump)
            {
                if (wallRun && wallRun.isWallRunning && !grounded) //wall run jump
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
            if (Physics.Raycast(transform.position, -transform.up, out _, groundedDist) || 
                Physics.Raycast(transform.position + new Vector3(playerGroundedWidth, 0, 0), -transform.up, out _, groundedDist) ||
                Physics.Raycast(transform.position + new Vector3(-playerGroundedWidth, 0, 0), -transform.up, out _, groundedDist) ||
                Physics.Raycast(transform.position + new Vector3(0, 0, playerGroundedWidth), -transform.up, out _, groundedDist) ||
                Physics.Raycast(transform.position + new Vector3(0, 0, -playerGroundedWidth), -transform.up, out _, groundedDist))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void IncreaseJumpForce(float amt)
        {
            jumpForce += amt;
        }
    }
}
