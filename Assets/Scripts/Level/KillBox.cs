using UnityEngine;

namespace LevelGeneration
{
    public class KillBox : MonoBehaviour
    {
        GameManager gm;

        void Awake()
        {
            gm = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                gm.RestartLevel();
            }
        }
    }
}

