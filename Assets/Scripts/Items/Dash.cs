using UnityEngine;
using Player;

namespace Items
{
    [CreateAssetMenu(fileName = "Dash", menuName = "Items/Dash", order = 7)]
    public class Dash : Item
    {
        [SerializeField] float dashForce = 2.0f;
        [SerializeField] float dashTimer = 3.0f;
        float currentDashTimer = 0.0f;
        PlayerJump jump;
        Rigidbody rb;

        public override void OnAdd(GameObject playerGO)
        {
            jump = playerGO.GetComponent<PlayerJump>();
            rb = playerGO.GetComponent<Rigidbody>();
        }

        public override void OnCollision(Collision collision)
        {
        }

        public override void OnUpdate()
        {
            currentDashTimer += Time.deltaTime;
            if (Input.GetButtonDown("Dash") && currentDashTimer > dashTimer && jump.Grounded())
            {
                currentDashTimer = 0.0f;
                rb.AddForce(rb.transform.forward * rb.GetComponent<PlayerMovement>().speed, ForceMode.Impulse); 
            }
        }
    }
}

