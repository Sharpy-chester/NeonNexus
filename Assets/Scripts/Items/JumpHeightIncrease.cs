using UnityEngine;
using Player;

namespace Items
{
    [CreateAssetMenu(fileName = "Jump Height Increase", menuName = "Items/Jump Height Increase", order = 6)]
    public class JumpHeightIncrease : Item
    {
        [SerializeField] float jumpForceIncrease;

        public override void OnAdd(GameObject playerGO)
        {
            playerGO.GetComponent<PlayerJump>().IncreaseJumpForce(jumpForceIncrease);
        }

        public override void OnCollision(Collision collision)
        {
        }

        public override void OnUpdate()
        {
        }
    }
}

