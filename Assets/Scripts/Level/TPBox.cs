using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPBox : MonoBehaviour
{
    [SerializeField] Vector3 pos;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = pos + transform.position;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pos + transform.position, 1);
    }
}
