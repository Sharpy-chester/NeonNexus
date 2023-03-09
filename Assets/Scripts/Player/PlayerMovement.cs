using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody rb;
        PlayerJump jump;

        [Tooltip("Normal speed the player runs at")]
        [SerializeField] float runSpeed = 10.0f;
        [Range(1, 10)]
        [SerializeField] float runDrag = 6.0f;
        [Range(0.1f, 1)]
        [SerializeField] float airDrag = 0.0f;
        public float airSpeed = 0.3f;
        internal float startAirSpeed = 0.3f;

        Vector3 direction;
        float speed;
        internal bool canRun = true;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
            speed = runSpeed;
            jump = GetComponent<PlayerJump>();
            startAirSpeed = airSpeed;
        }

        void Update()
        {
            if (canRun)
            {
                FindMoveDir();
            }
            else
            {
                direction = Vector3.zero;
            }

            if (jump)
            {
                rb.drag = jump.Grounded() ? runDrag : airDrag;
                speed = jump.Grounded() ? runSpeed : airSpeed;
            }
        }

        void FindMoveDir()
        {
            direction = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        }

        void FixedUpdate()
        {
            if (canRun)
            {
                rb.AddForce(direction.normalized * speed, ForceMode.Acceleration);
            }
        }

        public void IncreaseSpeed(float amt)
        {
            runSpeed += amt;
        }
    }
}