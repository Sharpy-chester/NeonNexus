using UnityEngine;
using Player;

namespace Items
{
    [CreateAssetMenu(fileName = "Fire Rate Increase", menuName = "Items/Fire Rate Increase", order = 2)]
    public class FireRateIncrease : Item
    {
        [SerializeField] float fireRateIncrease = 0.1f;

        public override void OnAdd(GameObject playerGO)
        {
            playerGO.GetComponent<PlayerShoot>().IncreaseFireRate(fireRateIncrease);
        }

        public override void OnCollision(Collision collision)
        {

        }

        public override void OnUpdate()
        {

        }
    }
}

