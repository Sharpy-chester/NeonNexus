using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;

    private void OnCollisionEnter(Collision collision)
    {
        Health hp = collision.gameObject.GetComponent<Health>();
        if (hp)
        {
            hp.ReduceHealth(bulletDamage);
        }
        Destroy(gameObject);
    }
}
