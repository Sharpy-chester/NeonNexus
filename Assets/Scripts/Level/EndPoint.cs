using UnityEngine;

namespace LevelGeneration
{
    public class EndPoint : MonoBehaviour
    {
        GameManager manager;

        private void Awake()
        {
            manager = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                manager.EndPointReached();
            }
        }
    }
}