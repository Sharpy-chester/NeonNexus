using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject audioObj;
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void SpawnAudio(AudioClip clip, Vector3 pos)
    {
        GameObject audio = Instantiate(audioObj, pos, Quaternion.identity);
        AudioSource source = audio.GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        Destroy(audio, clip.length);
    }
}
