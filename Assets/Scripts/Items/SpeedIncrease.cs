using UnityEngine;
using Player;

namespace Items
{
    [CreateAssetMenu(fileName = "Speed Increase", menuName = "Items/Speed Increase", order = 5)]
    public class SpeedIncrease : Item
    {
        [SerializeField] float speedIncrease;

        public override void OnAdd(GameObject playerGO)
        {
            playerGO.GetComponent<PlayerMovement>().IncreaseSpeed(speedIncrease);
        }

        public override void OnCollision(Collision collision)
        {
        }

        public override void OnUpdate()
        {
        }
    }
}
