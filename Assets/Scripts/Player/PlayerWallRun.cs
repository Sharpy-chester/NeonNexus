using UnityEngine;

namespace Player
{
    public class PlayerWallRun : MonoBehaviour
    {
        Rigidbody rb;
        PlayerMovement movement;
        public bool isWallRunning = false;
        [SerializeField] float wallRunDist;
        [Range(0, 1)]
        [SerializeField] float wallRunGravity = 0.1f;

        internal WallRunDirection wallRunDir = WallRunDirection.none;

        internal enum WallRunDirection
        {
            left,
            right,
            none
        }


        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            movement = GetComponent<PlayerMovement>();
        }

        void Update()
        {
            CheckWallRun();
        
        }

        void FixedUpdate()
        {
            if (isWallRunning)
            {
                UpdateWallRun();
            }
        }

        void CheckWallRun()
        {
            Debug.DrawLine(transform.position, transform.position + -transform.right * wallRunDist, Color.green);
            Debug.DrawLine(transform.position, transform.position + transform.right * wallRunDist, Color.green);
            if (Physics.Raycast(transform.position, -transform.right, out RaycastHit leftHit, wallRunDist))
            {
                wallRunDir = WallRunDirection.left;
                StartWallRun();
            }
            else if (Physics.Raycast(transform.position, transform.right, out RaycastHit rightHit, wallRunDist))
            {
                wallRunDir = WallRunDirection.right;
                StartWallRun();
            }
            else if (isWallRunning)
            {
                EndWallRun();
            }
        }

        void StartWallRun()
        {
            isWallRunning = true;
            rb.useGravity = false;
        }

        void UpdateWallRun()
        {
            rb.AddForce(transform.up * (Physics.gravity.y * wallRunGravity), ForceMode.Acceleration);
        }

        public void EndWallRun()
        {
            isWallRunning = false;
            rb.useGravity = true;
            wallRunDir = WallRunDirection.none;
        }
    }
}

