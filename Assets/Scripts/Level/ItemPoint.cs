using UnityEngine;

namespace LevelGeneration
{
    public class ItemPoint : MonoBehaviour
    {
        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
    }
}

