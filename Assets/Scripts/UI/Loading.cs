using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 360.0f;

    void FixedUpdate()
    {
        transform.Rotate(transform.forward, rotateSpeed * Time.fixedDeltaTime);
    }
}
