using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrow : MonoBehaviour
{
    Transform endPoint;
    Camera cam;

    void Start()
    {
        endPoint = FindObjectOfType<CityGenerator>().endPoint.transform;
        cam = Camera.main;
    }

    void Update()
    {
        /*Vector3 targetPosLocal = cam.transform.InverseTransformPoint(endPoint.position - cam.transform.position);
        float targetAngle = Mathf.Atan2(-targetPosLocal.x, targetPosLocal.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, targetAngle);*/
        transform.LookAt(endPoint, Vector3.up);
        transform.eulerAngles += new Vector3(-90, 90, 0);

    }
}
