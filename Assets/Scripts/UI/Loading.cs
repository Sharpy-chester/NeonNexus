using UnityEngine;

namespace UIElements
{
    public class Loading : MonoBehaviour
    {
        [SerializeField] float rotateSpeed = 360.0f;

        void FixedUpdate()
        {
            transform.Rotate(transform.forward, rotateSpeed * Time.fixedDeltaTime);
        }
    }
}

