using UnityEngine;

namespace Enemies
{
    public class Bullet : MonoBehaviour
    {
        public int bulletDamage;
        bool hit = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (!hit)
            {
                Destroy(gameObject);
                hit = true;
                Health hp = collision.gameObject.GetComponent<Health>();
                if (hp)
                {
                    hp.ReduceHealth(bulletDamage);
                }

            }
        }
    }
}
