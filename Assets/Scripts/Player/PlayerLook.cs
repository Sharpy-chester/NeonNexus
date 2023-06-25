using UnityEngine;

namespace Player
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] Transform vCam;

        [Tooltip("Sensitivity of the camera")]
        public float sens;
        internal bool canLook = true;
        bool lockCursor = true;

        float multi = 0.01f;
        float xrot;
        float yrot;
    

        void Start()
        {
            Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !lockCursor;

            if (PlayerPrefs.GetFloat("Sensitivity") == 0)
            {
                PlayerPrefs.SetFloat("Sensitivity", 1);
            }
        }

        void Update()
        {
            if(canLook)
            {
                xrot -= Input.GetAxisRaw("Mouse Y") * sens * multi * PlayerPrefs.GetFloat("Sensitivity");
                yrot += Input.GetAxisRaw("Mouse X") * sens * multi * PlayerPrefs.GetFloat("Sensitivity");

                xrot = Mathf.Clamp(xrot, -90.0f, 90.0f);

                vCam.localRotation = Quaternion.Euler(xrot, 0, 0);
                transform.rotation = Quaternion.Euler(0, yrot, 0);
            }
        }

        public void UpdateRot(float x, float y)
        {
            xrot = x;
            yrot = y;
        }

        public void ToggleCursor()
        {
            lockCursor = !lockCursor;
            Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !lockCursor;
        }
    }
}

