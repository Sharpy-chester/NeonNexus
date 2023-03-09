using UnityEngine;
using LevelGeneration;

namespace UIElements
{
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
            transform.LookAt(endPoint, Vector3.up);
            transform.eulerAngles += new Vector3(-90, 90, 0);

        }
    }
}

