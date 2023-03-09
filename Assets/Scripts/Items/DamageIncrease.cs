using UnityEngine;
using Player;

namespace Items
{
    [CreateAssetMenu(fileName = "Damage Increase", menuName = "Items/Damage Increase", order = 4)]
    public class DamageIncrease : Item
    {
        [SerializeField] int damageIncrease;

        public override void OnAdd(GameObject playerGO)
        {
            playerGO.GetComponent<PlayerShoot>().IncreaseDamage(damageIncrease);
        }

        public override void OnCollision(Collision collision)
        {
        }

        public override void OnUpdate()
        {
        }
    }
}
