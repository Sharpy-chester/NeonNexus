using UnityEngine;
using Player;

namespace Items
{
    [CreateAssetMenu(fileName = "DoubleJump", menuName = "Items/Double Jump", order = 1)]
    public class DoubleJump : Item
    {
        PlayerJump jump;
        Rigidbody rb;
        PlayerWallRun wallRun;
        [SerializeField] float jumpForce;
        bool hasDoubleJumped = false;
        GameObject player;

        void StartDoubleJump()
        {
            if (Input.GetButtonDown("Jump") && !jump.Grounded() && jump.hasJumped && !hasDoubleJumped && !wallRun.isWallRunning)
            {
                hasDoubleJumped = true;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        void ResetDoubleJump()
        {
            hasDoubleJumped = false;
        }

        public override void OnUpdate()
        {
            StartDoubleJump();
        }

        public override void OnAdd(GameObject playerGO)
        {
            player = playerGO;
            rb = player.GetComponent<Rigidbody>();
            wallRun = player.GetComponent<PlayerWallRun>();
            jump = player.GetComponent<PlayerJump>();
            jump.onGrounded += ResetDoubleJump;
        }

        public override void OnCollision(Collision collision) { }
}

}
