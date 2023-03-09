using UnityEngine;
using Player;

namespace UIElements
{
    public class SpeedLineController : MonoBehaviour
    {
        ParticleSystem speedLinePS;
        Rigidbody playerRB;
        public float minVelocity;

        void Start()
        {
            speedLinePS = GetComponent<ParticleSystem>();
            playerRB = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (playerRB && playerRB.velocity.magnitude > minVelocity)
            {
                speedLinePS.Play();
            }
            else if (speedLinePS.isEmitting)
            {
                speedLinePS.Pause();
                speedLinePS.Clear();
            }
        }
    }
}

