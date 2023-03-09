using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Health Increase", menuName = "Items/Health Increase", order = 3)]
    public class HealthIncrease : Item
    {
        [SerializeField] int healthIncrease;

        public override void OnAdd(GameObject playerGO)
        {
            playerGO.GetComponent<Health>().IncreaseMaxHealth(healthIncrease);
        }

        public override void OnCollision(Collision collision)
        {
        }

        public override void OnUpdate()
        {
        }
    }
}

