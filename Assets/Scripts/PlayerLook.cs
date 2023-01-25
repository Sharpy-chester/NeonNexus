using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    Camera cam;

    [Tooltip("Sensitivity of the camera")]
    [SerializeField] float sens;
    internal bool canLook = true;
    bool lockCursor = true;

    float multi = 0.01f;
    float xrot;
    float yrot;
    

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;
    }

    void Update()
    {
        if(canLook)
        {
            xrot -= Input.GetAxisRaw("Mouse Y") * sens * multi;
            yrot += Input.GetAxisRaw("Mouse X") * sens * multi;

            xrot = Mathf.Clamp(xrot, -90.0f, 90.0f);

            cam.transform.localRotation = Quaternion.Euler(xrot, 0, 0);
            transform.rotation = Quaternion.Euler(0, yrot, 0);
        }
    }

    private void FixedUpdate()
    {
        xrot -= Input.GetAxisRaw("Mouse Y") * sens * multi;
        yrot += Input.GetAxisRaw("Mouse X") * sens * multi;
        xrot = Mathf.Clamp(xrot, -90.0f, 90.0f);
        cam.transform.position = transform.position;
        cam.transform.localRotation = Quaternion.Euler(xrot, 0, 0);
        transform.rotation = Quaternion.Euler(0, yrot, 0);
    }

    public void ToggleCursor()
    {
        lockCursor = !lockCursor;
        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;
    }
}
