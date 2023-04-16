using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement;

public class TutorialEndpoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("TutorialComplete", 1);
            StartCoroutine(LevelManager.Instance.SwitchLevel("SampleScene"));
        }
    }
}
