using UnityEngine;
using Player;

namespace Items
{
    [CreateAssetMenu(fileName = "SlideForceIncrease", menuName = "Items/Slide Force Increase", order = 8)]
    public class SlideIncrease : Item
    {
        [SerializeField] float slideForceIncrease = 50.0f;
        PlayerSlide slide;

        public override void OnAdd(GameObject playerGO)
        {
            playerGO.GetComponent<PlayerSlide>().IncreaseSlideForce(slideForceIncrease);
        }

        public override void OnCollision(Collision collision)
        {
        }

        public override void OnUpdate()
        {
        }
    }
}

